// 
// ForceBasedLayout.cs
//  
// Author:
//       Antoine Cailliau <antoine.cailliau@uclouvain.be>
// 
// Copyright (c) 2010 UCLouvain
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using Smog.Physics;
using Smog.Utils;
using Smog.Physics.Force;

namespace Smog.Layout
{
	
	/// <summary>
	/// 	Represents a layout computed by simulating forces applied
	/// 	on particles by a set of forces. <code>N</code> is the type
	/// 	attached to particles, and <code>E</code> is the type attached
	/// 	to springs.
	/// </summary>
	public class ForceBasedLayout<N, E> : PhysicalLayout<N, E>
		where N: Node
		where E: Edge<N>
	{
		
		/// <summary>
		/// 	Whether bounds are enforced.
		/// </summary>
		private bool enforceBounds = false;
		
		/// <summary>
		/// 	Wheter bounds are enforced. It is not possible
		///  	to enforce bounds without proper bounds set.
		/// </summary>
		public bool EnforceBounds  {
			get { return enforceBounds; } 
			set { 
				if (value) {
					enforceBounds = topBound > bottomBound & rightBound > leftBound;
				} else {
					enforceBounds = false;
				}
			}
		}
		
		/// <summary>
		/// 	The top bound.
		/// </summary>
		private double topBound = 0;
		
		/// <summary>
		/// 	The bottom bound.
		/// </summary>
		private double bottomBound = 0;
		
		/// <summary>
		/// 	The left bound.
		/// </summary>
		private double leftBound = 0;
		
		/// <summary>
		/// 	The right bound.
		/// </summary>
		private double rightBound = 0;
		
		/// <summary>
		/// 	The bounds of the layout. Bounds are represented clockwise.
		/// 	There are 4 ways to set bounds:
		/// 	<list type="bullet">
		/// 		<item><code>{ top, right, bottom, left }</code></item>
		/// 		<item><code>{ top, right and left, bottom }</code></item>
		/// 		<item><code>{ top and bottom, right and left }</code></item>
		/// 		<item><code>{ top and right and bottom and left }</code></item>
		/// 	</list>
		/// 	When setting bounds the bounds are automatically enforced
		/// 	if valid.
		/// </summary>
		public double[] Bounds {
			get { return new double[] { topBound, rightBound, bottomBound, leftBound }; }
			set { 
				EnforceBounds = true;
				if (value.Length == 4) {
					topBound = value[0];
					rightBound = value[1];
					bottomBound = value[2];
					leftBound = value[3];
					
				} else if (value.Length == 3) {
					topBound = value[0];
					rightBound = value[1];
					bottomBound = value[2];
					leftBound = value[1];
					
				} else if (value.Length == 2) {
					topBound = value[0];
					rightBound = value[1];
					bottomBound = value[0];
					leftBound = value[1];
					
				} else if (value.Length == 1) {
					topBound = value[0];
					rightBound = value[0];
					bottomBound = value[0];
					leftBound = value[0];
					
				} else {
					EnforceBounds = false;
				}
			}
		}
		
		/// <summary>
		/// 	The list of particles. See <see cref="P:Smog.PhysicalLayout.Particles"/>.
		/// </summary>
		public List<Particle<N>> Particles  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The list of springs. See <see cref="P:Smog.PhysicalLayout.Springs"/>.
		/// </summary>
		public List<Spring<N, E>> Springs  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The list of forces acting for the simulation.
		/// </summary>
		public List<Force> Forces  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The threshold of energy indicating when the simulation ends.
		/// </summary>
		public double Threshold  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The damping factor of the graph.
		/// </summary>
		public double Damping  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	Creates a new layout with no particles, no springs and no forces.
		/// </summary>
		public ForceBasedLayout ()
		{
			Particles = new List<Particle<N>>();
			Springs = new List<Spring<N,E>>();
			Forces = new List<Force>();
			Threshold = .1; Damping = .9;
		}
		
		/// <summary>
		/// 	Creates a new layout with no particles, no springs and no force.
		/// </summary>
		/// <param name="threshold">
		/// 	A <see cref="T:System.Double"/> representing the threshold.
		/// </param>
		public ForceBasedLayout (double threshold)
			: this()
		{
			this.Threshold = threshold;
		}
		
		/// <summary>
		/// 	See <see cref="M:Smog.PhysicalLayout.Init(N[],E[])"/>
		/// </summary>
		/// <param name="nodes">
		/// 	A <see cref="N[]"/> represents the nodes of the graph.
		/// </param>
		/// <param name="edges">
		/// 	A <see cref="E[]"/> represents the edges of the graph.
		/// </param>
		public void Init (N[] nodes, E[] edges)
		{
			// Reset the nodes and particles
			Particles = new List<Particle<N>>();
			Springs = new List<Spring<N,E>>();
			
			Dictionary<N, Particle<N>> attachedParticle = new Dictionary<N, Particle<N>>();
			
			// Creates a particle for each node
			Random r = new Random();
			foreach(N n in nodes) {
				Particle<N> particle = new Particle<N>(r.NextDouble()-.5, r.NextDouble()-.5) { Value = n };
				Particles.Add(particle);
				attachedParticle.Add(n, particle);
			}
			
			// Creates a spring for each edge
			foreach(E e in edges) {
				Springs.Add(new Spring<N, E>(attachedParticle[e.Head], attachedParticle[e.Tail])
					{ Value = e });
			}
		}
		
		/// <summary>
		/// 	See <see cref="M:Smog.PhysicalLayout.Terminate()"/>.
		/// </summary>
		public void Terminate ()
		{
		}
		
		/// <summary>
		/// 	See <see cref="M:Smog.PhysicalLayout.ComputeNextStep(int)"/>.
		/// </summary>
		/// <param name="timeStep">
		/// 	A <see cref="T:System.Double"/> representing the timestep
		/// </param>
		/// <returns>
		/// 	A <see cref="T:System.Boolean"/> representing wheter the are
		/// 	more steps.
		/// </returns>
		public bool ComputeNextStep (double timeStep)
		{	
			foreach (Force f in Forces) {
				f.Apply(this);
			}
			
			
			foreach (Particle<N> p in Particles) {
				double ax = p.XForce / p.Mass;
				double ay = p.YForce / p.Mass;
				
				p.XSpeed = (p.XSpeed + ax * timeStep * timeStep / 2) * Damping;
				p.YSpeed = (p.YSpeed + ay * timeStep * timeStep / 2) * Damping;
				
				p.X += p.XSpeed * timeStep;
				p.Y += p.YSpeed * timeStep;
				
				p.XForce = 0; p.YForce = 0;
			}
			
			// Enforce bounds
			if (EnforceBounds) {
				foreach (Particle<N> p in Particles) {
					p.X = Math.Min(topBound, p.X);
					p.Y = Math.Min(rightBound, p.Y);
					p.X = Math.Max(bottomBound, p.X);
					p.Y = Math.Max(leftBound, p.Y);
				}
			}
			
			// Compute energy
			double kineticEnergy = 0;
			foreach (Particle<N> p in Particles) {
				double speed2 = p.XSpeed * p.XSpeed + p.YSpeed * p.YSpeed;
				kineticEnergy += p.Mass * speed2 / 2;
			}
			
			return kineticEnergy > Threshold;
		}
		
	}
}


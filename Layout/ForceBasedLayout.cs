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
		/// 	The list of particles.
		/// </summary>
		public List<Particle<N>> Particles  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The list of springs.
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
		/// 	Creates a new layout with no particles, no springs and no forces.
		/// </summary>
		public ForceBasedLayout ()
		{
			Particles = new List<Particle<N>>();
			Springs = new List<Spring<N,E>>();
			Forces = new List<Force>();
			Threshold = .1;
		}
		
		/// <summary>
		/// 	Creates a new layout with no particles, no springs and no force.
		/// </summary>
		/// <param name="threshold">
		/// 	A <see cref="System.Double"/> representing the threshold.
		/// </param>
		public ForceBasedLayout (double threshold)
			: this()
		{
			this.Threshold = threshold;
		}

		public void Init (N[] nodes, E[] edges)
		{
			// Reset the nodes and particles
			Particles = new List<Particle<N>>();
			Springs = new List<Spring<N,E>>();
			
			Dictionary<N, Particle<N>> attachedParticle = new Dictionary<N, Particle<N>>();
			
			// Creates a particle for each node
			Random r = new Random();
			foreach(N n in nodes) {
				Particle<N> particle = new Particle<N>(r.NextDouble () - .5, r.NextDouble () - .5, 0, 0)
					{ Value = n };
				Particles.Add(particle);
				attachedParticle.Add(n, particle);
			}
			
			// Creates a spring for each edge
			foreach(E e in edges) {
				Springs.Add(new Spring<N, E>(attachedParticle[e.Head], attachedParticle[e.Tail])
					{ Value = e });
			}
		}

		public void Terminate ()
		{
		}

		public bool ComputeNextStep (double timeStep)
		{			
			foreach (Force f in Forces) {
				f.Apply(this);
			}
			
			double energy = 0;
			foreach (Particle<N> p in Particles) {
				// Update velocities of particles
				p.XSpeed = (p.XSpeed + timeStep * p.XForce);
				p.YSpeed = (p.YSpeed + timeStep * p.YForce);
			
				// Update position of nodes
				p.X = p.X + p.XSpeed * timeStep;
				p.Y = p.Y + p.YSpeed * timeStep;
			
				energy += p.Mass * Math.Sqrt (p.XSpeed * p.XSpeed + p.YSpeed * p.YSpeed);
			}
			
			return energy > Threshold;
		}
		
	}
}


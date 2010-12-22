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
	public class ForceBasedLayout : PhysicalLayout
	{
		
		public List<Particle> Particles  {
			get;
			private set;
		}
		
		public List<Spring> Springs  {
			get;
			private set;
		}
		
		public List<Force> Forces  {
			get;
			private set;
		}
		
		public double Threshold  {
			get;
			private set;
		}
		
		public ForceBasedLayout ()
		{
			Particles = new List<Particle>();
			Springs = new List<Spring>();
			Forces = new List<Force>();
			Threshold = .1;
		}
		
		public ForceBasedLayout (double threshold)
			: base()
		{
			this.Threshold = threshold;
		}

		
		public void Init (Utils.Node[] nodes, Utils.Edge[] edges)
		{
			Dictionary<Node, Particle> attachedParticle = new Dictionary<Node, Particle>();
			
			// Creates a particle for each node
			Random r = new Random();
			foreach (Node n in nodes) {
				Particle particle = new Particle(r.NextDouble () - .5, r.NextDouble () - .5, 0, 0);
				Particles.Add(particle);
				attachedParticle.Add(n, particle);
			}
			
			// Creates a spring for each edge
			foreach (Edge e in edges) {
				Springs.Add(new Spring(attachedParticle[e.Head], attachedParticle[e.Tail]));
			}
		}

		public void Terminate ()
		{
			throw new NotImplementedException ();
		}

		public bool ComputeNextStep (double timeStep)
		{			
			foreach (Force f in Forces) {
				f.Apply(this);
			}
			
			double energy = 0;
			foreach (Particle p in Particles) {
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


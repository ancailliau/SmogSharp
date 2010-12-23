// 
// SpringForce.cs
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
using Smog.Layout;
using Smog.Utils;
namespace Smog.Physics.Force
{
	/// <summary>
	/// 	Represents the force applied by springs on particles.
	/// </summary>
	public class SpringForce : Force
	{
		
		/// <summary>
		/// 	Creates a new spring force.
		/// </summary>
		public SpringForce ()
		{
		}
		
		/// <summary>
		/// 	See <see cref="M:Smog.Force.Apply(PhysicalLayout)"/>.
		/// </summary>
		/// <param name="l">
		/// 	A <see cref="T:PhysicalLayout"/> representing a physical layout.
		/// </param>
		public void Apply<S, T> (PhysicalLayout<S, T> l)
			where S: Node where T: Edge<S>
		{
			
			foreach (Particle<S> p in l.Particles) {				
				foreach (Spring<S, T> s in l.Springs) {
					if (s.Particle1 == p | s.Particle2 == p) {
						Particle<S> op;
						if (s.Particle1 == p) {
							op = s.Particle2;
						} else {
							op = s.Particle1;
						}						
						
						double dx = p.X - op.X;
						double dy = p.Y - op.Y;
						
						
						double d = Math.Sqrt(dx*dx + dy*dy);
						double dd = d < 1 ? 1 : d;
						
						if (d == 0) {
							Random r = new Random();
							dx = .01 * (r.NextDouble() - 0.5);
							dy = .01 * (r.NextDouble() - 0.5);
						}
						
						double k = s.Strenght * (d - s.Length);
						
						double fx = -k * dx / dd;
						double fy = -k * dy / dd;
						
						p.XForce += fx;
						p.YForce += fy;
					}
				}
			}
		}
	}
}


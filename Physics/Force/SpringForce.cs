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
namespace Smog.Physics.Force
{
	public class SpringForce
	{
		public SpringForce ()
		{
		}
		
		public void Apply (PhysicalLayout l)
		{
			
			foreach (Spring s in l.Springs) {
			
				// Distance between the two particles
				double xdistance = (s.Particle1.X - s.Particle2.X);
				double ydistance = (s.Particle1.Y - s.Particle2.Y);
				double distance = Math.Sqrt (xdistance * xdistance + ydistance * ydistance);
			
				// Force of the spring on the particles
				double force = s.Strenght * (distance - s.Length) / distance;
			
				// Add force to particles
				s.Particle1.XForce += - force * xdistance;
				s.Particle1.XForce += - force * ydistance;
				
				s.Particle2.XForce -= - force * xdistance;
				s.Particle2.YForce -= - force * ydistance;
				
			}
			
			
		}
		
	}
}


// 
// Spring.cs
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
namespace Smog.Physics
{
	
	/// <summary>
	/// 	Represents a physical spring. A spring is defined by its strenght
	/// 	and its natural length. An other important characteristics is the
	/// 	damping factor of the spring.
	/// </summary>
	public class Spring
	{
		
		/// <summary>
		/// 	One of the particle attached to the spring.
		/// </summary>
		public Particle Particle1  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The other particle attached to the spring.
		/// </summary>
		public Particle Particle2  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The strenght of the spring.
		/// </summary>
		public double Strenght  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The natural length of the spring.
		/// </summary>
		public double Length  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The damping factor of the spring.
		/// </summary>
		public double Damping  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	A tag to attach elements to the spring.
		/// </summary>
		public int Tag  {
			get;
			set;
		}
		
		/// <summary>
		/// 	Creates a new spring between the two given particles, of
		/// 	unitary length and strenght.
		/// </summary>
		/// <param name="p1">
		/// A <see cref="Particle"/> representing one particle.
		/// </param>
		/// <param name="p2">
		/// A <see cref="Particle"/> representing the other particle.
		/// </param>
		public Spring (Particle p1, Particle p2)
		{
			Particle1 = p1;
			Particle2 = p2;
			Strenght = 1;
			Length = 1;
			Damping = Length / 10;
		}
		
		/// <summary>
		///		Creates a new spring between the two given particles, of unitary
		///		length and given strenght.
		/// </summary>
		/// <param name="particle1">
		/// 	A <see cref="Particle"/> representing one particle.
		/// </param>
		/// <param name="particle2">
		/// 	A <see cref="Particle"/> representing the other particle.
		/// </param>
		/// <param name="strenght">
		/// 	A <see cref="System.Double"/> representing the strenght of the
		/// 	spring.
		/// </param>
		public Spring (Particle particle1, Particle particle2, double strenght)
			: this(particle1, particle2)
		{
			this.Strenght = strenght;
		}
		
		/// <summary>
		/// 	Creates a new spring between the given particles of given length
		/// 	and strenght.
		/// </summary>
		/// <param name="particle1">
		/// 	A <see cref="Particle"/> representing one particle.
		/// </param>
		/// <param name="particle2">
		/// 	A <see cref="Particle"/> representing the other particle.
		/// </param>
		/// <param name="strenght">
		/// 	A <see cref="System.Double"/> representing the strenght of the
		/// 	spring.
		/// </param>
		/// <param name="length">
		/// 	A <see cref="System.Double"/> representing the length of the
		/// 	spring.
		/// </param>
		public Spring (Particle particle1, Particle particle2, double strenght, double length)
			: this(particle1, particle2, strenght)
		{
			Length = length;
			Damping = Length / 10;
		}
	
		/// <summary>
		/// 	Creates a new spring between the given particles of given length
		/// 	and strenght. The damping factor is equal to the given one.
		/// </summary>
		/// <param name="particle1">
		/// 	A <see cref="Particle"/> representing one particle.
		/// </param>
		/// <param name="particle2">
		/// 	A <see cref="Particle"/> representing the other particle.
		/// </param>
		/// <param name="strenght">
		/// 	A <see cref="System.Double"/> representing the strenght of the
		/// 	spring.
		/// </param>
		/// <param name="length">
		/// 	A <see cref="System.Double"/> representing the length of the
		/// 	spring.
		/// </param>
		/// <param name="damping">
		/// 	A <see cref="System.Double"/> representing the damping factor of
		/// 	the spring.
		/// </param>
		public Spring (Particle particle1, Particle particle2, double strenght, double length, double damping)
		{
			this.Particle1 = particle1;
			this.Particle2 = particle2;
			this.Strenght = strenght;
			this.Length = length;
			this.Damping = damping;
		}
		
	}
}


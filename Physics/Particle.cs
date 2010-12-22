// 
// Particle.cs
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
	/// 	Represents a particle which is a punctual mass with a position
	/// 	and a speed. Forces can be applied to particle. These are null by
	/// 	default.
	/// </summary>
	public class Particle
	{
		
		/// <summary>
		/// 	The x-coordinate of the particle
		/// </summary>
		public double X  {
			get;
			set;
		}
		
		/// <summary>
		/// 	The y-coordinate of the particle
		/// </summary>
		public double Y  {
			get;
			set;
		}
		
		/// <summary>
		/// 	The speed along the x-axis
		/// </summary>
		public double XSpeed  {
			get;
			set;
		}
		
		/// <summary>
		/// 	The speed along the y-axis
		/// </summary>
		public double YSpeed  {
			get;
			set;
		}
		
		/// <summary>
		/// 	The force applied to the particle along the x-axis.
		/// </summary>
		public double XForce  {
			get;
			set;
		}
		
		/// <summary>
		/// 	The force applied to the particle along the y-axis.
		/// </summary>
		public double YForce  {
			get;
			set;
		}
		
		/// <summary>
		/// 	The mass of the particle
		/// </summary>
		public double Mass  {
			get;
			set;
		}
		
		/// <summary>
		/// 	A tag to attach elements to the particle.
		/// </summary>
		public int Tag  {
			get;
			set;
		}
		
		/// <summary>
		/// 	Creates a new particle, centered at (0, 0) with null speed 
		/// 	and unitary mass.
		/// </summary>
		public Particle ()
		{
			X = 0; Y = 0;
			XSpeed = 0; YSpeed = 0;
			XForce = 0; YForce = 0;
			Mass = 1;
		}

		/// <summary>
		/// 	Creates a new particle, centered at (0, 0) with null speed
		/// 	and the given mass.
		/// </summary>
		/// <param name="mass">
		/// 	A <see cref="System.Double"/> representing the mass.
		/// </param>
		public Particle (double mass)
		{
			Mass = mass;
		}
		
		/// <summary>
		/// 	Creates a new particle, centered at the given position, with
		///   null speed and the given mass.
		/// </summary>
		/// <param name="x">
		/// 	A <see cref="System.Double"/> representing the x-coordinate
		/// </param>
		/// <param name="y">
		/// 	A <see cref="System.Double"/> representing the y-coordinate
		/// </param>
		public Particle (double x, double y)
			: this()
		{
			X = x;
			Y = y;
		}
		
		/// <summary>
		/// 	Creates a new particle centered at the given position,
		/// 	of null speed and with given mass.
		/// </summary>
		/// <param name="x">
		/// 	A <see cref="System.Double"/> representing the x-coordinate
		/// </param>
		/// <param name="y">
		/// 	A <see cref="System.Double"/> representing the y-coordinate
		/// </param>
		/// <param name="mass">
		/// 	A <see cref="System.Double"/> representing the mass
		/// </param>
		public Particle (double x, double y, double mass)
			: this(x, y)
		{
			Mass = mass;
		}
		
		/// <summary>
		/// 	Creates a new particle centered at the given position,
		/// 	of given speed and of unitary mass.
		/// </summary>
		/// <param name="x">
		/// 	A <see cref="System.Double"/> representing the x-coordinate.
		/// </param>
		/// <param name="y">
		/// 	A <see cref="System.Double"/> representing the y-coordinate.
		/// </param>
		/// <param name="xSpeed">
		/// 	A <see cref="System.Double"/> representing the speed along the x-axis.
		/// </param>
		/// <param name="ySpeed">
		/// 	A <see cref="System.Double"/> representing the speed along the y-axis.
		/// </param>
		public Particle (double x, double y, double xSpeed, double ySpeed)
			: this(x, y)
		{
			XSpeed = xSpeed;
			YSpeed = ySpeed;
		}
		
		/// <summary>
		/// 	Creates a new particle, centered at given position, with an initial
		/// 	speed given and of given mass.
		/// </summary>
		/// <param name="x">
		/// 	A <see cref="System.Double"/> representing the x-coordinate.
		/// </param>
		/// <param name="y">
		/// 	A <see cref="System.Double"/> representing the y-coordinate.
		/// </param>
		/// <param name="xSpeed">
		/// 	A <see cref="System.Double"/> representing the speed along the 
		/// 	x-axis.
		/// </param>
		/// <param name="ySpeed">
		/// 	A <see cref="System.Double"/> representing the speed along the
		/// 	y-axis.
		/// </param>
		/// <param name="mass">
		/// 	A <see cref="System.Double"/> representing the mass of the
		/// 	particle.
		/// </param>
		public Particle (double x, double y, double xSpeed, double ySpeed, double mass)
			: this(x, y, xSpeed, ySpeed)
		{
			Mass = mass;
		}
		
	}
}


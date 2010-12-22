// 
// Layout.cs
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
using Smog.Utils;

namespace Smog.Layout
{
	
	/// <summary>
	/// 	Represents an algorithm to draw graph
	/// </summary>
	public interface GraphLayout
	{
		
		/// <summary>
		/// 	Initializes the algorithm by setting proper value to nodes and
		/// 	springs for the algorithm to start.
		/// </summary>
		/// <param name="nodes">
		/// 	A <see cref="Node[]"/> representing the nodes of the graph.
		/// </param>
		/// <param name="edges">
		/// 	A <see cref="Edge[]"/> representing the edges of the graph.
		/// </param>
		void Init (Node[] nodes, Edge[] edges);
		
		/// <summary>
		/// 	Closes
		/// 	<code>ComputeNextStep</code> can't be called afterwards.
		/// </summary>
		void Terminate ();
		
		/// <summary>
		/// 	Computes the next step of the simulation. The method returns
		/// 	whether there are more steps to do.
		/// </summary>
		bool ComputeNextStep(double timeStep);	
		
	}
}


// 
// Edge.cs
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

namespace Smog.Utils
{
	
	/// <summary>
	///		Represents a directed edge between two nodes
	/// </summary>
	public class Edge<S> where S: Node
	{
		
		/// <summary>
		/// 	The head of the edge
		/// </summary>
		public S Head  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The tail of the edge.
		/// </summary>
		public S Tail  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	Creates a new edge from <c>head</c> to <c>tail</c>.
		/// </summary>
		/// <param name="head">
		/// 	A <see cref="S"/> representing the head of the edge.
		/// </param>
		/// <param name="tail">
		/// 	A <see cref="S"/> representing the tail of the edge.
		/// </param>
		public Edge (S head, S tail)
		{
			this.Head = head;
			this.Tail = tail;
		}
		
	}
}


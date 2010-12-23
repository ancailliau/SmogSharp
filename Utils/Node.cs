// 
// Node.cs
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
	/// 	Represents a node in the graph.
	/// </summary>
	public class Node
	{
		
		/// <summary>
		/// 	The value contained in the node.
		/// </summary>
		public Object Value { get ; set ; }
		
		/// <summary>
		/// 	The weight of the node.
		/// </summary>
		public double Weight = 1;
		
		/// <summary>
		/// 	Creates a new node for the given value.
		/// </summary>
		/// <param name="val">
		/// 	A <see cref="T:System.Object"/> representing the value of the node.
		/// </param>
		public Node (Object val)
		{
			Value = val;
		}
		
		/// <summary>
		/// 	Creates a new node for the given value and given weight.
		/// </summary>
		/// <param name="val">
		/// 	A <see cref="T:System.Object"/> representing the value of the node.
		/// </param>
		/// <param name="weight">
		/// 	A <see cref="T:System.Double"/> representing the weight of the node.
		/// </param>
		public Node (Object val, double weight)
		{
			Value = val;
			Weight = weight;
		}
	}
}


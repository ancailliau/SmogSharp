// 
// Simulation.cs
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
using System.Collections.Generic;
namespace Smog
{
	
	/// <summary>
	/// 	Represents an event handler called when the visualisation
	/// 	starts.
	/// </summary>
	public delegate void StartedEventHandler(object sender, EventArgs e);
	
	/// <summary>
	/// 	Represents an event handler called when the visualisation stops.
	/// </summary>
	public delegate void StoppedEventHandler(object sender, EventArgs e);
	
	/// <summary>
	/// 	Represents an event handler called when the visualisation is
	/// 	interrupted.
	/// </summary>
	public delegate void InterruptedEventHandler(object sender, EventArgs e);
	
	/// <summary>
	/// 	Represents an event handler called when the visualisation
	/// 	changes.
	/// </summary>
	public delegate void ChangedEventHandler(object sender, EventArgs e);
	
	/// <summary>
	/// 	Represents a visualisation
	/// </summary>
	public class Visualisation<N, E>
		where N: Node where E: Edge<N>
	{
		/// <summary>
		/// 	The edges of the graph.
		/// </summary>
		public List<E> Edges  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The nodes of the graph.
		/// </summary>
		public List<N> Nodes {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The event raised when visualisation starts.
		/// </summary>
		public event StartedEventHandler Started;
		
		/// <summary>
		/// 	The event raised when visualisation ends.
		/// </summary>
		public event StoppedEventHandler Stopped;
		
		/// <summary>
		/// 	The event raised when visualisation is interrupted.
		/// </summary>
		public event InterruptedEventHandler Interrupted;
		
		/// <summary>
		/// 	The event raised when the visualisation changed.
		/// </summary>
		public event ChangedEventHandler Changed;
		
		/// <summary>
		/// 	Raise <c>Started</c> event.
		/// </summary>
		/// <param name="e">
		/// 	A <see cref="EventArgs"/> representing the args of 
		/// 	the visualisation.
		/// </param>
		protected virtual void OnStarted(EventArgs e)
		{
			if (Started != null) {
				Started(this, e);
			}
		}
				
		/// <summary>
		/// 	Raise <c>Stopped</c> event.
		/// </summary>
		/// <param name="e">
		/// 	A <see cref="EventArgs"/> representing the args of 
		/// 	the visualisation.
		/// </param>
		protected virtual void OnStopped(EventArgs e)
		{
			if (Stopped != null) {
				Stopped(this, e);
			}
		}		
		
		/// <summary>
		/// 	Raise <c>Interrupted</c> event.
		/// </summary>
		/// <param name="e">
		/// 	A <see cref="EventArgs"/> representing the args of 
		/// 	the visualisation.
		/// </param>
		protected virtual void OnInterrupted(EventArgs e)
		{
			if (Interrupted != null) {
				Interrupted(this, e);
			}
		}
		
		/// <summary>
		/// 	Raise <c>Changed</c> event.
		/// </summary>
		/// <param name="e">
		/// 	A <see cref="EventArgs"/> representing the args of 
		/// 	the visualisation.
		/// </param>
		protected virtual void OnChanged(EventArgs e) 
		{
			if (Changed != null) {
				Changed(this, e);
			}
		}
		
		/// <summary>
		/// 	Represents the time step used for the simulation.
		/// </summary>
		public double TimeStep  {
			get;
			private set;
		}
		
		/// <summary>
		/// 	The layout used for the visualisation
		/// </summary>
		public GraphLayout<N, E> Layout {
			get;
			private set;
		}
		
		/// <summary>
		/// 	Creates a new visualisation with the given layout.
		/// </summary>
		/// <param name="layout">
		/// 	A <see cref="T:Smog.GraphLayout"/> representing the layout
		/// 	to use for the visualisation.
		/// </param>
		public Visualisation (GraphLayout<N, E> layout)
		{
			Layout = layout;
			TimeStep = .5;
			Nodes = new List<N>();
			Edges = new List<E>();
		}
		
		/// <summary>
		/// 	Initializes the visualisation.
		/// </summary>
		public void Init ()
		{
			Layout.Init(Nodes.ToArray(), Edges.ToArray());
			OnStarted(EventArgs.Empty);
		}
		
		/// <summary>
		/// 	Terminates the visualisation.
		/// </summary>
		public void Terminate ()
		{
			Layout.Terminate();
			OnStopped(EventArgs.Empty);
		}
		
		/// <summary>
		/// 	Runs the visualisation for a step.
		/// </summary>
		/// <returns>
		/// 	A <see cref="T:System.Boolean"/> representing wheter the
		/// 	visualisation ended.
		/// </returns>
		public bool StepRun ()
		{
			bool result = Layout.ComputeNextStep(TimeStep);
			OnChanged(EventArgs.Empty);
			return result;
		}
		
		/// <summary>
		/// 	Runs the visualisation.
		/// </summary>
		public void BatchRun()
		{
			Init();
			while(StepRun()) {
			}
			Terminate();
		}
		
	}
}


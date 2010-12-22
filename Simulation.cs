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
		
	public delegate void StartedEventHandler(object sender, EventArgs e);
	public delegate void StoppedEventHandler(object sender, EventArgs e);
	public delegate void InterruptedEventHandler(object sender, EventArgs e);
	public delegate void ChangedEventHandler(object sender, EventArgs e);
	
	public class Simulation<S, T>
		where S: Node where T: Edge<S>
	{
		
		public List<T> Edges  {
			get;
			private set;
		}
		
		public List<S> Nodes {
			get;
			private set;
		}
		
		public event StartedEventHandler Started;
		public event StoppedEventHandler Stopped;
		public event InterruptedEventHandler Interrupted;
		public event ChangedEventHandler Changed;
		
		protected virtual void OnStarted(EventArgs e)
		{
			if (Started != null) {
				Started(this, e);
			}
		}
				
		protected virtual void OnStopped(EventArgs e)
		{
			if (Stopped != null) {
				Stopped(this, e);
			}
		}		
		
		protected virtual void OnInterrupted(EventArgs e)
		{
			if (Interrupted != null) {
				Interrupted(this, e);
			}
		}
		
    protected virtual void OnChanged(EventArgs e) 
    {
      if (Changed != null) {
          Changed(this, e);
			}
    }
		
		
		public double TimeStep  {
			get;
			private set;
		}
		
		public GraphLayout<S, T> Layout {
			get;
			private set;
		}
		
		public Simulation (GraphLayout<S, T> layout)
		{
			Layout = layout;
			TimeStep = 1;
			Nodes = new List<S>();
			Edges = new List<T>();
		}
		
		public void Init ()
		{
			Layout.Init(Nodes.ToArray(), Edges.ToArray());
			OnStarted(EventArgs.Empty);
		}
		
		public void Terminate ()
		{
			Layout.Terminate();
			OnStopped(EventArgs.Empty);
		}
		
		public bool StepRun ()
		{
			bool result = Layout.ComputeNextStep(TimeStep);
			OnChanged(EventArgs.Empty);
			return result;
		}
		
		public void BatchRun()
		{
			Init();
			while(StepRun()) {
			}
			Terminate();
		}
		
	}
}


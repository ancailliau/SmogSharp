# Smog\#

* [Project Source](http://github.com/ancailliau/smog)

## Description
	
Smog# aims at providing reusable facilities to draw graph by proposing well-documented API.
	
An additionnal objective of the project is to make experimentation with other layouts
possible and easy. Trial and error is sometimes the best way to find **the** right graph.
With a common API, such process is easy to perform.

The project is at its very first steps. The API is therefore highly unstable and more features are to come.

## Requirements

* Mono >= 2.8.1

## Examples of use

### Basic physical simulation

	var layout = new ForceBasedLayout<Node, Edge<Node>>();
	layout.Forces.Add(new SpringForce());
	
	var visualisation = new Visualisation<Node, Edge<Node>>(layout);
	
	Node[] nodes = {
		new Node("node0"), new Node("node1"), new Node("node2"), new Node("node3"),
		new Node("node4"), new Node("node5"), new Node("node6")
	};
	
	Edge<Node>[] edges = {
		new Edge<Node>(nodes[0], nodes[1]), new Edge<Node>(nodes[1], nodes[2]),
		new Edge<Node>(nodes[2], nodes[3]),	new Edge<Node>(nodes[3], nodes[4]),
		new Edge<Node>(nodes[4], nodes[5]),	new Edge<Node>(nodes[5], nodes[6]),
		new Edge<Node>(nodes[6], nodes[0])
	};
	
	foreach (Node n in nodes) {
		visualisation.Nodes.Add(n);
	}
	
	foreach (Edge<Node> e in edges) {
		visualisation.Edges.Add(e);
	}
	
	visualisation.BatchRun();

### Event handlers

In addition to the previous code, one can attach event handlers to act upon
visualition changes.
	
	visualisation.Started += delegate(object sender, EventArgs e) {
		Console.WriteLine("Simulation Started");
	};
	
	visualisation.Stopped += delegate(object sender, EventArgs e) {
		Console.WriteLine("Simulation Stopped");
	};
	
	visualisation.Changed += delegate(object sender, EventArgs e) {
		Console.WriteLine("Simulation changed");
	};

## Licence

    (The MIT License)

    Copyright (c) 2010 UCLouvain

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    'Software'), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
    CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
    TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
    SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
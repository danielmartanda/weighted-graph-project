/* 
================================================================
Course: COIS 3020 - Data Structures and Algorithms II
Assignment 1: Weighted Graph - Shortest Path
Date: October 2025

Project Description: 
This program implements a weighted directed graph using an adjacency list.
It populates graph data from a JSON file and finds the shortest path between 
two nodes using a shortest path algorithm. 

Authors:
1. Ussanth Balasingam - Student ID: 0765174
2. Daniel Martanda - Student ID: 0813510

================================================================
*/

/* 
--------------------------------------------
Graph Data Structure - Weighted and Directed    
--------------------------------------------
- Utilizes a Dictionary that stores key-value pairs
- Consists of nodes ("Location A", "Location B",...)
    - These are string based location names, parsed from a JSON file to populate data
- Consists of edges that map relationships between nodes ("Location A" to "Location B", 13 minutes)
   - These are string based location names and integer weights 
   - Stored in an adjacency list
- Includes methods for adding nodes and edges
*/

using System;
using System.Collections.Generic;

namespace WeightedGraph
{
    class Graph
    {
        //VARIABLES
        //This stores each node (starting location) and its adjacency list of edges 
        //  Each edge contains a destination location and travel time (weight)
        private Dictionary<string, List<(string neighbour, int weight)>> adjacencyList;

        //CONSTRUCTOR FOR GRAPH OBJECT
        public Graph()
        {
            //This initializes an empty adjacency list that stores nodes and edges
            adjacencyList = new Dictionary<string, List<(string, int)>>();
        }

        //METHODS
        //This method adds a node (string based location name) to the graph if it doesn't exist
        public void AddNode(string node)
        {
            //This checks if the graph contains a specific node (key)
            if (!adjacencyList.ContainsKey(node))
            {
                //If not, create a new entry in the dictionary with an empty adjacency list
                adjacencyList[node] = new List<(string neighbour, int weight)>();
            }
        }

        //This method adds an edge (directed connection) from one node to another with a travel time (weight)
        public void AddEdge(string origin, string destination, int weight)
        {
            //This ensures that both nodes (locations) exist in the graph before adding the edge (weighted connection)
            AddNode(origin);
            AddNode(destination);

            //This adds the directed edge from the origin node to destination node
            adjacencyList[origin].Add((destination, weight));
        }

        //This method displays all nodes and it's respective adjacency list
        public void PrintGraph()
        {
            //This loops through each node in the adjacency list
            foreach (var node in adjacencyList)
            {
                //This prints the starting node
                Console.WriteLine($"{node.Key} -> ");

                //This loops through each connected neighbour of the current node
                
            }
        }

    }
}
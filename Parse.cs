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
-----------------------------------------
JSON Parsing Method
-----------------------------------------
- Helper method to ingest the provided JSON file to populate the graph
- Each node's adjacency list is constructed from the parsed data. 
- (Optional) Data can be hardcoded if JSON parsing is hard. Resulting in 15% deduction.
- Recommended: Include a print helper method to display all nodes for testing. 
*/

using System;
using System.Text.Json;

namespace WeightedGraph
{

    //CLASSES
    //  - These classes are used to deserialize the JSON file into C# objects

    //This class represents the entirety of the JSON file
    // - Contains all nodes and edges 
    public class GraphData
    {
        //This list contains all nodes (location names)
        public List<string> nodes { get; set; }

        //This list contains all edges and weights
        public List<EdgeData> edges { get; set; }
    }

    //This class represents an edge from the JSON file
    // - Contains directed connections between nodes and their associated travel time
    public class EdgeData
    {
        public string origin { get; set; }      //Origin node (starting location)
        public string destination { get; set; } //Targeted node (destination location)
        public int weight { get; set; }         //Edge weight (travel time between nodes)
    }

    static class Parse
    {
        //METHODS
        //This method reads the provided JSON file and populates the graph with its data
        public static void LoadGraphDataFromJson(Graph graph, string filePath)
        {
            //Reading JSON data
            string jsonString = File.ReadAllText(filePath);
            
            //Deserialize into objects
            GraphData data = JsonSerializer.Deserialize<GraphData>(jsonString);
            
            //Add nodes and edges to graph 
            foreach (var node in data.nodes)
            {
                graph.AddNode(node);
            }
            
            foreach (var edge in data.edges)
            {
                graph.AddEdge(edge.origin, edge.destination, edge.weight);
            }
        }

    }
}
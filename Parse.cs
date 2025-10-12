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
JSON Parsing Component
-----------------------------------------
- Responsible for loading and converting JSON graph data into the Graph data structure
- Reads nodes and edges, then uses Graph.cs methods (AddNode and AddEdge) to build the adjacency list 
- (Recommendation) Include a print helper method to display all nodes for testing
- (Optional) Data can be hardcoded but results in 15% deduction 
*/

using System;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace WeightedGraph
{

    //JSON DATA CLASSES
    //  - These classes represent the structure of the JSON file
    //  - They are used to deserialize JSON into C# objects

    //This class represents a directed edge in the JSON file
    // - Includes the source, target and weighted travel time (time_min)
    public class EdgeData
    {
        public string source { get; set; }      //Source node (starting location)
        public string target { get; set; }      //Targeted node (destination location)
        public int time_min { get; set; }       //Edge weight (travel time between nodes)
    }

    //This class represents the entire JSON file
    // - Contains separate lists of nodes and edges 
    public class GraphData
    {
        public List<string> nodes { get; set; }     //List of all nodes (location names)
        public List<EdgeData> edges { get; set; }   //List of all directed edges and weights
    }

    //PARSING CLASS
    //  - Contains method to convert JSON data into the Graph
    static class Parse
    {
        //This method reads a JSON file and populates data into the Graph object
        public static void LoadGraphDataFromJson(Graph graph, string filePath)
        {
            //This reads the entire JSON file
            string jsonString = File.ReadAllText(filePath);

            //This converts the JSON string into GraphData object (deserializing)
            GraphData data = JsonSerializer.Deserialize<GraphData>(jsonString);

            //This adds all nodes to the graph 
            foreach (var node in data.nodes)
            {
                graph.AddNode(node);
            }

            //This adds all edges to the graph 
            foreach (var edge in data.edges)
            {
                graph.AddEdge(edge.source, edge.target, edge.time_min);
            }
        }

    }
}
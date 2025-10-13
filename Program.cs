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
Program/Driver Code (Main)
-----------------------------------------
- Prompts user to input a source and target location
- Calculates and prints the shortest path & total cost
- Make sure you print out the location along the path to the destination (if any exist)  
- Includes validation to ensure source and target nodes exist
*/

using System;
using System.Collections.Generic;

namespace WeightedGraph
{
    class Program
    {
        static void Main()
        {

            //Clears the console
            Console.Clear();

            //Creates a new graph
            Graph graph = new Graph();

            //Loads graph data from the JSON file
            //  - Uses relative path and goes backwards three levels to get to root folder
            Parse.LoadGraphDataFromJson(graph, @"../../../GraphData.json");

            //Displays the graph structure (populated from parsed JSON)
            Console.WriteLine("Directed & Weighted Graph");
            Console.WriteLine("-------------------------");
            graph.PrintGraph();

            //User prompt
            Console.WriteLine();
            Console.Write("Please enter a starting location (Ex. Location B) -> ");
            string origin = Console.ReadLine();

            Console.Write("Please enter a destination location (Ex. Location G) -> ");
            string destination = Console.ReadLine();

            //Normalizes input to allow user to also enter just a letter instead of location
            if (!origin.StartsWith("Location "))
            {
                origin = "Location " + origin.Trim();
            }
            if (!destination.StartsWith("Location "))
            {
                destination = "Location " + destination.Trim();
            }

            //Calculates shortest path
            Algorithm.DijkstraShortestPath(graph, origin, destination);

        }
        
    }
}
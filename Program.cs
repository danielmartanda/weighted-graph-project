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
Graph Data Structure
-----------------------------------------
- Implements a graph composed of nodes that store their edges in an adjacency list 
- Provides methods for adding nodes and edges 
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


/* 
-----------------------------------------
Shortest Path Algorithm
-----------------------------------------
- Method to compute the shortest path between any two locations (nodes) on the map (graph)
- We can use any algorithm that will find the shortest path between two nodes on a graph
- Add nodes/edges as needed to test out edge cases
- Justify our choice of algorithm in the testing document 
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

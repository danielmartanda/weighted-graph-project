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

//NOTES
/* Dijkstra's algorithm initializes all vertices' distances to infinity (∞), initializes all vertices' predecessors
to null, and enqueues all vertices into a queue of unvisited vertices. The algorithm then assigns the
start vertex's distance with 0. While the queue is not empty, the algorithm dequeues the vertex with
the shortest distance. For each adjacent vertex, the algorithm computes the distance of the path from
the start vertex to the current vertex and continuing on to the adjacent vertex. If that path's distance is
shorter than the adjacent vertex's current distance, a shorter path has been found. The adjacent
vertex's current distance is updated to the distance of the newly found shorter path's distance, and
vertex's predecessor pointer is pointed to the current vertex. */

/* 
-----------------------------------------
 Dijkstra's Shortest Path Algorithm
-----------------------------------------
- Calculates the shortest path between any two locations (nodes) on the map (graph)
- Works with the Graph class (directed and weighted adjacency list)
- Utilizes a priority-based approach to determine the shortest path
- Tracks distances using a Dictionary<string, int>
- Tracks previous nodes to construct a path
- Throws exceptions if invalid source and target nodes are provided
- (Note) May add nodes/edges as needed to test out edge cases
- (Note) Must justify our choice of algorithm in the testing document 
*/

namespace WeightedGraph
{
    class Algorithm
    {
        //METHOD
        //This method calculates and prints the shortest path between two nodes
        public static void DijkstraShortestPath(Graph graph, string source, string target)
        {
            //This checks if both start and end nodes exist within the graph
            if (!graph.ContainsNode(source) || !graph.ContainsNode(target))
            {
                throw new ArgumentException("Error: One or both nodes do not exist in the graph");
            }

            //VARIABLES
            Dictionary<string, int> distance = new Dictionary<string, int>();  //This stores the shortest known distance to each node
            Dictionary<string, string?> previous = new Dictionary<string, string?>(); //This stores the previous node for path construction, allows null
            HashSet<string> visited = new HashSet<string>();                        //This tracks the visited nodes

            //Initializes all distances to infinity and previous to null
            foreach (var node in graph.GetAllNodes())
            {
                distance[node] = int.MaxValue;
                previous[node] = null;
            }

            //Initialize distance to the start node to zero
            distance[source] = 0;

            //Main loop
            while (true)
            {
                //This selected the unvisited node with the smallest known distance
                string current = null;
                int minDistance = int.MaxValue;

                //Loop through all nodes that are still unvisited
                foreach (var node in graph.GetAllNodes())
                {
                    //This checks if the node is unvisited and has a smaller distance than the current minimum
                    if (!visited.Contains(node) && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        current = node;
                    }
                }

                //If no such node is found, then all reachable nodes have been processed and we exit
                if (current == null)
                {
                    break;      //Exit our main loop
                }

                //This marks the current node as visited
                visited.Add(current);

                //If the target node has been reached, we stop scanning further
                if (current == target)
                {
                    break;
                }

                //Checks all adjacent neighbours in reference to current node
                foreach (var (neighbour, weight) in graph.GetNeighbours(current))
                {
                    int newDistance = distance[current] + weight;

                    //If a shorter path to neighbour is found, update the distance and previous
                    if (newDistance < distance[neighbour])
                    {
                        distance[neighbour] = newDistance;
                        previous[neighbour] = current;
                    }
                }
            }

            //If no path exists between source and target
            if (distance[target] == int.MaxValue)
            {
                throw new Exception($"No path found from {source} to {target}");
            }

            //This constructs the path using the previous dictionary
            List<string> path = new List<string>();
            string? step = target;

            //Rebuilds the path backwards from target to source
            while (step != null)
            {
                path.Add(step);
                step = previous[step];
            }

            //Reverses to show the order from source to target
            path.Reverse();

            //Labelled output
            Console.WriteLine();
            Console.WriteLine($"Source: {source}");
            Console.WriteLine($"Target: {target}");
            Console.WriteLine($"Path: {string.Join(" -> ", path)}");
            Console.WriteLine($"Total Travel Time: {distance[target]} minutes");
            Console.WriteLine();
        }

    }
}

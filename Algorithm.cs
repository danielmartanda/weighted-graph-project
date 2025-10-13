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
 - We used this algorithm because all edge weights (travel times) are non-negative, 
   and it guarantees the optimal shortest path from a source to a destination. 
-----------------------------------------
- Calculates the shortest path between any two locations (nodes) on the map (graph)
- Works with the Graph class (directed and weighted adjacency list)
- Utilizes a queue-based approach to determine the shortest path
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
        //This method calculates and prints the shortest path between two nodes using Dijkstra's Algorithm
        //Validates that both source and destination exist in the graph
        public static void DijkstraShortestPath(Graph graph, string source, string target)
        {
            //This checks if both start and end nodes exist within the graph
            if (!graph.ContainsNode(source) || !graph.ContainsNode(target))
            {
                throw new ArgumentException("Error: One or both nodes do not exist in the graph");
            }

            //VARIABLES
            //This stores the shortest known distance from the source to each node
            Dictionary<string, int> distance = new Dictionary<string, int>();
            //This stores the previous node used for path construction, allows null strings
            Dictionary<string, string?> previous = new Dictionary<string, string?>();
            //This stores the unvisited nodes to be processed later
            Queue<string> unvisitedQueue = new Queue<string>();

            //Initializes all distances to infinity and previous to null
            //Enqueues every node into the unvisitedQueue
            foreach (var node in graph.GetAllNodes())
            {
                distance[node] = int.MaxValue;      //Initial unknown distance
                previous[node] = null;              //No predecessors
                unvisitedQueue.Enqueue(node);       //Adds all node to the queue
            }

            //Set's the starting nodes distance to zero
            distance[source] = 0;

            //Main loop which runs until all nodes are visited or target is reached
            while (unvisitedQueue.Count > 0)
            {
                //This selected the unvisited node with the smallest known distance
                string current = null;
                int minDistance = int.MaxValue;

                //Loop through all unvisited nodes to find the current closest node
                foreach (var node in unvisitedQueue)
                {
                    //This checks if the node is unvisited and has a smaller distance than the current minimum
                    if (distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        current = node;
                    }
                }

                //If no such node is found, then all reachable nodes have been processed and we exit
                if (current == null)
                {
                    break;
                }

                //This creates a temporary queue to rebuild the unvisited list
                //  - A node is considered visited when it is removed from unvisitedQueue
                Queue<string> tempQueue = new Queue<string>();

                //Rebuilds the queue without the current node
                //  - All other nodes stay in the unvisitedQueue
                while (unvisitedQueue.Count > 0)
                {
                    string node = unvisitedQueue.Dequeue();
                    if (node != current)
                    {
                        tempQueue.Enqueue(node);
                    }
                }

                //Updates unvisitedQueue to reflect the removal of the current node
                unvisitedQueue = tempQueue;

                //If the target node has been reached, we stop scanning further
                if (current == target)
                {
                    break;
                }

                //Checks all neighbour nodes connected to the current node
                foreach (var (neighbour, weight) in graph.GetNeighbours(current))
                {
                    //Calculates potential new distance from source to neighbour from current
                    int alternativeDistance = distance[current] + weight;

                    //If this route is shorter, update the distance and record the path
                    if (alternativeDistance < distance[neighbour])
                    {
                        distance[neighbour] = alternativeDistance;      //Updates shortest distance
                        previous[neighbour] = current;                  //Tracks the previous for path construction
                    }
                }
            }

            //If no path exists between source and target, throws error
            if (distance[target] == int.MaxValue)
            {
                throw new Exception($"No path found from {source} to {target}");
            }

            //This constructs the path starting from the target node
            string pathOutput = target;         //Holds the final path as formatted string
            string? stepNode = target;          //Pointer to trace each previous node

            //This loops backwards using previous until we reach the source
            while (previous[stepNode] != null)
            {
                stepNode = previous[stepNode];      //Moves one step backwards to previous node
                pathOutput = stepNode + " -> " + pathOutput;
            }

            //Labelled output
            Console.WriteLine();
            Console.WriteLine($"Source: {source}");
            Console.WriteLine($"Target: {target}");
            Console.WriteLine($"Path: {pathOutput}");
            Console.WriteLine($"Total Travel Time: {distance[target]} minutes");
            Console.WriteLine();
        }

    }
}

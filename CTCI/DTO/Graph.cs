using System.Collections.Generic;
using System;

namespace CTCI.DTO
{
    public class Graph
    {
        public int V;
        public LinkedList<int>[] adj;
        public Graph(int v){
            V=v;
            adj = new LinkedList<int>[V];
            for(int i = 0; i<V; i++){
                adj[i] = new LinkedList<int>();
            }   
        }
        public void AddEdge(int u , int v)
        {
            adj[u].AddLast(v);
            adj[v].AddLast(u);
        }

        public void PrintGraph()
        {
            for (int i = 0; i < adj.Length; i++){
                Console.WriteLine("\nAdjacency list of vertex " + i);
                Console.Write("head");

                foreach (var item in adj[i])
                {
                    Console.Write(" -> " + item);
                }
                Console.WriteLine();
            }
        }

        public void BFS(int s){
            Queue<int> q = new Queue<int>();
            bool[] visited = new bool[V];
            for(int i = 0; i< V; i++){
                visited[i] = false;
            }
            q.Enqueue(s);
            while(q.Count != 0){
                int v = q.Dequeue();
                foreach(int u in adj[v]){
                    if(!visited[u]){
                        q.Enqueue(u);
                        visited[u] = true;
                    }
                }
            }
        }

        public void BFSUseful(int s){
            Dictionary<int, int> level = new Dictionary<int, int>();
            level[s]=0;
            Dictionary<int, int> parent = new Dictionary<int, int>();
            parent[s]=-1;

            // first level is 1
            int i = 1;
            List<int> frontier = new List<int>(s);

            while(frontier.Count == 0){
                List<int> next = new List<int>();
                foreach(int u in frontier){
                    foreach(int v in adj[u]){
                        level[v]=i;
                        parent[v]=u;
                        next.Add(v);
                    }
                }
                frontier=next;
                i+=1;
            }

            // shortest path from s to v = level[v]
        }

        public void DFS(int s){
            bool[] visited = new bool[V];
            for(int i = 0; i< V; i++){
                visited[i] = false;
            }
            DFSUtil(s, visited);            
        }

        public void DFSUtil(int s, bool[] visited){
            visited[s] = true;
            foreach(int u in adj[s]){
                if(!visited[u]){
                    DFSUtil(u, visited);
                }
            }
        }

        public bool CycleDetection_DirectedGraph(int v){
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];

            for(int i = 0;i<V;i++){
                visited[i]=false;
                recStack[i]=false;
            }

            return CycleDetectionUtil_DirectedGraph(v, visited, recStack);
          
        }

        public bool CycleDetectionUtil_DirectedGraph(int v, bool[] visited, bool[] recStack)
        {
            if(!visited[v]) return false;
            if(recStack[v]) return true;

            visited[v]=true;
            recStack[v] = true;

            foreach(int u in adj[v]){
                if(CycleDetectionUtil_DirectedGraph(u, visited, recStack))
                    return true;
            }
            recStack[v]=false;
            return false;
        }

        public bool CycleDetection_UndirectedGraph(int v){
            // 1--0
            // | /
            // 2/
            // the above graph has a cycle if 2 has a parent of 1 and a parent of 0
            // 2 cannot have 0 visited and 2's parent != 0(current node)
            bool[] visited = new bool[V];

            for(int i = 0;i<V;i++){
                visited[i]=false;
            }

            return CycleDetectionUtil_UndirectedGraph(v, visited, -1);
        }

        public bool CycleDetectionUtil_UndirectedGraph(int v, bool[] visited, int parent){
            visited[v] = true;
            foreach(int u in adj[v]){
                if(!visited[u]){
                    CycleDetectionUtil_UndirectedGraph(u, visited, v);
                }
                if(visited[u] && u!=parent){
                    return false;
                }
            }
            return true;
        }
        
        public void TopologicalsSort(int v){
            // Given directed acyclic graph, order vertices so that all edges point from lower order to higher order
            // Run DFS output the reverse of finishing time of vertices
            // for a graph (e=(u,v))
            // visit v before u finish (can have a cycle)
            // v finish before visit u (graph is acyclic - no cycle)
            Stack<int> st = new Stack<int>();
            bool[] visited = new bool[V];
            for(int i =0;i<V;i++){
                TopologicalsSortUtil(v, visited, st);
            }

            while(st.Count!=0){
                Console.Write(st.Pop() + " ");
            }
        }

        public void TopologicalsSortUtil(int v, bool[] visited, Stack<int> st)
        {
            visited[v] = true;
            foreach(int u in adj[v]){
                if(!visited[u]){
                    TopologicalsSortUtil(u, visited, st);
                }
            }
            st.Push(v);
        }

        public void PathFinding(int start, int end){
            Stack<int> st = new Stack<int>();
            bool[] visited = new bool[V];
            for(int i = 0; i<V;i++)
            {
                visited[i] = true;
            }

            PathFindingUtil(start, end, visited, st);

            while(st.Count != 0){
                if(st.Count == 1){
                    Console.Write(st.Pop());          
                }
                else{
                    Console.Write(st.Pop() + " -> ");
                }
            }
        }

        public void PathFindingUtil(int start, int end, bool[] visited, Stack<int> st)
        {
            if(start == end) return;
            visited[start]=true;
            foreach(int u in adj[start]){
                if(!visited[u]){
                    st.Push(u);
                    PathFindingUtil(u, end, visited, st);
                }
            }
        }

        public bool IsBiparite(int v){
            string[] color = new string[v];
            bool[] visited = new bool[V];
            color[v]="BLACK";
            return IsBipariteUtil(v, visited, color);
        }

        public bool IsBipariteUtil(int v, bool[] visited, string[] color)
        {
            visited[v] = true;            
            foreach(int u in adj[v]){
                if(!visited[u]){
                    // EITHER WHITE/BLACK on opposite vertex
                    if(color[u]!= null && color[v] != null && color[u] == color[v]) return false;
                    if(color[v] == "BLACK") color[u]="WHITE";
                    if(color[v] == "WHITE") color[u]="BLACK";

                    IsBipariteUtil(u, visited, color);
                }
            }

            return true;
        }

        // Find strongly connected components
        // A directed graph is called strongly connected if there is a path from each vertex in the graph to every other vertex.

    }
}
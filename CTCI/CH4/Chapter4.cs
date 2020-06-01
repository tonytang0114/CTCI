using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using CTCI.BT;
using CTCI.DTO;

namespace CTCI.CH4
{
    public class Chapter4{
        // Qn1: Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
        public bool RouteBetweenNodes(Graph g, int start, int end)
        {
            // Use DFS to find if end is visited or not.
            bool[] visited = new bool[g.V];
            return DFSUtil(g, start, end, visited);

        }

        public bool DFSUtil(Graph g, int start, int end, bool[] visited)
        {
            if(start == end) return true;

            visited[start] = true; 

            foreach(int u in g.adj[start])
            {
                if(!visited[u])
                {
                    DFSUtil(g, u, end, visited);
                }
            }

            return false;
        }

        // Qn2 Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search
        // tree with minimal height

        public TreeNode CreateMinimalBST(int[] arr)
        {
            return CreateMinimalBST(arr, 0, arr.Length-1);
        }

        public TreeNode CreateMinimalBST(int[] arr, int start, int end){
            if(start < end){
                return null;
            }

            int mid = (start+end) / 2;
            TreeNode n = new TreeNode(arr[mid]);
            n.left = CreateMinimalBST(arr, start, mid-1);
            n.right = CreateMinimalBST(arr, mid+1, end);
            return n;
        }

        // Qn3: Given a binary tree, design an algorithm which creates a linked list of all the nodes at each depth
        // (e.g. if you have a tree with depth D, you will have D linked lists)
        public List<LinkedList<TreeNode>> ListOfDepths(TreeNode root)
        {
            int level = 0;
            List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
            ListOfDepthsRecur(root, lists, level);
            return lists;
        }

        public void ListOfDepthsRecur(TreeNode root, List<LinkedList<TreeNode>> lists, int level)
        {
            if(root == null) return;
            LinkedList<TreeNode> list = null;
            if(lists.Count == level){
                lists.Add(list);
            }else{  
                list = lists[level];
            }

            list.AddLast(root);
            ListOfDepthsRecur(root.left, lists, level+1);
            ListOfDepthsRecur(root.right, lists, level+1);
        }

        // Qn5 Implement a function to check if a binary tree is balanced. For the purpose of the question
        // A balanced tree is defined to be a tree such tat the heights of the two subtrees of any node never differ
        // by more than one

        public bool CheckBalanced(TreeNode root){
            // foreach node check the height (if heightDiff > 1 return false)
            // if root==null (return true) as the false checks are finished
            if(root == null ) return true;
            int heightDiff = Math.Abs(getHeight(root.left) - getHeight(root.right));

            if(heightDiff > 1) 
                return false;

            return CheckBalanced(root.left) && CheckBalanced(root.right);

        }

        public int getHeight(TreeNode root){
            if(root == null) return 0;
            return Math.Max(getHeight(root.left)+1, getHeight(root.right)+1);
        }

        // Qn5: Implement a function to check if a binary tree is a binary search tree
        public bool ValidateBST(TreeNode root)
        {
            // Four way (in-order traversal / min-max(1) / min-max(2) / stacks)
            TreeNode last = null;
            return ValidateBSTRecur(root, last);
        }

        public bool ValidateBSTRecur(TreeNode root, TreeNode last){
            if(root == null) return true;

            if(!ValidateBSTRecur(root.left, last)) return false;
            if(last!=null && root.data<last.data) return false;
            last=root;
            return ValidateBSTRecur(root.right, last);          
        }

        public bool ValidateBST2(TreeNode root){
            return ValidateBSTRecur2(root, Int32.MinValue, Int32.MaxValue);
        }

        public bool ValidateBSTRecur2(TreeNode root, int min, int max)
        {
            if(root == null)  return true;
            if(root.data < min) return false;
            if(root.data > max) return false;
            return ValidateBSTRecur2(root.left, min, root.data) && ValidateBSTRecur2(root.right, root.data, max);
        }

        // Qn6 Successor


        // Qn7: You are given a list of projects and a list of dependencies(which is a list of pairs of projects)
        // where the second proeject is dependent on the first project. All of a project's dependencies must be built
        // before the project is. Find as build order that will allow the project to be built. If the project is no valid build order
        // return an error.
        // Solution: basically use a topological sort (DFS and get the reverse list of values using stacks and print the order)

        // Qn8: Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree.
        // Avoid storing additional nodes in a data structure. NOTE: this is not necessarily a binary search tree.

        public TreeNode CommonAncestor(TreeNode n1, TreeNode n2)
        {
            // by using parent property
            // find the difference of depth in each node

            int diff = depth(n1) - depth(n2);
            if(diff>0) {
                n1 = goesUp(n1, diff);
            }else{
                n2 = goesUp(n2, diff);
            }          

            while(n1!=null && n2!=null){
                TreeNode p1 = n1.parent;
                TreeNode p2 = n2.parent;

                if(p1 == p2) return p1;
                n1 = n1.parent;
                n2 = n2.parent;
            }

            return null;

        }

        public TreeNode goesUp(TreeNode node, int diff){
            while(diff >0 && node!=null){
                node = node.parent;
                diff--;
            }

            return node;
        }

        public int depth(TreeNode node){
            int depth = 0;
            while (node!=null) {
                node = node.parent;
                depth++;
            }
            return depth;
        }

        // Generate BST Sequences
        public List<TreeNode> BSTSequence(int n) {
            if (n == 0) return new List<TreeNode>();
            return generateTrees(1, n);
        }
        public List<TreeNode> generateTrees(int l, int r){
            List<TreeNode> ans = new List<TreeNode>();
            if(l > r){
                ans.Add(null);
                return ans;
            }

            for(int i =l; i<= r; i++){
                foreach(TreeNode left in generateTrees(l, i-1)){
                    foreach(TreeNode right in generateTrees(i+1, r)){
                        TreeNode root = new TreeNode(i);
                        root.left = left;
                        root.right = right;
                        ans.Add(root);
                    }
                }
            }

            return ans;
        }

        // Qn10: T1 and T2 are two very large bianry trees, with T1 much bigger than T2. Create an algorithm
        // to determine if T2 is a subtree of T1
        public bool CheckSubTree(TreeNode t1, TreeNode t2)
        {
            // Brute force
            // for each node in t1, Check IsSameTree(t2) return true/false
            if(t1 == null) return false;
            if(IsSameTree(t1,t2)) return true;
            return CheckSubTree(t1.left, t2) || CheckSubTree(t1.right, t2);

        }

        public bool CheckSubTree2(TreeNode t1, TreeNode t2){
            // Traverse until t1.data == t2.data and check if t2 is subtree of t1
            if(t1==null) return false;
            if(t1.data == t2.data) {
                return IsSameTree(t1,t2);
            }
            return CheckSubTree(t1.left, t2) || CheckSubTree(t1.right, t2);
        }


        public bool IsSameTree(TreeNode t1, TreeNode t2){
            if(t1==null && t2==null){
                return true;
            }else if(t1!=null && t2!=null){
                return (t1.data == t2.data && IsSameTree(t1.left,t2.left) && IsSameTree(t1.right, t2.right));
            }else{
                return false;
            }
        }

        // Qn11: You are implementing a binary tree class from scratch which, in addition insert, find and delete.
        // has a method getRanndom node from the tree. All nodes should be equally likely to be chosen
        // Design an algorithm from getRandomNote and explain how you would implement the rest of methods.
        

        // Qn12: You have given a binary tree in which each node contains an integer value (which might be positive or negative)
        // Design an algorithm to count the number of paths that sum to a given value. The path does not need to start or end at the
        // roof or a leaf, but it must go downwards (travelling only form parent nodes to child nodes)
        public int PathsWithSum(TreeNode root){
            
        }
        
    }



}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CTCI.BT
{
    public class TreeNode{
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;
        public int data;

        public TreeNode(int data){
            this.data = data;
            left = right = null;
        }
    }

    public class BinarySearchTree{
        TreeNode root;

        BinarySearchTree(int key){
            root = new TreeNode(key);
        }

        BinarySearchTree(){
            root = null;
        }

        public bool Search(TreeNode node, int target){
            if(node.data == target){
                return true;
            }

            if(node.data <= target){
                return Search(node.left, target);
            }else{
                return Search(node.right, target);
            }
        }

        public TreeNode Insert(TreeNode node, int data){
            if(node == null){
                return new TreeNode(data);
            }

            if(node.data <= data){
                node.left = Insert(node.left, data);
            }else{
                node.right = Insert(node.right, data );
            }

            // return the unchanged node pointer
            return node;
        }



        // Binary Tree problems

        public TreeNode build123_1(int rootData, int leftData, int rightData){
            TreeNode root = new TreeNode(rootData);
            TreeNode leftChild = new TreeNode(leftData);
            TreeNode rightChild = new TreeNode(rightData);

            root.left = leftChild;
            root.right = rightChild;

            return root;
        }
        public TreeNode build123_2(int rootData, int leftData, int rightData){
            TreeNode root = new TreeNode(rootData);
            root.left  = new TreeNode(leftData);
            root.right  = new TreeNode(rightData);
            return root;
        }

        public TreeNode build123_3(int rootData, int leftData, int rightData){
            TreeNode root = null;
            root = Insert(root, rootData);
            root = Insert(root, leftData);
            return Insert(root, rightData);
        }

        public int Size(TreeNode root){
            if(root == null){
                return 0;
            }

            return Size(root.left)  + Size(root.right) + 1;
        }

        public int maxDepth(TreeNode root){
            if(root == null){
                return 0;
            }

            return Math.Max(Size(root.left)+1, Size(root.right)+1);
        }
        
        public int MinValueBST(TreeNode root){
            while(root.left != null){
                root = root.left;
            }

            return root.data;
        }

        public void PrintTree(TreeNode root){
            if(root == null){
                return;
            }
            PrintTree(root.left);
            Console.Write(root.data + ",");
            PrintTree(root.right);
        }

        public void PrintPostOrder(TreeNode root){
            if(root == null){
                return;
            }
            PrintTree(root.left);
            PrintTree(root.right);
            Console.Write(root.data + ",");
        }

        public bool HasPathSum(TreeNode root, int sum){
            if(root.left == null && root.right == null){
                if((sum - root.data) == 0){
                    return true;
                }
            }

            return HasPathSum(root.left, sum-root.data) || HasPathSum(root.right, sum-root.data);
        }

        public void PrintPath(TreeNode node){
            int[] path = new int[1000];
            PrintPathsRecur(node, path, 0);
        }

        public void PrintPathsRecur(TreeNode node, int[] path, int pathLen)
        {
            if (node == null)
                return;
            
            path[pathLen] = node.data;
            pathLen++;

            // it's a leaf, so print the path that led to here
            if (node.left==null && node.right==null) {
                PrintArray(path, pathLen);
            }
            else {
            // otherwise try both subtrees
                PrintPathsRecur(node.left, path, pathLen);
                PrintPathsRecur(node.right, path, pathLen);
            }
        }

        public void PrintArray(int[] path, int pathLen){
            for(int i = 0; i<pathLen; i++){
                Console.Write(path[i] + " ");
            }
            Console.WriteLine();
        }

        public void Mirror(TreeNode node){
            if(node==null){
                return;
            }

            Mirror(node.left);
            Mirror(node.right);

            //swap node
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;             
        }

        public void Mirror2(TreeNode node){
            if(root == null)
                return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);

            while(q.Count != 0){
                TreeNode cur = q.Dequeue();

                TreeNode temp = cur.left;
                cur.left = cur.right;
                cur.right = temp;  

                if(cur.left!=null){
                    q.Enqueue(cur.left);
                }
                
                if(cur.left!=null){
                    q.Enqueue(cur.right);
                }

            }
        }

        public TreeNode Mirror3(TreeNode node){
            if(node == null){
                return null;
            }else{
                TreeNode newNode = new TreeNode(node.data);
                Mirror3(node.left);
                Mirror3(node.right);
                return node;
            }
        }

        public void doubleTree(TreeNode node){
            if(root==null){
                return;
            }
            doubleTree(node.left);
            if(node.left!=null) {
                TreeNode newNode = new TreeNode(node.data);
                newNode.left = node.left;
                node.left = newNode;
            }else{
                node.left = new TreeNode(node.data);
            }
            doubleTree(node.right);
        }

        public bool SameTree(TreeNode n1, TreeNode n2){

            if(n1 == null && n2==null){
                return true;
            }else if(n1!=null && n2!=null){
                return (n1.data == n2.data && SameTree(n1.left,n2.left) && SameTree(n1.right,n2.right));
            }else{
                return false;
            }          
        }

        public int CountTrees(int numKeys){
            // keys mean the treeNode
            // CountTrees(0) = 1
            // CountTrees(1) = 1
            // CountTrees(2) = 2
            // CountTrees(3) = 5
            // CountTrees(4) = 14

            // formula: CountTrees(3) = 2*(CountTrees(0)) + CountTrees(1) + CountTrees(0)*2
            
            if(numKeys <= 1){
                return 1;
            }else{
                int sum = 0;
                int left, right, root;

                for(root = 1; root<=numKeys; root++){
                    left = CountTrees(root-1);
                    right = CountTrees(numKeys - root);

                    sum += left*right;
                }
                return sum;
            }
        }


        public bool isBST(TreeNode root, TreeNode last){
            // Inorder traversal
            if(root == null)
                return true;
            if(!isBST(root.left,last)) return false;
            if(last!=null && root.data <= last.data) return false;
            last=root;
            return isBST(root.right, last);
        }

        public bool isBST2(TreeNode node){
            if(node == null) return true;

            if(node.left != null && MaxValue(node.left) > node.data){
                return false;
            }

            if(node.right!= null && MinValue(node.right) <= node.data){
                return false;
            }

            if(!isBST2(node.left) || !isBST2(node.right)){
                return false;
            }
            return true;
        }

        public bool isBST3(TreeNode root){
            return isBSTRecur(root, int.MinValue, int.MaxValue);
        }

        public bool isBSTRecur(TreeNode root, int min, int max){
            if(root == null)
                return true;
            if(root.data < min || root.data > max){
                return false;
            }

            return isBSTRecur(root.left, min, root.data) && isBSTRecur(root.right, root.data, max);
        }

        public bool isBST4(TreeNode root, int max){
            Stack<int> st = new Stack<int>();
            while(root!= null || st.Count!=0){
                while(root!=null){
                    st.Push(root.data);
                    root = root.left;
                }

                int temp = st.Pop();
                if(temp > max) return false;
                max = temp;
                root = root.right;
            }
        }

        public int MaxValue(TreeNode node){
            if(node==null)
                return int.MinValue;
            
            int res = node.data;
            int lres = MaxValue(node.left);
            int rres = MaxValue(node.right);

            if (lres > res) 
            { 
                res = lres; 
            } 
            if (rres > res) 
            { 
                res = rres; 
            } 
            return res;             
        }

        public int MinValue(TreeNode node){
            if(node==null)
                return int.MaxValue;
            
            int res = node.data;
            int lres = MinValue(node.left);
            int rres = MinValue(node.right);

            if (lres < res) 
            { 
                res = lres; 
            } 
            if (rres < res) 
            { 
                res = rres; 
            } 
            return res;                         
        }








    }

    public class BinaryTree{
        
        TreeNode root;

        BinaryTree(int key){
            root = new TreeNode(key);
        }

        BinaryTree(){
            root = null;
        }

        public void InOrderTraversal(TreeNode temp){
            if(temp == null)
                return;
            InOrderTraversal(temp.left);
            Console.WriteLine(temp.data);
            InOrderTraversal(temp.right);

        }


        public void Insert(TreeNode temp, int key){
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(temp);

            while(q.Count != 0){
                TreeNode node = q.Dequeue();
                if(node.left != null){
                    q.Enqueue(node.left);
                }
                else{
                    node.left = new TreeNode(key);
                    break;
                }

                if(node.right != null){
                    q.Enqueue(node.right);
                }
                else{
                    node.right = new TreeNode(key);
                    break;
                }
            }
        }




    }
}
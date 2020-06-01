using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.CH2
{
    public class Node{
        public Node next;
        public int data;

        public Node(int data){
            this.data = data;
            next = null;
        }
    }
    public class Chapter2
    {
        // Qn1: Write code to remove duplicate from an unsorted list
        public void RemoveDups1(Node head){
            // using two pointers i,j where j = i+1 in perspect of while loop
            Node ptr1 = head;
            while(ptr1 != null && ptr1.next != null){
                Node ptr2 = ptr1;
                while(ptr2.next != null){
                    if(ptr1.data == ptr2.next.data){
                        ptr2.next = ptr2.next.next;
                    }
                    ptr2 = ptr2.next;
                }
                ptr1=ptr1.next;
            }
        }

        public void RemoveDups2(Node head){
            // using hashmap to store duplicate value
            HashSet<int> hs = new HashSet<int>();
            while(head.next != null){
                if(!hs.Contains(head.data)){
                    hs.Add(head.data);
                }else{
                    head = head.next;
                    hs.Remove(head.data);
                }
                head = head.next;
            }
        }

        // Qn2: Implement an algorithm to find the kth to last element of a singly linked list
        public Node ReturnKthToLast(Node head, int k){
            int count = 1;
            while(head.next != null){
                if(count == k){
                    return head;
                }
                head = head.next;
                count++;
            }
            return null;
        }

        // Qn3: Implement an algorithm to delete a node in the middle (i.e. any node but the first and last node)
        // not necessarily the exact middle of a singly linked list, given only access to that node.
        public bool DeleteMiddleNode(Node target){
            if(target == null && target.next == null){
                return false;
            }

            int temp = target.next.data;
            target.data = temp;
            target.next = target.next.next;
            return true;
        }

        // Qn4: Write code to partition a linked list around a value x, such that all nodes less than x come
        // before all nodes greater thhan or equal to x. If x is contained within the list, the values of x only need
        // to be after the elements less than x (see below). The partition element x can appear anywhere in 
        // the right partition. It does not need to appear between the left and right partitions
        public Node Partition(Node head, int partition){
            Node left = null;
            Node right = null;
            while(head.next != null){
                if(partition > head.data){
                    if(left == null){
                        left = new Node(head.data);
                    }
                    else{
                        left.next = new Node(head.data);
                    }
                    left = left.next;
                }
                else{
                    if(right == null){
                        right = new Node(right.data);
                    }
                    else{
                        right.next = new Node(right.data);
                    }
                    right = right.next;
                }
                head = head.next;
            }

            if(left==null && right == null)
                return null;
            if(left==null && right != null)
                return left;
            if(left!=null && right == null)
                return right;
            left.next = right;
            return left;
        }

        // Qn5: Sum Lists You have two numbers represented by a linked list, which each node contains a single digit. 
        // The digits are stored in reverse order, such that the 1's digit is at the head of the list. Write a function that
        // adds the two numbers and return the sum as a linked list.
        public Node SumLists(Node a, Node b, int carry){
            if(a == null && b == null && carry == 0){
                return null;
            }

            Node result = new Node(0);
            int value = carry;

            if (a != null){
                value += a.data;
            }

            if (b != null){
                value += b.data;
            }

            result.data = value % 10;

            if(a!= null && b != null){
                Node more = SumLists(a==null? null : a.next, b==null ? null : b.next, value>=10 ? 1: 0);
                result.next = more;
            }

            return result;
        }

        // Follow up (will do 25/5 night)
        // Qn6: Implement a function to check if a linked list is palindrome
        public bool Palindrome(Node head){
            if(head == null){
                return false;
            }
            // Reverse the linked list
            Node prev = null, cur = head, next = null; 

            while(cur.next != null){
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }
            
            Node ptr = prev;

            // Compare to original linkedlist
            while(head.next!= null){
                if(ptr.data != head.data){
                    return false;
                }
                head = head.next;
                ptr = ptr.next;
            }
            return true;
        }

        public bool Palindrome1(Node head){
            // Find the middle point of the linkedlist by runner runner technique
            // the second pointer run twice as fast as the first pointer and slow pointer will be in the middle when fast pointer end
            Stack<int> st = new Stack<int>();
            Node slow = head;
            Node fast = head.next;
            while(slow!=null && fast!=null && fast.next!=null){
                st.Push(slow.data);
                slow = slow.next;
                fast = fast.next.next;
            }

            // has odd number of elements and skip the middle element
            if(fast != null){
                slow = slow.next;
            }

            while(slow!=null){
                int top = st.Pop();
                if(top!=slow.data){
                    return false;
                }
                slow = slow.next;
            }

            return true;        
        }

        // Qn7: Given two linked lists, determine if the two lists intersect. Return the intersecting node.
        // Note that the intersection is defined based on reference, not value. That is, if the 
        // kth node of the first linked list is the exact same node (by reference) as the jth node of the second linked list
        // then they are intersecting
        public Node Intersect(Node l1, Node l2){
            HashSet<Node> hs = new HashSet<Node>();
            while(l1.next != null){
                if(!hs.Contains(l1)){
                    hs.Add(l1);
                }
            }

            while(l2.next != null){
                if(hs.Contains(l2)){
                    return l2;
                }
            }

            return null;
        }

        public Node Intersect2(Node l1, Node l2){
            if(l1==null && l2==null)
                return null;
            
             var diff = GetDiff(l1, l2);

            if(diff > 0){
                l1 = l1.next;
                diff--;
            }else{
                while(diff < 0){
                    l2 = l2.next;
                    diff++;
                }
            }

            while(l1 !=null){
                if(l1 == l2){
                    return l1;
                }    
                l1 = l1.next;
                l2 = l2.next;
            }
            return null;
        }

        public int GetDiff(Node l1, Node l2){
            var aLength = 0;
            var bLength = 0;

            while(l1 != null ){
                aLength++;
                l1 = l1.next;
            }
            while(l2 != null ){
                bLength++;
                l2 = l2.next;
            }

            return aLength - bLength;
        }


        // Qn8: Given a circular linked list, implement an algorithm that returns the node at the beginning of the loop
        public Node LoopDetection(Node head){
            // Use runner runner technique to find the loop 
            Node slow = head;
            Node fast = head.next;

            while(slow!=null && fast!=null && fast.next!=null){
                if(slow == fast){
                    return slow;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return null;
        }

        

        public void PrintLinkedList(Node head){
            while(head!=null) {
                if(head.next==null){
                    Console.Write($"{head.data}");
                    break;
                }
                else{
                    Console.Write($"{head.data} -> ");
                }
                head = head.next;
            }
        }


    }
}

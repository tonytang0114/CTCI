using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CTCI.CH3
{
    public class ThreeStacks{
        private const int numOfStacks = 3;
        private int capacity;
        private int[] sizes;
        private int[] values;

        public ThreeStacks(int capacity){
            this.capacity = capacity;
            sizes = new int[numOfStacks];
            values = new int[numOfStacks * capacity];
        }

        public void Push(int stackNum, int data){
            if(IsFull(stackNum)){
                throw new Exception("Stack is full exception");
            }
            sizes[stackNum]++;
            values[indexOfTop(stackNum)] = data;
            
        }

        public int pop(int stackNum) {
            if(isEmpty(stackNum)) {
                throw new Exception("Empty stack exception");
            }
            
            int topIndex = indexOfTop(stackNum);
            int value = values[topIndex]; // Get top
            values[topIndex] = 0; // Clear 
            sizes[stackNum]--; // Shrink
            return value;
        }

        

        /* Returns index of the top of the stack. */
        private int indexOfTop(int stackNum) {
            int offset = stackNum * capacity;
            int size = sizes[stackNum];
            return offset + size - 1;
        }	

        public bool IsFull(int stackNum){
            return sizes[stackNum] == capacity;
            }
        public bool isEmpty(int stackNum) {
            return sizes[stackNum] == 0;
        }
    }

    public class StackMin{
        private int capacity;

        private int[] stackArr;

        private int[] minStack;

        private int top = 0;

        public StackMin(int capacity){
            this.capacity = capacity;
            stackArr = new int[capacity];
            minStack = new int[capacity];
        }

        public void Push(int data){
            // push to datastack as normal push to minstack as normal;
            if(top == capacity){
                throw new Exception("Stack full exception");
            }

            if(top == 0){
                stackArr[top] = data;
                minStack[top] = data;
            }
            else{
                stackArr[top] = data;
                if(minStack[top-1] > data){
                    minStack[top] = data;
                }else{
                    minStack[top] = minStack[top-1];
                }
            }
            top++;
        }

        public int Pop(){
            // Pop the stack array and minstack arr
            if(top == 0){
                throw new Exception("Stack is empty");
            }
            return stackArr[top--];
        }

        public int Min(){
            return minStack[top];
        }
    }

    public class SetsOfStacks{

        private int capacity;
        List<Stack<int>> stacks = new List<Stack<int>>();
        
        public SetsOfStacks(int capacity){
            this.capacity = capacity;
        }

        public Stack<int> getLastStack(){
            if(stacks.Count == 0) return null;
            return stacks[stacks.Count-1];
        }

        public void Push(int data){
            Stack<int> last = getLastStack();
            if (last != null && last.Count!=capacity){
                last.Push(data);
            }else{
                // create new stack
                Stack<int> stack = new Stack<int>(capacity);
                stack.Push(data);
                stacks.Add(stack);
            }
        }

        public int Pop(){
            Stack<int> last = getLastStack();
            if (last == null)
                throw new Exception("Empty Stack");
            int v = last.Pop();
            if (last.Count == 0){
                stacks.RemoveAt(stacks.Count -1);          
            }
            return v;
        }
    }
    public class Chapter3
    {   
        // Qn1: Implement three stacks in array
        // Above

        // Qn2: How would you design a stack which, in addition to push and pop, has a function min which returns the minimum element
        // Push, pop, min still operate in O(1) time

        // Qn3: Imagine a literal stack of plates. If the stack gets too high. It may topple. 
        // Therefore in real life, we would likely to start a new stack when the previous stack exceeds some threshold
        // Implement a data structure SetsOfStacks that mimics this. (push, pop peek, isempty...)
        
        // Example ArrayList--



       

    }
}

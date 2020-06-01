using System;
using System.Collections.Generic;

namespace CTCI.BH {
    public class BinaryMinHeap {
        // Start with index 1
        public int parent(int i) => i/2;

        public int left(int i) => 2*i;

        public int right(int i) => 2*i+1;

        private int capacity;

        private int heap_size;

        private int[] heapArr;

        BinaryMinHeap(int capacity){
            this.capacity = capacity;
            // start with heap_size 1 for essential array shifting
            this.heap_size = 1;
            heapArr = new int[capacity];
        }

        public void MinHeapify(int i){
            int l =left(i);
            int r = right(i);

            int smallest = i;
            if(l < heap_size && heapArr[l] < heapArr[i]){
                smallest= l;
            }
            if(r < heap_size && heapArr[r] < heapArr[i]){
                smallest = r;
            }

            if (smallest!=i){
                int temp = heapArr[i];
                heapArr[i] = heapArr[smallest];
                heapArr[smallest] = temp;
                MinHeapify(smallest);                
            }
        }

        // to extract the root which is the minimum element
        public int ExtractMin() {
            if(heap_size == 1){
                return int.MaxValue;
            }
            if(heap_size == 2){
                heap_size--;
                return heapArr[1];
            }

            // Store the minimum value and remove it from heap
            int root = heapArr[1];
            heapArr[1] = heapArr[heap_size-1];
            heap_size--;
            MinHeapify(0);
            return root;
        }

        // Decreaases key value of key at index i to new val
        public void DecreaseKey(int i, int new_val){
            heapArr[i] = new_val;
            while(i != 0 && heapArr[parent(i)] > heapArr[i]){
                int temp = heapArr[parent(i)];
                heapArr[parent(i)] = heapArr[i];
                heapArr[i] = temp;
                i = parent(i);
            }
        }   

        public int getMin() => heapArr[0];

        public void DeleteKey(int i){
            if(heap_size == 1){
                throw new Exception("Cannot delete anymore");
            }

            DecreaseKey(i, Int32.MinValue);
            ExtractMin();
        }

        public void insertKey(int k) {
            if(heap_size == capacity){
                throw new Exception("Overflow");
            }

            heap_size++;
            int i = heap_size-1;
            heapArr[i]=k;

            // if parent of k > k, perform swapping 
            while(i!=0 && heapArr[parent(i)] > heapArr[i]){
                int temp = heapArr[parent(i)];
                heapArr[parent(i)] = heapArr[i];
                heapArr[i] = temp;
                i = parent(i);
            }
        
        }       
    }
}
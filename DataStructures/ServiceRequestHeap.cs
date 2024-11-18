using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{
    public class ServiceRequestHeap
    {
        
        private List<(ServiceRequest request, int dependencyCount)> heap = new List<(ServiceRequest request, int dependencyCount)>();

        
        public int Count => heap.Count;

        
        public ServiceRequestHeap()
        {
            heap = new List<(ServiceRequest, int)>();
        }

        
        public void Insert(ServiceRequest request, int dependencyCount)
        {
            heap.Add((request, dependencyCount));
            HeapifyUp(heap.Count - 1);
        }

        
        public (ServiceRequest request, int dependencyCount) ExtractMax()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            var max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return max;
        }

        
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].dependencyCount <= heap[parentIndex].dependencyCount)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        
        private void HeapifyDown(int index)
        {
            while (index < heap.Count)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int largestIndex = index;

                if (leftChildIndex < heap.Count && heap[leftChildIndex].dependencyCount > heap[largestIndex].dependencyCount)
                {
                    largestIndex = leftChildIndex;
                }

                if (rightChildIndex < heap.Count && heap[rightChildIndex].dependencyCount > heap[largestIndex].dependencyCount)
                {
                    largestIndex = rightChildIndex;
                }

                if (largestIndex == index)
                    break;

                Swap(index, largestIndex);
                index = largestIndex;
            }
        }

        
        private void Swap(int index1, int index2)
        {
            var temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{
    public class AVLTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private AVLTreeNode<TKey, TValue> root;

        // Public method to insert a key-value pair
        public void Insert(TKey key, TValue value)
        {
            root = Insert(root, key, value);
        }

        // Public method to search for a value by key
        public TValue Search(TKey key)
        {
            var node = Search(root, key);
            if (node == null)
                throw new KeyNotFoundException("Key not found in AVL Tree.");
            return node.Value;
        }

        // Public method to delete a node by key
        public void Delete(TKey key)
        {
            root = Delete(root, key);
        }

        // Recursive insert method with balancing
        private AVLTreeNode<TKey, TValue> Insert(AVLTreeNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null)
                return new AVLTreeNode<TKey, TValue>(key, value);

            int compareResult = key.CompareTo(node.Key);
            if (compareResult < 0)
                node.Left = Insert(node.Left, key, value);
            else if (compareResult > 0)
                node.Right = Insert(node.Right, key, value);
            else
                throw new ArgumentException("Duplicate keys are not allowed in AVL tree");

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            return Balance(node, key);
        }

        // Recursive search method
        private AVLTreeNode<TKey, TValue> Search(AVLTreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null || key.CompareTo(node.Key) == 0)
                return node;

            if (key.CompareTo(node.Key) < 0)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);
        }

        // Recursive delete method with balancing
        private AVLTreeNode<TKey, TValue> Delete(AVLTreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null)
                return node;

            int compareResult = key.CompareTo(node.Key);
            if (compareResult < 0)
                node.Left = Delete(node.Left, key);
            else if (compareResult > 0)
                node.Right = Delete(node.Right, key);
            else
            {
                if ((node.Left == null) || (node.Right == null))
                {
                    AVLTreeNode<TKey, TValue> temp = node.Left ?? node.Right;

                    if (temp == null)
                        return null;
                    else
                        return temp;
                }
                else
                {
                    AVLTreeNode<TKey, TValue> temp = GetMinValueNode(node.Right);
                    node.Key = temp.Key;
                    node.Value = temp.Value;
                    node.Right = Delete(node.Right, temp.Key);
                }
            }

            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
            return Balance(node, key);
        }

        // Utility method to get the minimum value node (used in delete)
        private AVLTreeNode<TKey, TValue> GetMinValueNode(AVLTreeNode<TKey, TValue> node)
        {
            AVLTreeNode<TKey, TValue> current = node;
            while (current.Left != null)
                current = current.Left;

            return current;
        }

        // Balancing method
        private AVLTreeNode<TKey, TValue> Balance(AVLTreeNode<TKey, TValue> node, TKey key)
        {
            int balance = GetBalance(node);

            if (balance > 1 && key.CompareTo(node.Left.Key) < 0)
                return RotateRight(node);

            if (balance < -1 && key.CompareTo(node.Right.Key) > 0)
                return RotateLeft(node);

            if (balance > 1 && key.CompareTo(node.Left.Key) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && key.CompareTo(node.Right.Key) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private int GetHeight(AVLTreeNode<TKey, TValue> node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(AVLTreeNode<TKey, TValue> node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLTreeNode<TKey, TValue> RotateRight(AVLTreeNode<TKey, TValue> y)
        {
            AVLTreeNode<TKey, TValue> x = y.Left;
            AVLTreeNode<TKey, TValue> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLTreeNode<TKey, TValue> RotateLeft(AVLTreeNode<TKey, TValue> x)
        {
            AVLTreeNode<TKey, TValue> y = x.Right;
            AVLTreeNode<TKey, TValue> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }
    }

    public class AVLTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public AVLTreeNode<TKey, TValue> Left { get; set; }
        public AVLTreeNode<TKey, TValue> Right { get; set; }
        public int Height { get; set; }

        public AVLTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Height = 1;
        }
    }
}

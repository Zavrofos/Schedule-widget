﻿using System;
using System.Collections;
using System.Collections.Generic;
using Prototype.Scripts.avl_tree_c_sharp_master.Bitlush.AvlTree;

namespace Prototype.Scripts.Tree
{
    public class BinaryTree<TKey, TValue> where TKey : IComparable
    {
        private readonly AvlTree<TKey, TValue> _tree;

        public BinaryTree()
        {
            _tree = new AvlTree<TKey, TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            _tree.Insert(key, value);
        }

        public void Delete(TKey key)
        {
            _tree.Delete(key);
        }

        public List<TValue> GetValuesBetweenBoundaries(float minBoard, float maxBoard)
        {
            if (_tree.Root == null) return null;
            AvlNode<TKey, TValue> leftNode = GetLeftNode(minBoard);
            AvlNode<TKey, TValue> rightNode = GetRightNode(maxBoard);

            return GetValueBetweenNodes(leftNode, rightNode);
        }

        private List<TValue> GetValueBetweenNodes(AvlNode<TKey, TValue> leftNode, AvlNode<TKey, TValue> rightNode)
        {
            List<TValue> result = new List<TValue>();
            
            Stack<AvlNode<TKey, TValue>> stack = new Stack<AvlNode<TKey, TValue>>();
            stack.Push(leftNode);
            
            while (stack.Count > 0)
            {
                AvlNode<TKey, TValue> current = stack.Pop();
                
                if (current.Key.CompareTo(leftNode.Key) >= 0 && current.Key.CompareTo(rightNode.Key) <= 0)
                {
                    result.Add(current.Value);
                }
                
                if (current.Right != null && current.Key.CompareTo(rightNode.Key) < 0)
                {
                    stack.Push(current.Right);
                }
                
                if (current.Left != null && current.Key.CompareTo(leftNode.Key) > 0)
                {
                    stack.Push(current.Left);
                }
            }

            return result;
        }
        private AvlNode<TKey, TValue> GetRightNode(float maxBoard)
        {
            AvlNode<TKey, TValue> root = _tree.Root;
            
            if (root == null)
            {
                return null; 
            }

            AvlNode<TKey, TValue> result = null;

            while (root != null)
            {
                if (root.Key.Equals(maxBoard))
                {
                    result = root;
                    break;
                }
                
                if (root.Key.CompareTo(maxBoard) < 0)
                {
                    
                    root = root.Right;
                }
                else
                {
                    result = root;
                    root = root.Left;
                }
            }

            if (result == null)
            {
                // вернуть самую последнюю ноду 
            }

            return result;
        }
        private AvlNode<TKey, TValue> GetLeftNode(float minBoard)
        {
            AvlNode<TKey, TValue> root = _tree.Root;
            
            if (root == null)
            {
                return null; 
            }

            AvlNode<TKey, TValue> result = null;

            while (root != null)
            {
                if (root.Key.Equals(minBoard))
                {
                    result = root;
                    break;
                }
                
                if (root.Key.CompareTo(minBoard) > 0)
                {
                    
                    root = root.Left;
                }
                else
                {
                    result = root;
                    root = root.Right;
                }
            }
            
            if (result == null)
            {
                // вернуть самую первую ноду 
            }
            return result;
        }
    }
}
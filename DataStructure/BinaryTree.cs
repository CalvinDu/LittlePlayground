using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataStructure
{
    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbours = null;
        public Node() { }
        public Node(T data) : this(data, null) { }

        public Node(T data, NodeList<T> neighbours)
        {
            this.data = data;
            this.neighbours = neighbours;
        }

        public T Value
        {
            get =>data;
            set =>data = value;
        }

        protected NodeList<T> Neighbours
        {
            get => neighbours;
            set => neighbours = value;
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            foreach (var node in Items)
                if (node.Value.Equals(value))
                    return node;
            return null;
        }
    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = data;
            var children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            base.Neighbours = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbours is null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbours[0];
            }
            set
            {
                if (base.Neighbours is null)
                    base.Neighbours = new NodeList<T>(2);
                base.Neighbours[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbours is null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbours[1];
            }
            set
            {
                if (base.Neighbours is null)
                    base.Neighbours = new NodeList<T>(2);
                base.Neighbours[1] = value;   
            }
        }
    }
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        public BinaryTree()
        {
            root = null;
        }

        public virtual void Clear()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get => root;
            set => root = value;
        }
    }
}

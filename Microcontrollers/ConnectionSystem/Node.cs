using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microcontrollers.ConnectionSystem
{
    [Serializable]
    public class CompositeOutOfRangeException : Exception
    {
        public CompositeOutOfRangeException(string message) : base(message) { }
    }
    [Serializable]
    public class CompositeInvalidNumberException : Exception
    {
        public CompositeInvalidNumberException(string message) : base(message) { }
    }
    internal interface INode<t>
    {
        t value { get; set; }
        INode<t> ?connected_node { get; set; }
        SKColor color { get; set; }
        void Transfer();
    }

    internal class VideoNode : INode<SKCanvas>
    {
        public SKCanvas value { get; set; }
        public INode<SKCanvas>? connected_node { get; set; }
        public SKColor color { get; set; }

        public void Transfer()
        {
            if (connected_node != null)
            {
                connected_node.value = value;
            }
        }
    }

    internal class CompNode : INode<Composite>
    {
        public Composite value { get; set; }
        public INode<Composite> ?connected_node { get; set; }
        public SKColor color { get; set; }
        public void Transfer()
        {
            if (connected_node != null)
            {
                connected_node.value = value;
            }
        }
    }

    internal class OnOffNode : INode<bool>
    {
        public bool value { get; set; }
        public INode<bool> ?connected_node { get; set; }
        public SKColor color { get; set; }
        public void Transfer()
        {
            if (connected_node != null)
            {
                connected_node.value = value;
            }
        }
    }

    internal class NumberNode : INode<double>
    {
        public double value { get; set; }
        public INode<double> ?connected_node { get; set; }
        public SKColor color { get; set; }
        public void Transfer()
        {
            if (connected_node != null)
            {
                connected_node.value = value;
            }
        }
    }
}
using Microcontrollers.ControllerSystem;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microcontrollers.ConnectionSystem
{
    internal interface INode<t>
    {
        public int id { get; set; }
        bool IsOutput { get; set; }
        t value { get; set; }
        INode<t> ?connected_node { get; set; }
        SKColor color { get; set; }
        void Transfer();
    }

    internal class VideoNode : INode<SKBitmap>
    {
        public Size? screen_size_return { get; set; }
        public int id { get; set; }
        public SKBitmap value { get; set; }
        public INode<SKBitmap>? connected_node { get; set; }
        public SKColor color { get; set; }
        public bool IsOutput { get; set; }
        public VideoNode(bool is_output)
        {
            IsOutput = is_output;
            value = new SKBitmap();
        }
        public void Transfer()
        {
            if (connected_node != null && this.IsOutput)
            {
                connected_node.value = value;
            }
            else
            {
                if (connected_node != null)
                {
                    value = connected_node.value;
                }
            }
        }
    }

    internal class CompNode : INode<Composite>
    {
        public int id { get; set; }
        public Composite value { get; set; }
        public INode<Composite> ?connected_node { get; set; }
        public SKColor color { get; set; }
        public bool IsOutput { get; set; }
        public CompNode(bool is_output)
        {
            IsOutput = is_output;
            value = new Composite();
        }
        public void Transfer()
        {
            if (connected_node != null && this.IsOutput)
            {
                connected_node.value = value;
            }
            else
            {
                if (connected_node != null)
                {
                    value = connected_node.value;
                }
            }
        }
    }

    internal class OnOffNode : INode<bool>
    {
        public int id { get; set; }
        public bool value { get; set; }
        public INode<bool> ?connected_node { get; set; }
        public SKColor color { get; set; }
        public bool IsOutput { get; set; }
        public OnOffNode(bool is_output)
        {
            IsOutput = is_output;
            value = false;
        }
        public void Transfer()
        {
            if (connected_node != null && this.IsOutput)
            {
                connected_node.value = value;
            }
            else
            {
                if (connected_node != null)
                {
                    value = connected_node.value;
                }
            }
        }
    }

    internal class NumberNode : INode<double>
    {
        public int id { get; set; }
        public double value { get; set; }
        public INode<double> ?connected_node { get; set; }
        public SKColor color { get; set; }
        public bool IsOutput { get; set; }
        public NumberNode(bool is_output)
        {
            IsOutput = is_output;
            value = 0;
        }
        public void Transfer()
        {
            if (connected_node != null && this.IsOutput)
            {
                connected_node.value = value;
            }
            else
            {
                if (connected_node != null)
                {
                    value = connected_node.value;
                }
            }
        }
    }
}
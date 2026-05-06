using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace Microcontrollers.PartSystem
{
    public interface IGateNode<t>
    {
        public int _id {  get; set; }
        public t value { get; set; }
        public bool _isOutput { get; set; }
        public int ?target_id { get; set; }
    }
    public class OnOffGateNode : IGateNode<bool>
    {
        public OnOffGateNode(int id,bool isOutput, int? targetid = null) 
        {
            _id = id;
            value = false;
            _isOutput = isOutput;
            target_id = targetid;
        }
        public int _id { get; set; }
        public bool value { get; set; }
        public bool _isOutput { get; set; }
        public int? target_id { get; set; }
    }
    public class VideoGateNode : IGateNode<SKBitmap>
    {
        public VideoGateNode(int id, bool isOutput, int? targetid = null)
        {
            _id = id;
            value = null;
            _isOutput = isOutput;
            target_id = targetid;
        }
        public int _id { get; set; }
        public SKBitmap value { get; set; }
        public bool _isOutput { get; set; }
        public int? target_id { get; set; }
    }
    public class NumberGateNode : IGateNode<double>
    {
        public NumberGateNode(int id,bool isOutput, int? targetid = null)
        {
            _id = id;
            value = 0;
            _isOutput = isOutput;
            target_id = targetid;
        }
        public int _id { get; set; }
        public double value { get; set; }
        public bool _isOutput { get; set; }
        public int? target_id { get; set; }
    }
    public class CompositeGateNode : IGateNode<Microcontrollers.ConnectionSystem.Composite>
    {
        public CompositeGateNode(int id, bool isOutput, int? targetid = null)
        {
            _id = id;
            _isOutput = isOutput;
            target_id = targetid;
            value = new Microcontrollers.ConnectionSystem.Composite();
        }
        public int _id { get; set; }
        public Microcontrollers.ConnectionSystem.Composite value { get; set; }
        public bool _isOutput { get; set; }
        public int? target_id { get; set; }
    }
}

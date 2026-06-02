using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ScematicEditor
{
    internal class PartPosition
    {
        internal PartPosition(Vector2 position, Vector2 size, string id)
        {
            this.position = position;
            this.size = size;
            this.id = id;
        }

        public Vector2 position {  get; set; }
        public Vector2 size { get; set; }
        public string id { get; set; }
    }
}

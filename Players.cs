using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TickTackToe
{
    public abstract class Players
    {
        public string Shape { get; private set; }

        public int ID { get; private set; }

        public Players(string shape, int id)
        {
            Shape = shape;
            ID = id;
        }

        public abstract string Turn(Players pl, string[,] obj);
    }
}
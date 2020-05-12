using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public static class DesignPattern
    {
        public static void Run()
        {
            var color = new Color(100, 200, 300);

            var shallowColor = color.Clone();

            var breakdebug = 0;
        }
    }


    //Prototype
    //Create new objects by copying prototypical instance
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", _red, _green, _blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

}

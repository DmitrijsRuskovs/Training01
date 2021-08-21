using System;


namespace CalculateArea
{

    public class Geometry
    {
        public static double AreaOfCircle(decimal radius)
        {
            if (radius <= 0) throw new NotPositiveArgumentException("Error! Enter positive arguments!");
            else return Math.PI * (double)radius * (double)radius;
        }

        public static double AreaOfRectangle(decimal length, decimal width)
        {
            if (length <= 0 || width <= 0) throw new NotPositiveArgumentException("Error! Enter positive arguments!");
            else return (double)length * (double)width;
        }

        public static double AreaOfTriangle(decimal ground, decimal h)
        {
            if (ground <= 0 || h <= 0) throw new NotPositiveArgumentException("Error! Enter positive arguments!");
            else return (double)ground * (double)h / 2;          
        }
    }
}

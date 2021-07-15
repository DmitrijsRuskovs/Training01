using System;


namespace CalculateArea
{
    public class Geometry
    {
        public static double areaOfCircle(decimal radius)
        {
            if (radius <= 0) throw new NotImplementedException("Error! Enter positive arguments!");
            else return Math.PI * (double)radius * (double)radius;
        }

        public static double areaOfRectangle(decimal length, decimal width)
        {
            if (length <= 0 || width <= 0) throw new NotImplementedException("Error! Enter positive arguments!");
            else return (double)length * (double)width;
        }

        public static double areaOfTriangle(decimal ground, decimal h)
        {
            if (ground<=0 || h <=0) throw new NotImplementedException("Error! Enter positive arguments!");
            else return (double)ground * (double)h / 2;
            
        }
    }
}

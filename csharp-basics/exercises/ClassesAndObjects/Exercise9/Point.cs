namespace Exercise9
{
    public class Point
    {
        public int x = 0;
        public int y = 0;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static void swapPoints(Point p1, Point p2)
        {
            int x = p1.x;
            int y = p1.y;
            p1.x = p2.x;
            p1.y = p2.y;
            p2.x = x;
            p2.y = y;
        }
    }
}

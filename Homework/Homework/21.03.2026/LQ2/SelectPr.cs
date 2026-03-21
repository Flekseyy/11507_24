namespace CW4.Task2;

public class SelectPr
{
    
    public static void Run()
    {
        var list = new List<Point>{new(0,0), new(0,1)};
        int count = GetNeighborCount(list);
        Console.WriteLine(count);
    }
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X, Y;

        public override bool Equals(object? obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
    public static int GetNeighborCount(List<Point> points)
    {
        var adders = new[] { -1, 0, 1 };

        var allp = points.MySelectMany(p => adders
            .MySelectMany(nx => adders
                .MySelect(ny => new Point(p.X + nx, p.Y + ny))));
        var distinctNeighbors = allp.MyDistinct();
        return distinctNeighbors.MyCount();
       
    }
    

}

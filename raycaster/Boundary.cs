using System.Numerics;
using Raylib_cs;

class Boundary
{
    public static List<Boundary> walls = new();
    
    public Vector2 a;
    public Vector2 b;
    public Boundary(int x1, int y1, int x2, int y2)
    {
        a = new(x1, y1);
        b = new(x2, y2);
    }

    public void Show()
    {
        Raylib.DrawLine((int)(a.X / 10), (int)(a.Y / 10), (int)(b.X / 10), (int)(b.Y / 10), Color.WHITE);
    }

    public static void Shape(int div, int cx, int cy, int r)
    {
        float resolution = 360 / div;

        for (int i = 0; i < div; i++)
        {
            float degree = i * resolution;

            int x1 = cx;

            int y1 = cy;

            int x2 = (int)(cx + r * Math.Cos(Raylib.DEG2RAD * degree));

            int y2 = (int)(cy + r * Math.Sin(Raylib.DEG2RAD * degree));

            walls.Add(new Boundary(x1, y1, x2, y2));

            cx = x2;

            cy = y2;

        }
    }
}

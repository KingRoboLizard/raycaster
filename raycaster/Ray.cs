using System.Numerics;
class Ray
{
    Vector2 pos;
    Vector2 dir;
    public Ray(Vector2 pos, float angle)
    {
        this.pos = pos;
        angle *= (float)(Math.PI / 180);
        this.dir = new((float)Math.Cos(angle), (float)Math.Sin(angle));
    }

    public Vector2 cast(Boundary wall)
    {
        float x1 = wall.a.X;

        float y1 = wall.a.Y;

        float x2 = wall.b.X;

        float y2 = wall.b.Y;


        float x3 = this.pos.X;

        float y3 = this.pos.Y;

        float x4 = this.pos.X + this.dir.X;

        float y4 = this.pos.Y + this.dir.Y;


        float den1 = (x1 - x2) * (y3 - y4);

        float den2 = (y1 - y2) * (x3 - x4);

        float den = den1 - den2;

        if (den == 0) return Vector2.Zero;


        float t1 = (x1 - x3) * (y3 - y4);

        float t2 = (y1 - y3) * (x3 - x4);

        float t = (t1 - t2) / den;


        float u1 = (x1 - x2) * (y1 - y3);

        float u2 = (y1 - y2) * (x1 - x3);

        float u = -(u1 - u2) / den;


        if (t > 0 && t < 1 && u > 0)
        {
            Vector2 pt;

            pt.X = x1 + t * (x2 - x1);

            pt.Y = y1 + t * (y2 - y1);

            return pt;

        }
        else
        {
            return Vector2.Zero;
        }
    }
}

using System.Numerics;
using Raylib_cs;

class Particle
{
    float b = 0;
    float r = 0;
    Vector2 pos = new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
    List<Ray> rays = new();
    int rayCount = Raylib.GetScreenWidth();
    int wally = Raylib.GetScreenHeight() / 2;
    int heighte = Raylib.GetScreenHeight() * 20;

    public Particle(float r, int FOV, Vector2 pos)
    {
        for (double a = 0; a < FOV; a += FOV * 2.0 / rayCount)
        {
            this.rays.Add(new Ray(pos, (float)(a - FOV / 2 + r * 57.2958)));

            b = (float)a;

        }
    }
    public void look(List<Boundary> walls)
    {
        int i = -1;

        foreach (var ray in rays)
        {
            Vector2 closest = Vector2.Zero;

            float record = float.MaxValue;


            foreach (var wall in walls)
            {
                var pt = ray.cast(wall);

                if (pt != Vector2.Zero)
                {
                    float d = Vector2.Distance(this.pos, pt);

                    if (d < record)
                    {
                        closest = pt;

                        record = d;

                    }
                }
            }
            if (closest != Vector2.Zero)
            {
                Raylib.DrawLine((int)pos.X / 10, (int)pos.Y / 10, (int)closest.X / 10, (int)closest.Y / 10, Color.LIGHTGRAY);    //map ray lines
                float distance = Vector2.Distance(new(this.pos.X, this.pos.Y), new(closest.X, closest.Y));
                distance = (float)(distance * Math.Cos((r - b) * (Math.PI / 180)));

                Raylib.DrawLine(i * Raylib.GetScreenWidth() / rayCount * 2 + 8, (int)(wally - heighte / distance * 5), i * Raylib.GetScreenWidth() / this.rayCount * 2 + 8, (int)(this.wally + this.heighte / distance), new Color(0, Math.Clamp((int)(255 - distance / 5), 0, 255), 0, 255));
            }
            i++;
        }
    }
    public void update(int x, int y)
    {
        this.pos = new(x, y);
    }
}
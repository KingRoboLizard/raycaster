using System.Numerics;
using Raylib_cs;


Raylib.InitWindow(Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), "raycaster");
Raylib.ToggleFullscreen();
Raylib.SetTargetFPS(60);

//Map walls
Boundary.walls.Add(new Boundary(0, 0, 2000, 0));
Boundary.walls.Add(new Boundary(2000, 0, 2000, 2000));
Boundary.walls.Add(new Boundary(2000, 2000, 0, 2000));
Boundary.walls.Add(new Boundary(0, 2000, 0, 0));

//shapes from 3-10 sides
Boundary.Shape(10, 1200, 200, 50);
Boundary.Shape(9, 980, 200, 50);
Boundary.Shape(8, 800, 200, 50);
Boundary.Shape(7, 650, 200, 50);
Boundary.Shape(6, 500, 200, 50);
Boundary.Shape(5, 350, 200, 50);
Boundary.Shape(4, 200, 200, 50);
Boundary.Shape(3, 50, 200, 50);

float r = 0;
int FOV = 60;
int speed = 10;
int x = 50;
int y = 50;

while (!Raylib.WindowShouldClose())
{
    int my = (Raylib.IsKeyDown(KeyboardKey.KEY_D) - Raylib.IsKeyDown(KeyboardKey.KEY_A));
    int mx = (Raylib.IsKeyDown(KeyboardKey.KEY_W) - Raylib.IsKeyDown(KeyboardKey.KEY_S));
    x += (int)(Math.Cos(r) * mx * speed);
    y += (int)(Math.Sin(r) * mx * speed);
    x += (int)(Math.Cos(r + 1.571) * my * speed);
    y += (int)(Math.Sin(r + 1.571) * my * speed);
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) { r += 0.03f; }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) { r -= 0.03f; }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    var particle = new Particle(r, FOV, new(x, y));
    particle.update(x, y);
    particle.look(Boundary.walls);

    foreach (var wall in Boundary.walls)
    {
        wall.Show();
    }
    
    Raylib.DrawFPS(Raylib.GetScreenWidth() - 100, 50);
    Raylib.EndDrawing();
}
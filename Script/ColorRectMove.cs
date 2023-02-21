using Godot;
using System;

public partial class ColorRectMove : ColorRect
{
    private Vector2 offset = new Vector2(100.0f, 50.0f);

    public override void _Process(double delta)
    {
        Position = GetGlobalMousePosition() - offset;
    }
}

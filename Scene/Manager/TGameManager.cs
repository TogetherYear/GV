using Godot;
using System;

public partial class TGameManager : TSingleton<TGameManager>
{
    public float deltaTime;

    public override void _Process(double delta)
    {
        deltaTime = (float)delta;
    }

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
        Engine.MaxFps = 144;
    }
}

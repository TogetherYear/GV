using Godot;
using System;

public partial class TFreeCharacter : Node3D
{
    [Export]
    public Camera3D camera;

    [Export(PropertyHint.Range, "1.0f,100.0f")]
    public float speed = 100.0f;

    [Export(PropertyHint.Range, "0.0f,1.0f")]
    public float rotateSpeed = 0.15f;

    public override void _Ready()
    {
        TInputManager.Instance.Jump += (TInputManager.TKeyType t) =>
        {
            GD.Print(t);
        };
    }

    public override void _Process(double delta)
    {
        Vector2 inputDir = Input.GetVector("A", "D", "W", "S");
        if (inputDir != Vector2.Zero)
        {
            TranslateObjectLocal(camera.Basis * new Vector3(inputDir.X, 0.0f, inputDir.Y) * speed * TGameManager.Instance.deltaTime);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion m)
        {
            RotateObjectLocal(Vector3.Right, -m.Relative.Y * rotateSpeed * TGameManager.Instance.deltaTime);
            GlobalRotate(Vector3.Up, -m.Relative.X * rotateSpeed * TGameManager.Instance.deltaTime);
        }
    }
}

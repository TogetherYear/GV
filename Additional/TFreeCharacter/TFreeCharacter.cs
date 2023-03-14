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


    public override void _Process(double delta)
    {
        TransformPosition();
    }

    private void TransformPosition()
    {
        if (TInputManager.Instance.inputDirection != Vector2.Zero)
        {
            TranslateObjectLocal(camera.Basis * new Vector3(TInputManager.Instance.inputDirection.X, 0.0f, TInputManager.Instance.inputDirection.Y) * speed * TGameManager.Instance.deltaTime);
        }
        TranslateObjectLocal(camera.Basis * Vector3.Up * TInputManager.Instance.rd * speed * TGameManager.Instance.deltaTime);

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

using Godot;
using System;

public partial class TFPSCharacter : CharacterBody3D
{
    [Export]
    public Camera3D camera;

    [Export(PropertyHint.Range, "100.0f,1000.0f")]
    public float speed = 100.0f;

    [Export(PropertyHint.Range, "0.0f,1.0f")]
    public float rotateSpeed = 0.15f;

    [Export(PropertyHint.Range, "0.0f,10.0f")]
    public float JumpVelocity = 4.5f;

    public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

    public override void _Process(double delta)
    {
        Vector3 velocity = Velocity;

        if (!IsOnFloor())
            velocity.Y -= gravity * TGameManager.Instance.deltaTime;

        if (Input.IsActionJustPressed("Jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        if (TInputManager.Instance.inputDirection != Vector2.Zero)
        {
            Vector3 direction = (Transform.Basis * new Vector3(TInputManager.Instance.inputDirection.X, 0, TInputManager.Instance.inputDirection.Y)).Normalized();
            velocity.X = direction.X * speed * TGameManager.Instance.deltaTime;
            velocity.Z = direction.Z * speed * TGameManager.Instance.deltaTime;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, speed * TGameManager.Instance.deltaTime);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, speed * TGameManager.Instance.deltaTime);
        }
        Velocity = velocity;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion m)
        {
            RotateY(-m.Relative.X * rotateSpeed * TGameManager.Instance.deltaTime);
            camera.RotateX(-m.Relative.Y * rotateSpeed * TGameManager.Instance.deltaTime);
            camera.Rotation = new Vector3(Mathf.Clamp(camera.Rotation.X, Mathf.DegToRad(-70.0f), Mathf.DegToRad(70.0f)), camera.Rotation.Y, camera.Rotation.Z);
        }
    }
}

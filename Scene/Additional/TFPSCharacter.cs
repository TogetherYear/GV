using Godot;
using System;

public partial class TFPSCharacter : CharacterBody3D
{
    [Export]
    public Camera3D camera;

    [Export(PropertyHint.Range, "100.0f,1000.0f")]
    public float Speed = 100.0f;

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

        Vector2 inputDir = Input.GetVector("A", "D", "W", "S");
        Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed * TGameManager.Instance.deltaTime;
            velocity.Z = direction.Z * Speed * TGameManager.Instance.deltaTime;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
        }
        Velocity = velocity;
        MoveAndSlide();
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion m)
        {
            RotateY(-m.Relative.X * rotateSpeed * TGameManager.Instance.deltaTime);
            camera.RotateX(-m.Relative.Y * rotateSpeed * TGameManager.Instance.deltaTime);
            camera.Rotation = new Vector3(Mathf.Clamp(camera.Rotation.X, Mathf.DegToRad(-70.0f), Mathf.DegToRad(70.0f)), camera.Rotation.Y, camera.Rotation.Z);
        }
    }
}

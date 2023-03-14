using Godot;
using System;

public partial class TInputManager : TSingleton<TInputManager>
{
    public enum TKeyType
    {
        Press,
        Release
    }

    public Action<TKeyType> Jump;

    public Vector2 inputDirection;

    public float rd = 0.0f;

    private bool isJump;

    public override void _Input(InputEvent @event)
    {
        SetValues(@event);
        DealKeyEvent();
        DealKeyMotion();
    }

    private void SetValues(InputEvent @event)
    {
        inputDirection = Input.GetVector("A", "D", "W", "S");
        rd = Input.GetAxis("Drop", "Rise");
    }

    private void DealKeyEvent()
    {
        if (Input.IsActionJustPressed("Jump"))
        {
            isJump = true;
            Jump?.Invoke(TKeyType.Press);
        }
        else if (Input.IsActionJustReleased("Jump"))
        {
            isJump = false;
            Jump?.Invoke(TKeyType.Release);
        }
    }

    private void DealKeyMotion()
    {

    }
}

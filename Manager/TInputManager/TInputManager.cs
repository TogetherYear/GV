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

    public Action<TKeyType> Crouch;

    public Action<TKeyType> Sprint;

    private bool isJump;

    private bool isCrouch;

    private bool isSprint;

    public override void _Input(InputEvent @event)
    {
        DealNormalKeyEvent();
    }

    private void DealNormalKeyEvent()
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
        else if (Input.IsActionJustPressed("Crouch"))
        {
            isCrouch = true;
            Crouch?.Invoke(TKeyType.Press);
        }
        else if (Input.IsActionJustReleased("Crouch"))
        {
            isCrouch = false;
            Crouch?.Invoke(TKeyType.Release);
        }
        else if (Input.IsActionJustPressed("Sprint"))
        {
            isSprint = true;
            Sprint?.Invoke(TKeyType.Press);
        }
        else if (Input.IsActionJustReleased("Sprint"))
        {
            isSprint = false;
            Sprint?.Invoke(TKeyType.Release);
        }
    }
}

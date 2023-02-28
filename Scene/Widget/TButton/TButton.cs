using Godot;
using System;

public partial class TButton : Button
{
    public Action OnClick;

    public override void _Ready()
    {
        Pressed += () =>
        {
            OnClick?.Invoke();
        };
    }
}

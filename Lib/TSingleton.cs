using Godot;
using System;

public partial class TSingleton<T> : Node where T : TSingleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    public override void _EnterTree()
    {
        if (instance != null)
        {
            QueueFree();
        }
        else
        {
            instance = (T)this;
        }
    }

    public override void _ExitTree()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}

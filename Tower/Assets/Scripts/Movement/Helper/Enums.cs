using System;
namespace Tower.Movment.Helper
{
    public enum MovmentState
    {
        Stand,
        WalkLeft,
        WalkRight,
        WalkUp,
        WalkDown,
        Jump,
        Fall,
        RunLeft,
        RunRight,
        Strike,
    }

    [Flags]
    public enum ActionState
    {
        AllAllowed,
        NoMovement,
        NoJump,
    }
}
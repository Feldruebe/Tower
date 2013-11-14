using UnityEngine;
using System.Collections;
using Tower;

public class CharacterActionBase
{
    public float ActionTime { get; set; }

    public CharacterActionBase()
    {
        ActionTime = 1;
    }

    public CharacterActionBase(float actionTime)
    {
        ActionTime = actionTime;
    }

    public virtual void DoAction(MoveMotor motor)
    {
        if (motor.TestIfGrounded())
        {
            motor.direction = new Vector3(motor.direction.x, motor.jumpForce, motor.direction.z);
            motor.fallSpeed = motor.jumpForce;
        }
    }
}

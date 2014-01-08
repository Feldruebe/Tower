using UnityEngine;
using System.Collections;

namespace Tower.Movment.Skills
{
    public class SkillBase
    {
        public virtual SkillResult ExecuteSkill(MoveMotor2 motor, params object[] parameters)
        {
            SkillResult result = new SkillResult() { completed = true };
            if (motor.IsGrounded)
            {
                motor.Direction = new Vector3(motor.Direction.x, motor.JumpForce, motor.Direction.z);
                motor.FallSpeed = motor.JumpForce;
            }

            return result;
        }

    }
}

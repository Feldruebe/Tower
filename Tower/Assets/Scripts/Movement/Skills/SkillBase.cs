using UnityEngine;
using System.Collections;

namespace Tower.Movment.Skills
{
    public class SkillBase
    {
        int state = 0;
        bool completed = false;

        public virtual void UpdateInput()
        {
            if(this.state == 0)
            {

            }
            else if(this.state == 1)
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    state = 2;
                }
            }
            else if(this.state == 2)
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    this.completed = true;
                }
            }
        }

        public virtual SkillResult ExecuteSkill(MoveMotor2 motor, params object[] parameters)
        {
            SkillResult result = new SkillResult() { completed = false };
            if (state == 0)
            {
                if (motor.IsGrounded)
                {
                    motor.Direction = new Vector3(motor.Direction.x, motor.JumpForce, motor.Direction.z);
                    motor.FallSpeed = motor.JumpForce;
                    state = 1;
                }
            }
            else if(state == 1)
            {

            }
            else if (state == 2)
            {
                motor.Direction = new Vector3(20, motor.Direction.y, 0);
                if(this.completed)
                {
                    result.completed = true;
                }
            }

            return result;
        }

        public virtual void Reset()
        {
            completed = false;
            state = 0;
        }

    }
}

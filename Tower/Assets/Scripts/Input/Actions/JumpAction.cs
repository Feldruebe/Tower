using UnityEngine;
using System.Collections;

namespace Tower
{
    public class JumpAction : AtomicAction
    {
        private JumpActionContext jumpActionContext;
        float standTime = 0.3f;
        private int actionState = 0;

        public JumpAction(MoveMotor motor)
        {
            jumpActionContext = new JumpActionContext(motor);
        }

        protected override bool Update(float deltaTime)
        {
            switch (actionState)
            {
                case 0:
                    if (jumpActionContext.Motor.TestIfGrounded())
                    {
                        jumpActionContext.Motor.direction = new Vector3(jumpActionContext.Motor.direction.x, jumpActionContext.Motor.jumpForce, jumpActionContext.Motor.direction.z);
                        jumpActionContext.Motor.fallSpeed = jumpActionContext.Motor.jumpForce;
                    }
                    actionState++;
                    return true;
                case 1:
                    if (jumpActionContext.Motor.TestIfGrounded())
                    {
                        jumpActionContext.Motor.movmentState = MovmentState.Fall;
                        actionState++;
                    }
                    return true;
                case 2:
                    standTime -= deltaTime;
                    Debug.Log(standTime);
                    if (standTime < 0)
                        return false;
                    return true;
            }

            return true;
        }
    }
}

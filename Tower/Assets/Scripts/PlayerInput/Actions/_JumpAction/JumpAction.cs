using UnityEngine;
using System.Collections;
using Tower.Movment;
using Tower.Movment.Helper;
using Tower.PlayerInput.Helper;

namespace Tower.PlayerInput.Actions
{
    public class JumpAction : AtomicAction
    {
        private JumpActionContext jumpActionContext;

        public JumpAction(MoveMotor motor)
        {
            jumpActionContext = new JumpActionContext(motor);
        }

        protected override ActionResult Update(float deltaTime, ActionState actionState)
        {
            if (jumpActionContext.Motor.TestIfGrounded())
            {
                jumpActionContext.Motor.direction = new Vector3(jumpActionContext.Motor.direction.x, jumpActionContext.Motor.jumpForce, jumpActionContext.Motor.direction.z);
                jumpActionContext.Motor.fallSpeed = jumpActionContext.Motor.jumpForce;
            }
            return new ActionResult(ActionState.NoJump | actionState, true);
        }
    }
}

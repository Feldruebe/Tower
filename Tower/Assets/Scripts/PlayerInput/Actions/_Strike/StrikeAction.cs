using UnityEngine;
using System.Collections;
using Tower.Movment;
using Tower.PlayerInput.Helper;
using Tower.Movment.Helper;
using Tower.Animation;

namespace Tower.PlayerInput.Actions
{
    public class StrikeAction : AtomicAction
    {
        private StrikeActionContext strikeActionContext;

        public StrikeAction(MoveMotor motor, AnimationController animationController)
        {
            strikeActionContext = new StrikeActionContext(motor, animationController);
        }

        protected override ActionResult Update(float deltaTime, ActionState actionState)
        {
            switch (ActionProgress)
            {
                case 0:
                    strikeActionContext.Motor.movmentState = MovmentState.Strike;
                    ActionProgress++;
                    return new ActionResult(strikeActionContext.Motor.TestIfGrounded() ? ActionState.NoJump | ActionState.NoMovement : ActionState.NoJump | actionState, false);
                case 1:
                    strikeActionContext.Motor.movmentState = MovmentState.Strike;
                    if (strikeActionContext.AnimationController.spriteAnimator.IsPlaying("Strike"))
                    {
                        return new ActionResult(actionState, false);
                    }
                    return new ActionResult(ActionState.AllAllowed, true);
                default:
                    return new ActionResult(ActionState.AllAllowed, true);
            }
        }
    }
}

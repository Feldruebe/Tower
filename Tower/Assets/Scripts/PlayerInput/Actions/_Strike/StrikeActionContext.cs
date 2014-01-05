using UnityEngine;
using System.Collections;
using Tower.PlayerInput.Actions;
using Tower.Movment;
using Tower.Animation;

namespace Tower.PlayerInput.Actions
{
    public class StrikeActionContext : ActionContext
    {
        public AnimationController AnimationController { get; set; }
        public StrikeActionContext(MoveMotor motor, AnimationController animationController)
            : base(motor)
        {
            AnimationController = animationController;
        }
    }
}

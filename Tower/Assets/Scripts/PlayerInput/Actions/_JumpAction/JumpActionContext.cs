using UnityEngine;
using System.Collections;
using Tower.Movment;

namespace Tower.PlayerInput.Actions
{
    public class JumpActionContext : ActionContext
    {
        public JumpActionContext(MoveMotor motor)
            : base(motor)
        {

        }
    }
}

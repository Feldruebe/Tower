using UnityEngine;
using System.Collections;
using Tower.Movment;

namespace Tower.PlayerInput.Actions
{
    public class ActionContext
    {
        public MoveMotor Motor { get; set; }

        public ActionContext(MoveMotor motor)
        {
            this.Motor = motor;
        }
    }
}
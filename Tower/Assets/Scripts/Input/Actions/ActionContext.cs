using UnityEngine;
using System.Collections;

namespace Tower
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
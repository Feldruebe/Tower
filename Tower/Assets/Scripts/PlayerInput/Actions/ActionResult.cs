using UnityEngine;
using System.Collections;
using Tower.Movment.Helper;

namespace Tower.PlayerInput.Helper
{
    public class ActionResult
    {
        public ActionResult(Movment.Helper.ActionState actionState, bool actionFinished)
        {
            this.ActionState = actionState;
            ActionFinished = actionFinished;
        }
        public ActionState ActionState { get; set; }
        public bool ActionFinished { get; set; }
    }
}
using UnityEngine;
using System.Collections;
using Tower;
using Tower.Movment.Helper;
using Tower.PlayerInput.Helper;

namespace Tower.PlayerInput.Actions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AtomicAction
    {
        public int ActionProgress { get; set; }

        // <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="actionContext"></param>
        public ActionResult UpdateCore(float deltaTime, ActionState actionState)
        {
            return this.Update(deltaTime, actionState);
        }

        protected abstract ActionResult Update(float deltaTime, ActionState actionState);
    }
}
using UnityEngine;
using System.Collections;
using Tower;

namespace Tower
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AtomicAction
    {
        // <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="actionContext"></param>
        public bool UpdateCore(float deltaTime)
        {
            return this.Update(deltaTime);
        }

        protected abstract bool Update(float deltaTime);
    }
}
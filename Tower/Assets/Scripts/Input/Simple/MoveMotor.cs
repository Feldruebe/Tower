using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tower
{
    public class MoveMotor : MonoBehaviour
    {

        public Vector3 direction;
        public List<CharacterActionBase> movesToDo = new List<CharacterActionBase>();
        public float speed;
        public float jumpForce;
        public LayerMask layerMask;
        public float gravity = 20;
        public float gravityMax = 20;
        public float fallSpeed = 0;
        public float motorIsBlockedTime = 0;

        private bool wasGrounded = false;
        
        // Use this for initialization
        void Start()
        {

        }

        void Update()
        {
            if(motorIsBlockedTime > 0)
                motorIsBlockedTime -= Time.deltaTime;
        }

        void FixedUpdate()
        {
            if (TestIfGrounded())
            {
                wasGrounded = true;
                fallSpeed = -gravityMax/2.0f;
            }
            fallSpeed -= gravity;
            direction = direction * Time.deltaTime * speed;
            direction = new Vector3(direction.x, fallSpeed, direction.z);

            DoAction();
            if (!wasGrounded && TestIfGrounded())
            {
                direction *= 0.6f;

            }
            direction = new Vector3(Mathf.Clamp(direction.x, -20, 20),
                                    Mathf.Clamp(direction.y, -jumpForce, jumpForce),
                                    Mathf.Clamp(direction.z, -20, 20));
            rigidbody.AddForce(direction, ForceMode.VelocityChange);

        }

        private void DoAction()
        {
            if (movesToDo.Count == 0 || motorIsBlockedTime > 0)
                return;

            movesToDo[0].DoAction(this);
            motorIsBlockedTime = movesToDo[0].ActionTime;
            movesToDo.RemoveAt(0);

        }

        void OnTriggerEnter(Collider other)
        {
            //grounded = true;
            //direction = Vector3.zero;
        }

        internal void AddAction(CharacterActionBase action)
        {
            movesToDo.Add(action);
        }

        public bool TestIfGrounded()
        {
            if (Physics.CheckCapsule(transform.position + new Vector3(-0.3f, -0.1f, 0), transform.position + new Vector3(0.3f, -0.1f, 0), 0.1f, layerMask))
            {
                return true;
            }

            return false;
        }
    }
}

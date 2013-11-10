using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tower
{
    public class MoveMotor : MonoBehaviour
    {

        public Vector3 direction;
        public List<Moves> movesToDo = new List<Moves>();
        public float speed;
        public float jumpForce;
        public LayerMask layerMask;

        private bool wasGrounded = false;

        // Use this for initialization
        void Start()
        {
        }

        void FixedUpdate()
        {
            direction = direction * Time.deltaTime * speed;
            direction = new Vector3(direction.x, rigidbody.velocity.y, direction.z);

            DoAction();
            if (!wasGrounded && TestIfGrounded())
            {
                direction *= 0.6f;
                
            }
            direction = new Vector3(Mathf.Clamp(direction.x, -20, 20),
                                    Mathf.Clamp(direction.y, -60, 60),
                                    Mathf.Clamp(direction.z, -20, 20));
            rigidbody.AddForce(direction, ForceMode.VelocityChange);

            wasGrounded = TestIfGrounded();
        }

        private void DoAction()
        {
            if (movesToDo.Count == 0)
                return;

            switch (movesToDo[0])
            {
                case Moves.Jump:
                    if (TestIfGrounded())
                    {
                        direction = new Vector3(direction.x, jumpForce, direction.z); 
                    }
                    break;
                default:
                    break;
            }
            movesToDo.RemoveAt(0);

        }

        void OnTriggerEnter(Collider other)
        {
            //grounded = true;
            //direction = Vector3.zero;
        }

        internal void AddAction(Moves move)
        {
            movesToDo.Add(move);
        }

        public bool TestIfGrounded()
        {
            //LayerMask layer = LayerHelper.GetLayerMaskByName("Ground", "Geometry");
            //print((int)layer);
            if (Physics.CheckCapsule(transform.position + new Vector3(-0.5f, -0.2f, 0), transform.position + new Vector3(0.5f, -0.2f, 0), 0.1f, layerMask))
            {
                return true;
            }

            return false;
        }
    }
}

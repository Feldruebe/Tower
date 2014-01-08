using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tower.Movment.Skills;


namespace Tower.Movment
{
    public class MoveMotor2 : MonoBehaviour
    {

        public bool isGrounded;
        public bool IsGrounded
        {
            get { return this.isGrounded; }
            set { this.isGrounded = value; }
        }

        public LayerMask groundLayerMask;
        public LayerMask GroundLayerMask
        {
            get { return this.groundLayerMask; }
            set { this.groundLayerMask = value; }
        }

        public float gravityMax = 20;
        public float GravityMax
        {
            get { return this.gravityMax; }
            set { this.gravityMax = value; }
        }

        public float fallSpeed = 0;
        public float FallSpeed
        {
            get { return this.fallSpeed; }
            set { this.fallSpeed = value; }
        }

        public float gravity = 20;
        public float Gravity
        {
            get { return this.gravity; }
            set { this.gravity = value; }
        }

        public Vector3 direction;
        public Vector3 Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        public float speed = 1;
        public float Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public float jumpForce = 1;
        public float JumpForce
        {
            get { return this.jumpForce; }
            set { this.jumpForce = value; }
        }

        //public Dictionary<int, SkillBase> skills = new Dictionary<int, SkillBase>();
        //public Dictionary<int, SkillBase> Skills
        //{
        //    get { return skills; }
        //}

        public List<SkillBase> skills = new List<SkillBase>();
        public List<SkillBase> Skills
        {
            get { return this.skills; }
        }

        public Queue<int> skillQueue = new Queue<int>();
        public Queue<int> SkillQueue
        {
            get { return this.skillQueue; }
        }

        public bool jump = false;

        // Use this for initialization
        void Start()
        {
            this.Skills.Add(new SkillBase());
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            this.IsGrounded = this.TestIfGrounded();

            this.Direction = this.Direction * this.Speed * Time.deltaTime;

            if (this.IsGrounded)
            {
                this.FallSpeed = -this.GravityMax;
            }

            this.FallSpeed -= this.Gravity;
            
            this.Direction = new Vector3(this.Direction.x,
                                        this.FallSpeed,
                                        this.Direction.z);

            if (this.SkillQueue.Count > 0)
            {
                this.UpdateSkill();
            }

            direction = new Vector3(Mathf.Clamp(direction.x, -20, 20),
                          Mathf.Clamp(direction.y, -jumpForce, jumpForce),
                          Mathf.Clamp(direction.z, -20, 20));

            this.rigidbody.AddForce(this.Direction, ForceMode.VelocityChange);
        }

        public bool TestIfGrounded()
        {
            if (Physics.CheckCapsule(this.transform.position + new Vector3(-0.3f, -0.1f, 0),
                                     this.transform.position + new Vector3(0.3f, -0.1f, 0), 0.1f,
                                     this.GroundLayerMask))
            {
                return true;
            }

            return false;
        }

        private void UpdateSkill()
        {
            int skillIndex = this.SkillQueue.Peek();

            SkillResult result = this.Skills[skillIndex].ExecuteSkill(this);

            if(result.completed)
            {
                this.SkillQueue.Dequeue();
            }
        }
    }
}

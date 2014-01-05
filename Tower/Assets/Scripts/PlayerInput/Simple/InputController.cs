using System.Linq;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tower.PlayerInput.Actions;
using Tower.Movment;
using Tower.Animation;

namespace Tower.PlayerInput.Simple
{
    public class InputController : MonoBehaviour
    {
        public List<MoveMotor> motors;
        public List<MoveMotor2> motors2;

        void Start()
        {
            motors = new List<MoveMotor>();
            motors.AddRange(GetComponentsInChildren<MoveMotor>().ToList());

            motors2 = new List<MoveMotor2>();
            motors2.AddRange(GetComponentsInChildren<MoveMotor2>().ToList());
        }

        void Update()
        {
            foreach (var motor in motors)
            {
                Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                if (inputDirection.magnitude > 1)
                    inputDirection.Normalize();
                motor.direction = inputDirection;

                if (Input.GetButtonDown("Jump"))
                {
                    motor.SetNextAtomicAction(new JumpAction(motor));
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    motor.SetNextAtomicAction(new StrikeAction(motor,  motor.gameObject.GetComponent<AnimationController>()));
                }
            }

            foreach (var motor in motors2)
            {
                Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                if (inputDirection.magnitude > 1)
                    inputDirection.Normalize();
                motor.direction = inputDirection;

                if (Input.GetButtonDown("Jump"))
                {
                    motor.jump = true;
                    
                }

                //if (Input.GetButtonDown("Fire1"))
                //{
                //    motor.SetNextAtomicAction(new StrikeAction(motor, motor.gameObject.GetComponent<AnimationController>()));
                //}
            }
        }

        public void AddMotor(MoveMotor motor)
        {
            motors.Add(motor);
        }
    }
}

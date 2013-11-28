using System.Linq;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tower
{
    public class InputController : MonoBehaviour
    {
        public List<MoveMotor> motors;

        void Start()
        {
            motors = new List<MoveMotor>();
            motors.AddRange(GetComponentsInChildren<MoveMotor>().ToList());
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
                    motor.AddAction(new JumpAction(motor));
                }
            }
        }

        public void AddMotor(MoveMotor motor)
        {
            motors.Add(motor);
        }
    }
}

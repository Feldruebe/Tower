﻿using System.Linq;

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


        }

        void Update()
        {
            motors = new List<MoveMotor>();
            motors.AddRange(GetComponentsInChildren<MoveMotor>().ToList());
            foreach (var motor in motors)
            {
                motor.direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                if (Input.GetButtonDown("Jump"))
                {
                    motor.AddAction(Moves.Jump);
                }
            }
        }
    }
}
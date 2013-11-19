using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Tower;

public class Follower : MonoBehaviour {

    public Transform transformToFollow;
    public List<MoveMotor> motors;

	// Use this for initialization
	void Start () {
        motors = new List<MoveMotor>();
        motors.AddRange(GetComponentsInChildren<MoveMotor>().ToList());
	}
	
	// Update is called once per frame
	void Update () {
        

        foreach (var motor in motors)
        {
            motor.direction = Vector3.zero;

            Vector3 dir = (transformToFollow.position - motor.transform.position);
            if (dir.magnitude > 5)
            {
                if (dir.magnitude < 10 && dir.y > 0.1)
                {
                    motor.AddAction(new CharacterActionBase(10));
                }
                dir.y = 0;

                motor.direction = dir.normalized;
            }
        }
	}
}

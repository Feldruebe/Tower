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
	
	}
	
	// Update is called once per frame
	void Update () {
        motors = new List<MoveMotor>();
        motors.AddRange(GetComponentsInChildren<MoveMotor>().ToList());

        foreach (var motor in motors)
        {
            Vector3 dir = (transformToFollow.position - motor.transform.position);
            if (dir.magnitude < 10 && dir.y > 0.1)
            {
                motor.AddAction(Moves.Jump);
            }
            dir.y = 0;

            motor.direction = dir.normalized;

            
            
        }
	}
}

using UnityEngine;
using System.Collections;
using Tower;
using Tower.Movment;

public class ResetJump : MonoBehaviour {

    public MoveMotor motor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("JumpReset"))
        {
            motor.fallSpeed = 0;
        }
    }

}

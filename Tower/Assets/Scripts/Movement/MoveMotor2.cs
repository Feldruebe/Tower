using UnityEngine;
using System.Collections;

public class MoveMotor2 : MonoBehaviour {

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

    public bool jump = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        this.IsGrounded = this.TestIfGrounded();

        this.Direction = this.Direction * this.Speed * Time.deltaTime;

        if(this.IsGrounded)
        {
            this.FallSpeed = -this.GravityMax;
        }

        this.FallSpeed -= this.Gravity;
        this.Direction = new Vector3(this.Direction.x,
                                    this.FallSpeed,
                                    this.Direction.z);

        if (jump)
        {
            jump = false;
            this.Direction = new Vector3(this.Direction.x, this.JumpForce, this.Direction.z);
            this.FallSpeed = this.JumpForce;
        }

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
}

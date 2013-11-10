using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    public MovmentState movmentstate;
    public bool lookingLeft;
    public float animationSpeed = 5;
    public float speed;
    public float jumpForce;
    public bool grounded;

    tk2dSprite sprite;
    tk2dSpriteAnimator spriteAnimator;
    

	// Use this for initialization
	void Start () {
        sprite = transform.FindChild("AnimatedSprite").GetComponentInChildren<tk2dSprite>();
        spriteAnimator = transform.FindChild("AnimatedSprite").GetComponentInChildren<tk2dSpriteAnimator>();
	}

    void FixedUpdate()
    {

    }

	// Update is called once per frame
	void Update () {

        HandleInput();
        HandleMovmentState();

	}

    private void HandleInput()
    {

        if (grounded)
        {
            movmentstate = MovmentState.Stand;
        }
        var direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            direction += Vector3.left * speed * Time.deltaTime;
            lookingLeft = true;
            if (grounded)
            {

                movmentstate = MovmentState.WalkLeft;
            }
        }
        else
            if (Input.GetKey(KeyCode.D))
            {
                //transform.position += Vector3.right * speed * Time.deltaTime;
                lookingLeft = false;
                direction += Vector3.right * speed * Time.deltaTime;
                if (grounded)
                {
                    movmentstate = MovmentState.WalkRight;
                }
            }

                if (Input.GetKey(KeyCode.W))
                {
                    //transform.position += Vector3.forward * speed * Time.deltaTime;
                    direction += Vector3.forward * speed * Time.deltaTime;
                    if (grounded)
                    {
                        movmentstate = MovmentState.WalkUp;
                    }
                }
                else
                    if (Input.GetKey(KeyCode.S))
                    {
                        direction += Vector3.back * speed * Time.deltaTime;
                        //transform.position += Vector3.back * speed * Time.deltaTime;
                        if (grounded)
                        {
                            movmentstate = MovmentState.WalkDown;
                        }
                    }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("pressed");
            if (grounded)
            {
                print("Inner");
                //rigidbody.velocity = Vector3.up * jumpForce;
                direction += Vector3.up * jumpForce;
                grounded = false;
                movmentstate = MovmentState.Jump;
                rigidbody.velocity = direction;
            }
        }
        else
        {
            direction = new Vector3(direction.x, rigidbody.velocity.y, direction.z);
            rigidbody.velocity = direction;
        }
    }

    private void HandleMovmentState()
    {
        sprite.FlipX = lookingLeft;

        switch (movmentstate)
        {
            case MovmentState.Stand:
                spriteAnimator.Play("Stand");
                break;
            case MovmentState.WalkLeft:
                spriteAnimator.Play("Walk");
                break;
            case MovmentState.RunLeft:
                spriteAnimator.Play("Run");
                break;
            case MovmentState.WalkRight:
                spriteAnimator.Play("Walk");
                break;
            case MovmentState.RunRight:
                spriteAnimator.Play("Run");
                break;
            case MovmentState.WalkUp:
                spriteAnimator.Play("Walk");
                break;
            case MovmentState.WalkDown:
                spriteAnimator.Play("Walk");
                break;
            case MovmentState.Jump:
                spriteAnimator.Play("Jump");
                break;
            case MovmentState.Fall:
                spriteAnimator.Play("Land");
                break;
            default:
                break;
        }
        spriteAnimator.CurrentClip.fps = animationSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        grounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        //grounded = false;
    }
}

public enum MovmentState
{
    Stand,
    WalkLeft,
    WalkRight,
    WalkUp,
    WalkDown,
    Jump,
    Fall,
    RunLeft,
    RunRight,
}

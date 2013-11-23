using UnityEngine;
using System.Collections;

namespace Tower
{
public class AnimationController : MonoBehaviour {
	
	tk2dSprite sprite;
    tk2dSpriteAnimator spriteAnimator;
    MoveMotor motor;
    public MovmentState movmentstate;
    public bool lookingLeft;
    public float animationSpeed = 5;
    public float speedMultiplier = 1;
	
	// Use this for initialization
	void Start () {
        sprite = transform.FindChild("AnimatedSprite").GetComponentInChildren<tk2dSprite>();
        spriteAnimator = transform.FindChild("AnimatedSprite").GetComponentInChildren<tk2dSpriteAnimator>();
        motor = GetComponent<MoveMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        animationSpeed = motor.speed * speedMultiplier;
        if (motor.TestIfGrounded())
        {
            if (motor.direction == Vector3.zero)
            {
                movmentstate = MovmentState.Stand;
            }

            if (motor.direction.x > 0)
            {
                movmentstate = MovmentState.WalkLeft;
                lookingLeft = false;
            }

            if (motor.direction.x < 0)
            {
                movmentstate = MovmentState.WalkRight;
                lookingLeft = true;
            }

            if (motor.direction.z != 0)
            {
                if (!lookingLeft)
                {
                    movmentstate = MovmentState.WalkRight;
                }
                else
                {
                    movmentstate = MovmentState.WalkLeft;
                }
            }
        }
        else
        {
            movmentstate = MovmentState.Jump;
        }

        HandleMovmentState();
	}

    private void HandleMovmentState()
    {
        //sprite.FlipX = lookingLeft;
        if (lookingLeft)
        {
            sprite.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            sprite.transform.localScale = new Vector3(1, 1, 1);
        }
        switch (movmentstate)
        {
            case MovmentState.Stand:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Stand"), 0f, animationSpeed);
                break;
            case MovmentState.WalkLeft:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                break;
            case MovmentState.RunLeft:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Run"), 0f, animationSpeed);
                break;
            case MovmentState.WalkRight:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                break;
            case MovmentState.RunRight:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Run"), 0f, animationSpeed);
                break;
            case MovmentState.WalkUp:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                break;
            case MovmentState.WalkDown:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                break;
            case MovmentState.Jump:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Jump"), 0f, animationSpeed);
                break;
            case MovmentState.Fall:
                spriteAnimator.Play(spriteAnimator.GetClipByName("Land"), 0f, animationSpeed);
                break;
            default:
                break;
        }
        //spriteAnimator.CurrentClip.fps = animationSpeed;
    }
}
}

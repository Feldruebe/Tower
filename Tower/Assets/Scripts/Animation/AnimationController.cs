using UnityEngine;
using System.Collections;
using Tower.Movment;
using Tower.Movment.Helper;

namespace Tower.Animation
{
    public class AnimationController : MonoBehaviour
    {
        public tk2dSprite sprite;
        public tk2dSpriteAnimator spriteAnimator;
        public MoveMotor motor;
        public bool lookingLeft;
        public float animationSpeed = 5;
        public float speedMultiplier = 1;

        // Use this for initialization
        void Start()
        {
            sprite = transform.FindChild("AnimatedSprite").GetComponentInChildren<tk2dSprite>();
            spriteAnimator = transform.FindChild("AnimatedSprite").GetComponentInChildren<tk2dSpriteAnimator>();
            motor = GetComponent<MoveMotor>();
        }

        // Update is called once per frame
        void Update()
        {
            animationSpeed = motor.speed * speedMultiplier;
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
            switch (motor.movmentState)
            {
                case MovmentState.Stand:
                case MovmentState.WalkLeft:
                case MovmentState.RunLeft:
                case MovmentState.WalkRight:
                case MovmentState.RunRight:
                case MovmentState.WalkUp:
                case MovmentState.WalkDown:
                    if (motor.direction == Vector3.zero)
                    {
                        spriteAnimator.Play(spriteAnimator.GetClipByName("Stand"), 0f, animationSpeed);
                    }

                    if (motor.direction.x > 0)
                    {
                        spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                        lookingLeft = false;
                    }

                    if (motor.direction.x < 0)
                    {
                        spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                        lookingLeft = true;
                    }

                    if (motor.direction.z != 0)
                    {
                        spriteAnimator.Play(spriteAnimator.GetClipByName("Walk"), 0f, animationSpeed);
                    }
                    break;
                case MovmentState.Jump:
                    spriteAnimator.Play(spriteAnimator.GetClipByName("Jump"), 0f, animationSpeed);
                    if (motor.direction.x > 0)
                    {
                        lookingLeft = false;
                    }

                    if (motor.direction.x < 0)
                    {
                        lookingLeft = true;
                    }
                    break;
                case MovmentState.Fall:
                    spriteAnimator.Play(spriteAnimator.GetClipByName("Land"), 0f, animationSpeed);
                    break;
                case MovmentState.Strike:
                    if (spriteAnimator.CurrentClip.name != "Strike")
                    {
                        spriteAnimator.Play(spriteAnimator.GetClipByName("Strike"), 0f, animationSpeed);
                    }
                    break;
                default:
                    break;
            }
            //spriteAnimator.CurrentClip.fps = animationSpeed;
        }
    }
}

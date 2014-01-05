using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tower.PlayerInput.Actions;
using Tower.Movment.Helper;
using Tower.PlayerInput.Helper;
using UnityEditor;

namespace Tower.Movment
{

    public class EnumFlagsAttribute : PropertyAttribute
    {
        public EnumFlagsAttribute() { }
    }

    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        }
    }

    public class MoveMotor : MonoBehaviour
    {
        public Vector3 direction;
        public AtomicAction currentAtomicAction;
        public List<AtomicAction> comboActions = new List<AtomicAction>();
        public float speed;
        public float jumpForce;
        public LayerMask layerMask;
        public float gravity = 20;
        public float gravityMax = 20;
        public float fallSpeed = 0;
        public float motorIsBlockedTime = 0;
        public bool resetJump = false;
        public MovmentState movmentState;
        [SerializeField]
        [EnumFlagsAttribute]
        public ActionState actionState = ActionState.AllAllowed;
        private bool wasGrounded = false;
        
        // Use this for initialization
        void Start()
        {
        }

        void Update()
        {
            if(motorIsBlockedTime > 0)
                motorIsBlockedTime -= Time.deltaTime;
        }

        void FixedUpdate()
        {
            if ((actionState & ActionState.NoMovement) == 0)
            {
                direction = direction * Time.deltaTime * speed;
                movmentState = MovmentState.Stand;
            }
            else
            {
                direction = Vector3.zero;
            }

            if (TestIfGrounded())
            {
                if(!wasGrounded)
                {
                    
                }

                wasGrounded = true;
                fallSpeed = -gravityMax / 2.0f;
            }
            else
            {
                if (currentAtomicAction == null &&
                    comboActions.Count == 0)
                {
                    movmentState = MovmentState.Jump;
                }
            }

            fallSpeed -= gravity;
            direction = new Vector3(direction.x, fallSpeed, direction.z);

            // only Do Atomic Action if no Action is playing
            if (comboActions.Count > 0)
            {
                currentAtomicAction = null;
                actionState = ActionState.AllAllowed;

                DoComboAction();
            }
            else
            {
                DoAtomicAction();
            }

            if (!resetJump)
            {
                direction = new Vector3(Mathf.Clamp(direction.x, -20, 20),
                                        Mathf.Clamp(direction.y, -jumpForce, jumpForce),
                                        Mathf.Clamp(direction.z, -20, 20));
            }
            else
            {
                //direction = new Vector3(Mathf.Clamp(direction.x, -20, 20),
                //                        0,
                //                        Mathf.Clamp(direction.z, -20, 20));
                //resetJump = false;
            }
            rigidbody.AddForce(direction, ForceMode.VelocityChange);

        }

        private void DoAtomicAction()
        {
            if (currentAtomicAction == null || motorIsBlockedTime > 0)
                return;

            ActionResult actionResult = currentAtomicAction.UpdateCore(Time.deltaTime, actionState);
            actionState = actionResult.ActionState;
            if (actionResult.ActionFinished)
            {
                currentAtomicAction = null;
            }
        }

        private void DoComboAction()
        {
            if (comboActions.Count > 0 || motorIsBlockedTime > 0)
                return;

            ActionResult actionResult = comboActions[0].UpdateCore(Time.deltaTime, actionState);
            actionState = actionResult.ActionState;
            if (actionResult.ActionFinished)
            {
                comboActions.RemoveAt(0);
            }

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Platform"))
            {
                transform.parent = other.transform;
            }

            if (other.gameObject.tag.Equals("JumpReset"))
            {
                fallSpeed = 0;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.transform == transform.parent)
            {
                transform.parent = transform;
            }
        }

        internal void SetNextAtomicAction(AtomicAction action)
        {
            currentAtomicAction = action;
        }

        internal void AddComboAction(AtomicAction action)
        {
            comboActions.Add(action);
        }

        public bool TestIfGrounded()
        {
            if (Physics.CheckCapsule(transform.position + new Vector3(-0.3f, -0.1f, 0), transform.position + new Vector3(0.3f, -0.1f, 0), 0.1f, layerMask))
            {
                return true;
            }

            return false;
        }
    }
}

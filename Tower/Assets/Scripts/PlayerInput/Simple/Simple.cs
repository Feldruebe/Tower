using UnityEngine;
using System.Collections;

namespace Tower.PlayerInput.Simple
{
    public class Simple : MonoBehaviour
    {
        public float speed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
                transform.position += Vector3.left * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.D))
                transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
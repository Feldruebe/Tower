using UnityEngine;
using System.Collections;

public class AttachToPlatform : MonoBehaviour
{
    public Transform RepresentationRoot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Platform"))
        {
            transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == transform.parent)
        {
            transform.parent = RepresentationRoot;
        }
    }
}

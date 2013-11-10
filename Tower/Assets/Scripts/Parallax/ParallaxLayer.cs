using UnityEngine;
using System.Collections;

public class ParallaxLayer : MonoBehaviour
{

    public float distanceX;
    public float distanceY;
    public Vector3 startPosition;


	void Start () {
        //startPosition = transform.position;

        if (distanceX > 1 || distanceY > 1)
            Debug.Log("Distances should be between 0 and 1!");
	}
	
	void Update () {
	
	}
}

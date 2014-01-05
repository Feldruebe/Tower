using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    SpriteRenderer renderer;

	// Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.castShadows = true;
        renderer.receiveShadows = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ParallaxController : MonoBehaviour {

    public List<ParallaxLayer> layers = new List<ParallaxLayer>();
    public Transform parallaxCenter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var layer in layers)
        {
            //Vector3 space = layer.startPosition - parallaxCenter.position;
            layer.transform.position = layer.startPosition + new Vector3(parallaxCenter.position.x * layer.distanceX,
                                                                         parallaxCenter.position.y * layer.distanceY,
                                                                         0);
        }
	}
}

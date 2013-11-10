using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

    public HOTweenComponent hwc;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hwc.generatedTweeners[0].Restart();
            audio.Play();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        hwc.generatedTweeners[0].Restart();
        audio.Play(); 
    }
}

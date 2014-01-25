using UnityEngine;
using System.Collections;

public class SpineAnimationController : MonoBehaviour {

    SkeletonAnimation skeletonAnimation;

	// Use this for initialization
	void Start () {
        skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        skeletonAnimation.state.SetAnimation(0, "walk", true);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Jump"))
        {
            //skeletonAnimation.state.SetAnimation(0, "jump", false);
            skeletonAnimation.state.AddAnimation(0, "walk", true, 0);
        }
	}
}

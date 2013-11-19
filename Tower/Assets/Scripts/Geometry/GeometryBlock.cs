using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GeometryBlock : MonoBehaviour {

    public BoxCollider AttachCollider;
    public BoxCollider ResetJumpCollider;

    void Update()
    {
        //Scale = transform.localScale; 
    }

    public Vector3 Scale
    {
        get
        {
            return transform.localScale;
        }

        set
        {
            transform.localScale = value;
            Vector3 colliderScale = new Vector3(1 - 0.1f, 1f / value.y, 1 - 0.1f);
            AttachCollider.transform.localScale = colliderScale;
            ResetJumpCollider.transform.localScale = colliderScale;
            AttachCollider.transform.position = new Vector3(AttachCollider.transform.position.x, transform.position.y + transform.localScale.y / 2f + 0.15f, AttachCollider.transform.position.z);
            ResetJumpCollider.transform.position = new Vector3(ResetJumpCollider.transform.position.x, transform.position.y - (transform.localScale.y / 2f + 0.05f), ResetJumpCollider.transform.position.z);
        }
    }
}

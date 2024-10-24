using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Transform objectGrabPointTransform;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            //Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.unscaledDeltaTime * lerpSpeed);
            //rigidBody.MovePosition(newPosition);
            transform.position = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.unscaledDeltaTime * lerpSpeed);

        }
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        rigidBody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        rigidBody.useGravity = true;
    }
}

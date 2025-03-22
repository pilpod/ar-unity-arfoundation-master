using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPortalCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Setteo del collider de la cámera
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = .1f;

        Rigidbody rigibody = gameObject.AddComponent<Rigidbody>();
        rigibody.isKinematic = true;
        
    }

}

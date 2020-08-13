using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetoid : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    Vector3 startingVelocity;

    // Start is called before the first frame update
    void Start()
    {
        startingVelocity = new Vector3(0f, 0f, 0f);
        rb = GetComponent<Rigidbody>();
        rb.velocity = startingVelocity;
    }
}

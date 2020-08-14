using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetoid : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    Vector3 startingVelocity;

    [SerializeField]
    Material material;

    [SerializeField]
    Material trailRendererMaterialStart;
    [SerializeField]
    Material trailRendererMaterialEscape;

    // Start is called before the first frame update
    void Start()
    {
        foreach(CelestialBody celestialBody in GetComponentsInChildren<CelestialBody>())
        {
            celestialBody.AddForce(startingVelocity);
            celestialBody.GetBody().GetComponent<Renderer>().material = material;
            celestialBody.GetComponent<TrailRenderer>().material = trailRendererMaterialStart;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public Transform centerOfMass;

    [SerializeField]
    Transform celestialBodyPrefab;

    [SerializeField]
    Material material;

    private List<CelestialBody> celestialBodies = new List<CelestialBody>();

    public int numCelestialBodies = 0;

    public float startingTranslationalVelocity = 0;
    public float startingRotationalVelocity = 0;

    public float startingPositionScalar = 0;

    public float gravityScalar = 1;

    public List<CelestialBody> GetCelestialBodies()
    {
        return celestialBodies;
    }

    public Vector3 GetGravitationalVector(Vector3 position)
    {
        return Vector3.one;
    }

    public void AddCelestialBody(CelestialBody celestialBody)
    {
        celestialBodies.Add(celestialBody);
    }

    private void Start()
    {
        for (int i = 0; i < numCelestialBodies; i++)
        {
            CelestialBody celestialBody = 
                Instantiate(celestialBodyPrefab, this.transform).GetComponent<CelestialBody>();
            celestialBody.SetSize(1);
            Rigidbody rb = celestialBody.GetRigidBody();
            rb.useGravity = false;
            rb.velocity = startingTranslationalVelocity * (new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f), Random.Range(-1f, 1f)));
            rb.angularVelocity = startingRotationalVelocity * (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
            celestialBody.transform.position = startingPositionScalar * new Vector3(Random.Range(-1f,1f), Random.Range(-0.1f, 0.1f), Random.Range(-1f, 1f));
            celestialBody.GetBody().GetComponent<Renderer>().material = material;
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < celestialBodies.Count; i++)
        {
            for (int j = i + 1; j < celestialBodies.Count; j++)
            {
                Vector3 forceVector = new Vector3(0, 0, 0);
                float distance = 0;
                forceVector = celestialBodies[j].transform.position - celestialBodies[i].transform.position;
                distance = forceVector.magnitude;
                if (distance > 1)
                {
                    float forceMagnitude = gravityScalar * (celestialBodies[i].GetMass() * celestialBodies[j].GetMass()) / (distance * distance);
                    celestialBodies[i].AddForce(forceVector.normalized * forceMagnitude);
                    celestialBodies[j].AddForce(forceVector.normalized * forceMagnitude * -1);
                }
            }
        }
    }

    public void Merge()
    {
       
    }
}

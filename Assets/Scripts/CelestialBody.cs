using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField]
    protected Transform body;
    [SerializeField]
    protected float mass; // Kg
    [SerializeField]
    protected float diameter; // Km

    [SerializeField]
    protected double revolutionPeriod; // days

    SolarSystem solarSystem;

    Rigidbody rb;

    Vector3 force = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;

        solarSystem = GetComponentInParent<SolarSystem>();
        solarSystem.AddCelestialBody(this);

        //rb.velocity = startingVelocity * (new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f), Random.Range(-1f, 1f)));
        //rb.angularVelocity = startingVelocity * (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        //SetSize(mass);
    }

    private void FixedUpdate()
    {
        ApplyForces();
        force = new Vector3(0f, 0f, 0f);
    }

    public void ApplyForces()
    {
        rb.AddForce(force, ForceMode.Acceleration);
    }

    public void AddForce(Vector3 force)
    {
        this.force += force;
    }

    public float GetMass()
    {
        return (float)mass;
    }

    public void SetSize(float mass)
    {
        this.mass = mass;
        diameter = 2 * Mathf.Pow((3f / 4f) * Mathf.PI * mass, 1f / 3f);
        body.localScale = Vector3.one * diameter / 2.66134f;
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class Dé : MonoBehaviour 
{
    public float thrust = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * thrust);
    }

    void FixedUpdate()
    {
            
    }
}

using UnityEngine;
using System.Collections;

public class testTrigger : MonoBehaviour 
{
	void Start () 
    {
	
	}

	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
    }
}

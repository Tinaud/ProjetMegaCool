using UnityEngine;
using System.Collections;

public class Jeton : MonoBehaviour 
{
    public int Case = 0;

    void Start ()
    {

    }

	void Update () 
    {
	    
	}

    public void Bouger(int Nombre)
    {
        Case += Nombre;

        if(Case <= 30)
        {
            this.transform.Translate(Vector3.forward * Nombre * -0.3f);
        }
    }
}

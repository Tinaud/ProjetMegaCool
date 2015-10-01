using UnityEngine;
using System.Collections;

public class Tests : MonoBehaviour 
{
    Dé ScriptDe;
    GameObject ObjetInstancie;
    Transform Parent;
   
    public GameObject Prefab;

    void Start()
    {
        Parent = transform;
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjetInstancie = Instantiate(Prefab);
            ObjetInstancie.transform.parent = Parent;

            ScriptDe = GetComponentInChildren<Dé>();
            ScriptDe.Lancer();
        }
	}
}

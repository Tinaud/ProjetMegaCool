using UnityEngine;
using System.Collections;

public class Tests : MonoBehaviour 
{
    Dé ScriptDe;
    GameObject ObjetInstancie;
    Transform CameraPos,
              Parent;
   
    public GameObject Prefab;

    void Start()
    {
        Parent = transform;
        CameraPos = Camera.main.transform;
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ObjetInstancie = (GameObject)Instantiate(Prefab, new Vector3(CameraPos.position.x - 14, CameraPos.position.y, CameraPos.position.z + 5), Random.rotation);
            ObjetInstancie.transform.parent = Parent;

            ScriptDe = GetComponentInChildren<Dé>();
            ScriptDe.Lancer();
        }
	}
}

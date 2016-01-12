using UnityEngine;
using System.Collections;

public class Dé : MonoBehaviour 
{
    public float Patate;
    public GameObject Plateforme;

    private Rigidbody rb;
    public float TestAngle;
    public int TestAngle2;
    
    void Start()
    {
        Patate = 100f;
        TestAngle = 100f;
    }

    IEnumerator MaCoroutine()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(1, 1, 0) * Patate);

        yield return new WaitForSeconds(5f);

        if (Vector3.Angle(transform.up, Plateforme.transform.up) < TestAngle)
        {
            TestAngle2 = 1;
            TestAngle = Vector3.Angle(transform.up, Plateforme.transform.up);
        }

        if (Vector3.Angle(-transform.up, -Plateforme.transform.up) < TestAngle)
        {
            TestAngle2 = 6;
            TestAngle = Vector3.Angle(-transform.up, -Plateforme.transform.up);
        }

        if (Vector3.Angle(transform.right, Plateforme.transform.right) < TestAngle)
        {
            TestAngle2 = 5;
            TestAngle = Vector3.Angle(transform.right, Plateforme.transform.right);
        }

        if (Vector3.Angle(-transform.right, -Plateforme.transform.right) < TestAngle)
        {
            TestAngle2 = 2;
            TestAngle = Vector3.Angle(-transform.right, -Plateforme.transform.right);
        }

        if (Vector3.Angle(transform.forward, Plateforme.transform.forward) < TestAngle)
        {
            TestAngle2 = 3;
            TestAngle = Vector3.Angle(transform.forward, Plateforme.transform.forward);
        }

        if (Vector3.Angle(-transform.forward, -Plateforme.transform.forward) < TestAngle)
        {
            TestAngle2 = 4;
            TestAngle = Vector3.Angle(-transform.forward, -Plateforme.transform.forward);
        }

        switch(TestAngle2)
        {
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
            case 3:
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                break;
            case 5:
                Debug.Log("5");
                break;
            case 6:
                Debug.Log("6");
                break;
        }

        Destroy(this.gameObject);
    }

    public void Lancer()
    {
        StartCoroutine(MaCoroutine());
    }

    void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
    }
}
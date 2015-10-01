using UnityEngine;
using System.Collections;

public class Dé : MonoBehaviour 
{
    public float Patate = 600f;
    public int ChiffreDe;
    private Rigidbody rb;
    
    /*public Jeton Jeton;

    void Awake()
    {
        Jeton = GameObject.Find("Cube").GetComponent<Jeton>();
    }
    */

    IEnumerator MaCoroutine()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * Patate);
        ChiffreDe = Random.Range(1, 6);

        switch (ChiffreDe)
        {
            case 1:
                Debug.Log("1");
                //transform.Rotate(90, 0, 0);
                break;
            case 2:
                Debug.Log("2");
                //transform.Rotate(180, 0, 0);
                break;
            case 3:
                Debug.Log("3");
                //transform.Rotate(270, 0, 0);
                break;
            case 4:
                Debug.Log("4");
                //transform.Rotate(0, 0, 0);
                break;
            case 5:
                Debug.Log("5");
                //transform.Rotate(90, 0, 0);
                break;
            default:
                Debug.Log("6");
                break;
        }

        yield return new WaitForSeconds(5f);

        //Jeton.Bouger(ChiffreDe);

        Destroy(this.gameObject);
    }

    public void Lancer()
    {
        StartCoroutine(MaCoroutine());
    }
}

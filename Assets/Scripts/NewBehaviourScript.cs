using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
    private bool isSpinning;
    private Rigidbody rb;

	void Start () 
    {
        isSpinning = true;
        rb = GetComponent<Rigidbody>();
        transform.Rotate(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
        //rb.AddForce(Random.Range(200, 500), 100, Random.Range(200, 500));
        rb.AddForce(Random.Range(-300, 300), 300, 500);
        StartCoroutine(ThrowDice());
	}

	void Update () 
    {
        if (isSpinning)
            transform.Rotate(9 * Random.value, 9 * Random.value, 9 * Random.value);
	}

    IEnumerator ThrowDice()
    {
        yield return new WaitForSeconds(0.5f);
        isSpinning = false;
    }
}

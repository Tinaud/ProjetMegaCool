using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
    public bool isMoving,
                 isSpinning;
    private Rigidbody rb;

	void Awake () 
    {
        isMoving = true;
        isSpinning = true;
        rb = GetComponent<Rigidbody>();
        transform.Rotate(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
        rb.AddForce(Random.Range(-300, 300), 200, Random.Range(200, 500));
        StartCoroutine(ThrowDice());
	}

	void Update () 
    {
        if(isSpinning)
            transform.Rotate(9 * Random.value, 9 * Random.value, 9 * Random.value);
        if (rb.IsSleeping())
            isMoving = false;
	}

    IEnumerator ThrowDice()
    {
        yield return new WaitForSeconds(0.5f);
        isSpinning = false;
        yield return new WaitWhile(() => isMoving);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.transform.parent.gameObject);
    }
}

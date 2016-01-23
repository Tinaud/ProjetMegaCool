using UnityEngine;
using System.Collections;

public class TileMapMouse : MonoBehaviour {

	GameObject board;
	private float distance;

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
	}

	void OnMouseDrag()
	{
		board = GameObject.Find ("Board_P" + 1);
		GetComponent<Renderer>().material.color = Color.red;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 rayPoint = ray.GetPoint (distance);
		transform.position = new Vector3(rayPoint.x, 20.1f, rayPoint.z);
		
	}

	// Update is called once per frame
	void Update () {

	}
}

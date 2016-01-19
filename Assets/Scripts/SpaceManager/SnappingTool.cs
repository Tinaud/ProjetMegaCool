using UnityEngine;
using System.Collections;

public class SnappingTool : MonoBehaviour {
	private Color mouseOverColor = Color.green;
	private float distance;

	bool isGood;
	public int playerNo = 1;
	GameObject board;

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
	}
		
	void OnMouseDrag()
	{
		board = GameObject.Find ("Board_P" + playerNo);
		GetComponent<Renderer> ().material.color = mouseOverColor;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 rayPoint = ray.GetPoint (distance);
		float X = Mathf.Round (rayPoint.x * 2f);
		float Z = Mathf.Round (rayPoint.z * 2f);

		if (Mathf.Abs (X) >= 3 || Mathf.Abs (Z) >= 4) {
			if (Mathf.Abs (X) < 11 && Mathf.Abs (Z) < 15) {
				//Debug.Log ("tile_" + X + "_" + Z);
				GameObject tile = GameObject.Find ("Board_P" + playerNo + "/Tile_" + X + "_" + Z);
				rayPoint = tile.transform.position;
				rayPoint.y = 20.1f;
				transform.position = rayPoint;

				for (float x = X - 1; x < X + 2; x++) {
					if (x != 0) {
						for (float z = Z - 1; z < Z + 2; z++) {
							if (z != 0) {
								tile = GameObject.Find ("Board_P" + playerNo + "/Tile_" + x + "_" + z);
								tile.GetComponent<Tile> ().IsAvailable = false;
							}
						}
					}
				}
			}
		}
	}

	void Update()
	{
		
	}

	void Start() {

	}
				
}
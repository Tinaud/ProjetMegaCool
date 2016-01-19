using UnityEngine;
using System.Collections;

public class SnappingTool : MonoBehaviour {
	private Color mouseOverColor = Color.green;
	private float distance;

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
	}
		
	void OnMouseDrag()
	{
		GetComponent<Renderer>().material.color = mouseOverColor;

		GameObject board = GameObject.Find ("Board");
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 rayPoint = ray.GetPoint(distance);
		rayPoint.x = Mathf.Round(rayPoint.x);
		rayPoint.z = Mathf.Round(rayPoint.z);

		GameObject tile = GameObject.Find ("Tile_" + Mathf.Round(rayPoint.x*2) + "_" + Mathf.Round(rayPoint.z*2));
		rayPoint = tile.transform.position;
		rayPoint.y = 20.1f;
		transform.position = rayPoint;

		/*for (int x = ((int)rayPoint.x) - 1; x <= ((int)rayPoint.x) + 1; x++) {
			if (x != 0) {
				for (int z = ((int)rayPoint.z) - 1; z <= ((int)rayPoint.z) + 1; z++) {
					if (z != 0) {
						tile = GameObject.Find ("Tile_" + x + "_" + z);
						if(tile != null)
							tile.GetComponent<Tile> ().IsAvailable = false;
					}
				}
			}
		}*/
		tile.GetComponent<Tile> ().IsAvailable = false;
	}

	void Update()
	{
		
	}
}
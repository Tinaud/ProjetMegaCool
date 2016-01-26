using UnityEngine;
using System.Collections;

public class SnappingTool : MonoBehaviour {
	private Color mouseOverColor = Color.green;
	private float distance;

	bool isGood;
	public int playerNo = 1;
	BoardManager board;

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
	}
		
	void OnMouseDrag()
	{
		GameObject b = GameObject.Find ("Game Board");
		board = b.GetComponent<BoardManager> ();

		GetComponent<Renderer> ().material.color = mouseOverColor;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 rayPoint = ray.GetPoint (distance);
		int X = (int)Mathf.Round (rayPoint.x * 2);
		int Z = (int)Mathf.Round (rayPoint.z * 2);

		if ((X >= 0 && X < board.Width) && (Z >= 0 && Z < board.Height)) {
			//Debug.Log ("tile_" + X + "_" + Z);
			GameObject tile = FindTile (X, Z);
			if (tile) {
				rayPoint = tile.transform.position;
				rayPoint.y = 20.1f;
				transform.position = rayPoint;

				for (int x = X - 1; x < X + 2; x++) {
					for (int z = Z - 1; z < Z + 2; z++) {
						if ((x >= 0 && x < board.Width) && (z >= 0 && z < board.Height)) 
							if (GetScriptOf (x, z))
								GetScriptOf (x, z).IsActive  = false;
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

	public Tile GetScriptOf(int x, int z) {
		return board.GetTileAt (x, z);
	}

	public GameObject FindTile(int x, int z) {
		if (board.GetTileAt (x, z)) {
			return GameObject.Find ("Board_P" + playerNo + "/Tile_" + x + "_" + z);
		}
		return null;
	}
				
}
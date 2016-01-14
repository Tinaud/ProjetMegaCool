using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject plane;

	public int nbPlayers = 2;

	Board[] boards;

	// Use this for initialization
	void Start () {
		boards = new Board[nbPlayers];

		for (int n = 0; n < nbPlayers; n++) {
			boards [n] = new Board ();
			GameObject board = new GameObject ();
			board.name = "Board_P" + (n+1);
			// Creer un carre (plane) pour chaque tuile

			for (float x = 1; x < boards[n].Width; x += 1.1f) {
				for (float z = 1; z < boards[n].Height; z += 1.1f) {
					if (x > 4 || z > 3) {
						GameObject tile = (GameObject)Instantiate (plane);
						tile.name = "Tile_" + (int)x + "_" + (int)z;
						tile.transform.parent = board.transform;
						switch (n) {
						case 0: 
							tile.transform.position = new Vector3 (tile.transform.position.x + x, tile.transform.position.y, tile.transform.position.z + z);
							break;
						case 1:
							tile.transform.position = new Vector3 (tile.transform.position.x - x, tile.transform.position.y, tile.transform.position.z + z);
							break;
						case 2:
							tile.transform.position = new Vector3 (tile.transform.position.x - x, tile.transform.position.y, tile.transform.position.z - z);
							break;
						case 3:
							tile.transform.position = new Vector3 (tile.transform.position.x + x, tile.transform.position.y, tile.transform.position.z - z);
							break;
						}
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}

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
			board.name = "Board_P" + (n + 1);
			board.transform.parent = transform;
			// Creer un carre (plane) pour chaque tuile
			int countX = 1;		
			for (float x = 0.5f; countX < boards[n].Height; x += 0.55f) {
				int countZ = 1;
				for (float z = 0.5f; countZ < boards[n].Width; z += 0.55f) {
					if (countX > 2 || countZ > 3) {
						GameObject tile = (GameObject)Instantiate (plane);
						tile.transform.parent = board.transform;
						switch (n) {
						case 0: 
							tile.name = "Tile_" + countX + "_" + countZ;
							tile.transform.position = new Vector3 (transform.position.x + x, transform.position.y, transform.position.z + z);
							break;
						case 1:
							tile.name = "Tile_" + -countX + "_" + countZ;
							tile.transform.position = new Vector3 (transform.position.x - x, transform.position.y, transform.position.z + z);
							break;
						case 2:
							tile.name = "Tile_" + -countX + "_" + -countZ;
							tile.transform.position = new Vector3 (transform.position.x - x, transform.position.y, transform.position.z - z);
							break;
						case 3:
							tile.name = "Tile_" + countX + "_" + -countZ;
							tile.transform.position = new Vector3 (transform.position.x + x, transform.position.y, transform.position.z - z);
							break;
						}
					}
					countZ++;
				}
				countX++;
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
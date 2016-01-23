using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject plane;

	ParcManager parc;

	int width;
	int height;

	GameObject[,] tiles;

	// Use this for initialization
	void Start () {
		transform.name = "Game Board";
		width = 12; height = 16;
		tiles = new GameObject[width, height];
		GenerateBoard();
		//SetInactive ();
	}

	// Update is called once per frame
	void Update () {

	}

	public BoardManager(ParcManager parc) {
		this.parc = parc;
	}
		
	public void GenerateBoard() {

		GameObject board = new GameObject("Board_" + "P1"); //P1 = parc.ID
		board.transform.parent = transform;
		for (int x = 1; x < width; x++) {
			for (int z = 1; z < height ; z++) {
				if (x > 2 || z > 3) {
					tiles [x, z] = (GameObject)Instantiate (plane);
					tiles [x, z].transform.name = "Tile_" + x + "_" + z;
					tiles [x, z].AddComponent<Tile> ();
					tiles [x, z].transform.parent = board.transform;

					tiles [x, z].transform.position = new Vector3 (transform.position.x + (float)x / 2, 20.1f, transform.position.z + (float)z / 2);
					tiles [x, z].transform.localScale = Vector3.one * 0.042f;
					//Debug.Log ("Tile (" + (int)x + "," + (int)z + ") is out of range.");
				}
			}
		}
		//Debug.Log ("Board created with " + (width * height) + " tiles.");
	}

	public void SetActive() {
		for (int x = 0; x < height; x++) {
			for (int z = 0; z < width; z++) {
				tiles [x, z].GetComponent<Tile>().IsActive = true;
			}
		}
	}

	public void SetInactive() {
		for (int x = 0; x < height; x++) {
			for (int z = 0; z < width; z++) {
				tiles [x, z].GetComponent<Tile> ().IsActive = false;
			}
		}
	}
}
using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject plane;

	int width;//10
	int height;

	public int Height {
		get { return height; }
	}

	public int Width {
		get { return width; }
	}

//14

	GameObject[,] tiles;

	[Range(1,4)]
	public int noPlayer = 2;

	// Use this for initialization
	void Start () {
		transform.name = "Game Board";
		width = 11; height = 15;
		tiles = new GameObject[width, height];
		GenerateBoard();
		SetActive ();
	}

	// Update is called once per frame
	void Update () {

	}
		
	public void GenerateBoard() {

		GameObject board = new GameObject("Board_P" + noPlayer); //P1 = parc.ID
		board.transform.parent = transform;
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height ; z++) {
				if (x > 1 || z > 2) {
					tiles [x, z] = (GameObject)Instantiate (plane);
					tiles [x, z].transform.name = "Tile_" + x + "_" + z;
					tiles [x, z].AddComponent<Tile> ();
					tiles [x, z].transform.parent = board.transform;

					tiles [x, z].transform.position = BoardPosition((x+1)/2f, (z+1)/2f);
					tiles [x, z].transform.localScale = Vector3.one * 0.042f;
					//Debug.Log ("Tile (" + (int)x + "," + (int)z + ") is out of range.");
				}
			}
		}
		//Debug.Log ("Board created with " + (width * height) + " tiles.");
	}

	public void SetActive() {
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				if (tiles [x, z]) {
					Tile tile = GetTileAt (x, z);
					tile.IsActive = true;
				}
			}
		}
	}

	public void SetInactive() {
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				if (tiles [x, z]) {
					Tile tile = GetTileAt (x, z);
					tile.IsActive = false;
				}
			}
		}
	}

	public Tile GetTileAt (int x, int z) {
		if (tiles [x, z]) {
			return tiles [x, z].GetComponent<Tile> ();
		}

		//Debug.LogError ("This tile is out of range !");
		return null;
	}

	Vector3 BoardPosition(float x, float z) {
		switch (noPlayer) {
		case 2:
			return new Vector3 (transform.position.x - x, 20.1f, transform.position.z + z);
		case 3:
			return new Vector3 (transform.position.x - x, 20.1f, transform.position.z - z);
		case 4:
			return new Vector3 (transform.position.x + x, 20.1f, transform.position.z - z);
		default:
			return new Vector3 (transform.position.x + x, 20.1f, transform.position.z + z);
		}
	}
}
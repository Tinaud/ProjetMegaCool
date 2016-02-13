using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject plane;
	
	public static int noBoard = 1;

	int width;//10
	int height;//14

	public int Height {
		get { return height; }
	}

	public int Width {
		get { return width; }
	}

	GameObject[,] tiles;


	// Use this for initialization
	void Start () {
		width = 16;
		height = 12;
		tiles = new GameObject[width, height];
		plane = Resources.Load ("Tile") as GameObject;
		GenerateBoard ();
		noBoard++;
	}



	// Update is called once per frame
	void Update () {

	}
		
	public void GenerateBoard() {
		
		for (int x = 1; x < width; x++) {
			for (int z = 1; z < height ; z++) {
				if (x > 3 || z > 2) {
					tiles [x, z] = (GameObject)Instantiate (plane);
					tiles [x, z].transform.name = "Tile_" + x + "_" + z;
					tiles [x, z].transform.parent = transform;
					tiles [x, z].GetComponent<Tile> ().Position = new Vector2 (x, z);
					tiles [x, z].transform.position = BoardPosition(x/3.5f, z/3.5f);
                    tiles[x, z].transform.localScale = Vector3.one * 0.023f;// 0.042f;
					//Debug.Log ("Tile (" + (int)x + "," + (int)z + ") is out of range.");
				}
			}
		}
		//Debug.Log ("Board created with " + (width * height) + " tiles.");
	}

	public Tile GetTileAt (int x, int z) {
		if (tiles [x, z]) {
			return tiles [x, z].GetComponent<Tile> ();
		}

		//Debug.LogError ("This tile is out of range !");
		return null;
	}

	public void SetAvailability (int type) {
		string types = " tiles { ";

		for (int x = 1; x < width; x++) {
			for (int z = 1; z < height; z++) {
				if ((x > 2 || z > 3)) {
					Tile at = GetTileAt (x, z);
					at.IsAvailable = at.Rule.isAvailable (type);
					types += "(" + x + "," + z + ") : " + at.Rule.TileType ;
					types += "[" + at.Rule.IsOccupied + "] - ";
				}
			}
			types += ", \n";
		}
		types += " };";
		Debug.Log (types);
	}

	public void SetTileType (int x, int z, int type) {
		Tile at = GetTileAt (x, z);
		if (at && (at.Rule.TileType != (SpaceRules.Type) type))
			at.Rule.TileType = (SpaceRules.Type) type;
	}

	public void SetOccupiedTile (int x, int z, int type) {
		Tile at = GetTileAt (x, z);
		at.Rule.TileType = (SpaceRules.Type) type;
		at.Rule.IsOccupied = true;
	}

	public void SetNeighbors(int x, int z, int type) {
		Tile at = GetTileAt (x, z);
		if (at) {
			for (int i = x - 1; i < x + 2; i++) {
				for (int j = z - 1; j < z + 2; j++) {
					if ((i >= 0 && i < width) && (j >= 0 && j < height))
						SetTileType (i, j, type);
				}
			}
		}
	}

	Vector3 BoardPosition(float x, float z) {
		switch (noBoard) {
		case 2:
            return new Vector3(transform.position.x - x - 1.28f, 20.8f, transform.position.z + z - 1.73f);
		case 3:
            return new Vector3(transform.position.x - x - 1.28f, 20.8f, transform.position.z - z - 1.73f);
        case 4:
            return new Vector3(transform.position.x + x - 1.28f, 20.8f, transform.position.z - z - 1.73f);
		default:
            return new Vector3(transform.position.x + x - 1.28f, 20.8f, transform.position.z + z - 1.73f);
		}
	}
}

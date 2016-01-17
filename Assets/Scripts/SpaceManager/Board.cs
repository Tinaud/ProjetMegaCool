using UnityEngine;
using System.Collections;

public class Board {

	Tile[,] tiles;

	public string moi = "lol";

	public Tile[,] Tiles {
		get {
			return tiles;
		}
	}

	int width;

	public int Width {
		get {return width;}
	}

	int height;

	public int Height {
		get {return height;}
	}

	public Board(int width = 15, int height = 11) {
		this.width = width;
		this.height = height;

		tiles = new Tile[height, width];
		int countX = 1;
		for (float x = 0.5f; countX < height; x += 0.55f) {
			int countZ = 1;
			for (float z = 0.5f; countZ < width ; z += 0.55f) {
				if (countX > 2 || countZ > 3) {
					tiles [(int)x, (int)z] = new Tile (this, x, z);
					//Debug.Log ("Tile (" + (int)x + "," + (int)z + ") is out of range.");
				}
				countZ++;
			}
			countX++;
		}

		Debug.Log ("Board created with " + (width * height) + " tiles.");
	}

	public Tile GetTileAt(int x, int z) {
		if (x > width || x < 0 || z > height || z < 0) {
			Debug.LogError ("Tile (" + x + "," + z + ") is out of range.");
			return null;
		}

		return tiles [x, z];
	}

}
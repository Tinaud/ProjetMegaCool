using UnityEngine;
using System.Collections;

public class Board {

	Tile[,] tiles;
	int width;

	public int Width {
		get {return width;}
	}

	int height;

	public int Height {
		get {return height;}
	}

	public Board(int width = 15, int height = 10) {
		this.width = width;
		this.height = height;

		tiles = new Tile[width, height];
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				if(x > 4 || z > 3)
					tiles [x, z] = new Tile (this, x, z);
			}
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
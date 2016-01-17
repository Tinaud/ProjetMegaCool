using UnityEngine;
using System.Collections;

public abstract class MovableTile {

	Tile[] space;
	protected int price;

	public int Price {
		get {return price;}
		set {price = value;}
	}

	protected bool isMovable = false;

	public MovableTile(int price, int nbTiles) {
		this.price = price;
		space = new Tile[nbTiles]; 
	}

	public abstract void ShowDetails ();
}

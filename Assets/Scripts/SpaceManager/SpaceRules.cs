﻿using System;

public class SpaceRules
{
	public enum Type {
		Empty = 20, 
		CageEmpty = 10, 
		CageBront = 0,
		CageVelo = 1, 
		CageTric = 2,
		CageTyra = 3, 
		Restaurant = 4, 
		Security = 5,
		Bathroom = 6, 
		Casino = 7, 
		Spy = 8, 
		Paleontologist = 9
	};
	Type type;

	bool isOccupied;

	public bool IsOccupied {
		get { return isOccupied; }
		set { isOccupied = value; }
	}

	public Type TileType {
		get { return type; }
		set { type = value; }
	}

	public SpaceRules ()
	{
		type = Type.Empty;
		isOccupied = false;
	}

	bool canPlaceBooth(int boothType) {
		if (!isOccupied && (this.type == Type.Empty || (int)this.type == boothType))
			return true;
		else 
			return false;
	}

	bool canPlaceCage(int cageType) {
		if (!isOccupied && (this.type == Type.Empty || (int)this.type == cageType))
			return true;
		else 
			return false;
	}

	public bool isAvailable(int type) {
		if (type == (int)Type.CageEmpty || (type >= (int)Type.CageBront && type <= (int)Type.CageTyra))
			return canPlaceCage (type);
		else if ((type >= (int)Type.Restaurant) && (type <= (int)Type.Paleontologist))
			return canPlaceBooth (type);

		return false;
	}
}


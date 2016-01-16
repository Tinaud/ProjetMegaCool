﻿using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	bool IsTargeted = false;

	public enum Status { Empty, Fill};
	Status status;

	Board board;

	int x;
	public int X {
		get {
			return x;
		}
	}

	int z;
	public int Z {
		get {
			return z;
		}
	}

	public Tile(Board board, int x, int z) {
		this.board = board;
		this.x = x;
		this.z = z;
	}
		
	void Update () {
		if (GetComponent<Renderer>().isVisible && Input.GetMouseButtonUp (0)) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = CameraOperator.InvertMouseY (camPos.y);
			IsTargeted = CameraOperator.selection.Contains (camPos);
		}

		if (IsTargeted)
			GetComponent<Renderer>().material.color = Color.green;
		else
			GetComponent<Renderer>().material.color = Color.white;

	}
}

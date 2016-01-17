using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	bool IsSelected = false;

	bool isAvailable;

	public enum ObjType {Cage, Dinosaur, Booth, Other};
	ObjType type;

	public bool IsAvailable {
		get { return isAvailable; }
		set { isAvailable = value; }
	}

	Board board;

	float x;
	public float X {
		get {return x;}
	}

	float z;
	public float Z {
		get {return z;}
	}

	public Tile(Board board, float x, float z) {
		this.board = board;
		this.x = x;
		this.z = z;
	}
		
	void Start () {
		this.isAvailable = true;
	}

	void Update () {

		/* Pour la selection des tuiles
		 * if (GetComponent<Renderer>().isVisible && Input.GetMouseButtonUp (0)) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = CameraOperator.InvertMouseY (camPos.y);
			IsSelected = CameraOperator.selection.Contains (camPos);
		}
		*/

		if (isAvailable)
			GetComponent<Renderer>().material.color = Color.white;
		else
			GetComponent<Renderer>().material.color = Color.red;

	}
}


using UnityEngine;
using System.Collections;

public class CameraOperator : MonoBehaviour {
	public Texture2D selectionHighLight = null;
	public static Rect selection = new Rect(0, 0, 0, 0);
	static float x = 810, y = 323;
	Vector2 startPos =  new Vector2(x, InvertMouseY(y));
	Vector2 width = new Vector2(23, 23);

	// Use this for initialization
	void CheckCamera () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
			y += 22; 

		if(Input.GetKeyDown(KeyCode.DownArrow))
			y -= 22; 

		if(Input.GetKeyDown(KeyCode.RightArrow))
			x += 22; 

		if(Input.GetKeyDown(KeyCode.LeftArrow))
			x -= 22;
			
		startPos =  new Vector2(x, InvertMouseY(y));
		selection = new Rect(startPos, width);
	}

	void OnGUI () {
			GUI.color = new Color (1, 1, 1, 0.5f);
			GUI.DrawTexture (selection, selectionHighLight);
	}

	public static float InvertMouseY(float y) {
		return Screen.height - y;
	}

	// Update is called once per frame
	void Update () {
		CheckCamera ();
	}
		
}

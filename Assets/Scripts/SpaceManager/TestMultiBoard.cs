using UnityEngine;
using System.Collections;

public class TestMultiBoard : MonoBehaviour {

	GameObject [] board;

	// Use this for initialization
	void Start () {
		board = new GameObject[4];
		InstantiateBoards ();
	}

	void InstantiateBoards() {
		for (int i = 0; i < 4; i++) {
			board [i] = new GameObject ("Board_P" + (i + 1));
			board [i].transform.parent = transform;
			board [i].AddComponent<BoardManager> ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}

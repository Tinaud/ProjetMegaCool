using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMultiBoard : MonoBehaviour {

	GameObject [] board;

	// Use this for initialization
	void Start () {
		board = new GameObject[4];
		InstantiateBoards ();
	}

	void InstantiateBoards() {
		for (int i = 0; i < 4; i++) {
			board [i] = new GameObject ("Player_" + (i+1));
			board [i].transform.parent = transform;
			board [i].AddComponent<ParcManager> ();
			board[i].GetComponent<ParcManager>().setID(i + 1);
		}
	}

    public GameObject[] getBoard()
    {
        return board;
    }
}

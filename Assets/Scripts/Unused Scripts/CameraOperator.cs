using UnityEngine;
using System.Collections;
using System;

public class CameraOperator : MonoBehaviour
{
    public Texture2D selectionHighLight = null;
    public static Rect selection = new Rect(0, 0, 0, 0);
    Vector2 startPos;
	public GameObject cube;
	public int playerNo = 1;
	ParcManager parc;
    Vector2 width = new Vector2(22, 22);

    void Start()  {
    }

    // Use this for initialization
    void CheckCamera()
    {
		startPos = new Vector2(Input.mousePosition.x-width.x/2, InvertMouseY(Input.mousePosition.y)-width.y/2);
        selection = new Rect(startPos, width);
    }

    void OnGUI()
    {
        GUI.color = new Color(1, 1, 1, 0.5f);
        GUI.DrawTexture(selection, selectionHighLight);
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCamera();
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			GameObject b = GameObject.Find ("Player_" + playerNo);
			parc = b.GetComponent<ParcManager> ();
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Vector3 tilePos = hit.collider.transform.position;
				Debug.Log(tilePos.ToString());

				/*if (parc.PurchaseAt ((int)Mathf.Round (tilePos.x * 2), (int)Mathf.Round (tilePos.z * 2), (int) SpaceRules.Type.CageEmpty)) {
					GameObject obj = (GameObject)Instantiate (cube, tilePos, Quaternion.identity);
				}*/
			}

		}
    }

	float Round (float f) {
		return (float)Math.Round (f,MidpointRounding.AwayFromZero)/2f;
	}

}

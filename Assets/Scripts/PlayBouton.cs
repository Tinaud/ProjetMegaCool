using UnityEngine;
using System.Collections;

public class PlayBouton : MonoBehaviour
{
    private bool toggleGUI;
    public int nbJoueur;

    // Use this for initialization
    void Start()
    {
        toggleGUI = false;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x + .5f, transform.localScale.y + .5f, transform.localScale.z);
    }

    void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x - .5f, transform.localScale.y - .5f, transform.localScale.z);
    }

    void OnMouseDown()
    {
        toggleGUI = true;
    }

    void OnGUI ()
    {
        if (toggleGUI == true)
        {
            GUI.Label(new Rect(60, 175, 300, 200), "<color=green><size=20>Combien de joueurs?</size></color>");
            if (GUI.Button(new Rect(100, 200, 100, 25), "<color=yellow>2 joueur</color>"))
            {
                nbJoueur = 2;
                Application.LoadLevel("Game");
                toggleGUI = false;
            }
                if (GUI.Button(new Rect(100, 225, 100, 25), "<color=yellow>3 joueur</color>"))
            {
                nbJoueur = 3;
                Application.LoadLevel("Game");
                toggleGUI = false;
            }
            if (GUI.Button(new Rect(100, 250, 100, 25), "<color=yellow>4 joueur</color>"))
            {
                nbJoueur = 4;
                Application.LoadLevel("Game");
                toggleGUI = false;
            }
        }
    }
}

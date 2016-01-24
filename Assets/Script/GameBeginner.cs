using UnityEngine;
using System.Collections;

public class GameBeginner : MonoBehaviour {

    bool gamelife = true;
    public GameObject pnlMenu;
    // Use this for initialization
    void Start () {

    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamelife)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        gamelife = false;
        GameObject.Find("Astronot").GetComponent<Astronoth>().movv = false;
        pnlMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        gamelife = true;
        GameObject.Find("Astronot").GetComponent<Astronoth>().movv = true;
        pnlMenu.SetActive(false);
    }

}

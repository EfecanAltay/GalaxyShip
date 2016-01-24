using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

  
	}
    public void StartGame() {
        Application.LoadLevel(1);
    }
    public void GoMenu() {
        Application.LoadLevel(0);
    }
    public void getir(GameObject go) {
        go.transform.SetParent(gameObject.transform);
        go.transform.SetParent(GameObject.Find("PnlOptions").transform);

    }
    public void ActivePanel(GameObject go) {
        go.SetActive(true);
    }
    public void DeActivePanel(GameObject go)
    {
        go.SetActive(false);
    }
    public void getGameMenu() {

    }
}

using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public GameObject bg1;
    public GameObject bg2;

    // Use this for initialization
    void Start () {
        setBg();
	}
    public void setBg() {
        for (int i = 0; i < 100; i++) {
            Instantiate(bg1, new Vector3(i*Random.Range(-2,2), i * Random.Range(-2, 2), 10), new Quaternion());
        }
        for (int i = 0; i < 300; i++)
        {
            Instantiate(bg2, new Vector3(i * Random.Range(-2, 2), i * Random.Range(-2, 2), 10), new Quaternion());
        }
    }
}

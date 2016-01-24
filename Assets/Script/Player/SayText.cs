using UnityEngine;
using System.Collections;

public class SayText : MonoBehaviour {

    public float time;
    float maxTime = 5;
    TextMesh text;
    public bool active = true ;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<TextMesh>();
	}
    public void Reset() {
        time = 0;
    }
	// Update is called once per frame
	void Update () {
        if (text.text != "" && active )
        {
            if (time < maxTime)
                time += Time.deltaTime;
            else
            {
                time = 0;
                text.text = "";
            }
        }
	}
}

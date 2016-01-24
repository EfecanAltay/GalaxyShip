
using UnityEngine;

public class Weapon : MonoBehaviour {

    float size;
    public Sprite background;
   
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = background; 
    }
}
using UnityEngine;

public class jetpack : MonoBehaviour {
    public float speed;
    public Sprite background;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = background;
    }
}

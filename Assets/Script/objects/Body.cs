using UnityEngine;
using System.Collections.Generic;

public class Body : MonoBehaviour {

    public List<GameObject> weapons;
    public List<GameObject> jetpacks;
    jetpack jetpack;
    public Sprite background;
    List<weaponPos> WeaponPositions;
    List<jetpackPos> JetpackPositions;

    int MaxJetpackSize = 1;
    int MaxWeaponSize = 3;

    float speed = 0f;
  
    public float GetSpeed()
    {
        return speed;
    }
    void Start() {

        weapons = new List<GameObject>();

        gameObject.GetComponent<SpriteRenderer>().sprite = background;

        setJetpackPos(new Vector2[] {new Vector2(-0.268f, 0) });
        setWeaponPos(new Vector2[] {new Vector2(0.202f,0),new Vector2(0.058f, 0.128f),new Vector2(0.058f, -0.128f) });
        addWeapon();
        addJetpack();
        
    }
    public void addWeapon() {
        foreach (weaponPos item in WeaponPositions)
        {
            if (!item.full)
            {
                GameObject go = Instantiate(Resources.Load("Prefabs/Weapon", typeof(GameObject)) as GameObject);
                go.transform.SetParent(this.transform);
                weapons.Add(go);
                go.transform.localPosition = item.pos;
                go.transform.rotation = gameObject.transform.rotation;
                item.full = true;
                break;
            }
        }
    }
    public void addJetpack()
    {
        foreach (jetpackPos item in JetpackPositions)
        {
            if (!item.full) {
                GameObject go = Instantiate(Resources.Load("Prefabs/Cat", typeof(GameObject)) as GameObject);
                go.transform.SetParent(this.transform);
                jetpacks.Add(go);
                speed += go.gameObject.GetComponent<jetpack>().speed;
                go.transform.localPosition = item.pos;
                go.transform.rotation = gameObject.transform.rotation;
                item.full = true;
                break;
            }

        }
    }
    public void setWeaponPos( Vector2[] list )
    {
        WeaponPositions = new List<weaponPos>();
        
        foreach (Vector2 item in list)
        {
            if (WeaponPositions.Count < MaxWeaponSize)
                WeaponPositions.Add(new weaponPos(item));
            else {
                break;
            }
        }
    }
    public void setJetpackPos(Vector2[] list)
    {
        JetpackPositions = new List<jetpackPos>();
        foreach (Vector2 item in list)
        {
            if (JetpackPositions.Count < MaxJetpackSize)
                JetpackPositions.Add(new jetpackPos(item));
            else {
                break;
            }
        }
    }

    class weaponPos {
        public bool full = false;
        public Vector2 pos;
        public weaponPos(Vector2 pos)
        {
            this.pos = pos;
        }
    }
    class jetpackPos
    {
        public bool full = false;
        public Vector2 pos;
        public jetpackPos(Vector2 pos){
            this.pos = pos;
        }
    }
}

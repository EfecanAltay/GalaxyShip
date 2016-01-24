using UnityEngine;
using System.Collections;

public class Astronoth : MonoBehaviour {


    //sayText Silme eklenecektir
    GameObject cam;
    public GameObject sayTextGo;

    TextMesh saytext;
    string text;
    float smoot;
    float speed = 0;
    public float maxSpeed = 2f;
    public float maxWalkSpeed = 1f;

    public float minZoom = 2;
    public float zoom = 0;
    public float maxZoom = 3;

    bool flying = false;
    bool shipping = false;

    public bool movv = false;
    bool chatMode=false ;

    string chatString ;


    // Use this for initialization

   public Rigidbody2D rb; 

    void Start()
    {
        zoom = minZoom;
        cam = GameObject.Find("Main Camera");
        saytext = sayTextGo.GetComponent<TextMesh>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    public void ShipControl()
    {

    }
    void Update()
    {
        Zoom();
        cam.GetComponent<Camera>().orthographicSize = (zoom / 3f);
        cam.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        sayTextGo.transform.position = gameObject.transform.position + new Vector3(.2f,.2f);

        if (movv)
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

        if (!chatMode && !shipping)
        {
            MoveControl();
        }
        else if (!chatMode && shipping) {
            ControlShip();
        }
        else if(chatMode)
        {
            WriteChat();
        }
        ChatControl();
        

        if (!flying) {walk();}
        else{ fly();}

    }

    void ControlShip()
    {
        
    }
    
    void walk() {
        gameObject.transform.parent.transform.Translate(transform.right * speed * Time.deltaTime );
    }
    void fly() {
        rb.AddForce(gameObject.transform.right * speed);
    }
    public void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (zoom < maxZoom)
                zoom++;

        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (zoom > minZoom)
                zoom--;
        }

    }

    public void MoveControl()
    {
        if (flying)
        {
            if (Input.GetKey(KeyCode.W) && movv)
            {

                if (speed < maxSpeed)
                    speed += .01f;
            }
            else
            {
                if (speed > 0)
                    speed -= .2f;
                else
                {
                    speed = 0f;
                }
            }
        }
        else {
            if (Input.GetKey(KeyCode.W) && movv)
            {
                speed = maxWalkSpeed - Mathf.Sin(Time.time*20);
              
            }
            else
            {
                speed = 0;
            }
        }
    }
    public void ChatControl() {
        if (Input.GetKeyDown(KeyCode.T)) {
            chatMode = true;
            saytext.text = "Say:";
            sayTextGo.GetComponent<SayText>().active = false;
        }
    }
    public void WriteChat()
    {
        if (Input.anyKey) {
            string key = Input.inputString;
            //if (Input.GetKeyDown(KeyCode.Backspace) && saytext.text.Length > 0) {
            //    for (int i = 0; i < saytext.text.Length ; i++)                         //Silme Hatalı
            //    {
            //        saytext.text += saytext.text[i] ;
            //    }
            //}
        if (Input.GetKeyDown("return"))
            {
                chatMode = false;
                sayTextGo.GetComponent<SayText>().active = true;
                sayTextGo.GetComponent<SayText>().Reset();
            }
            saytext.text += Input.inputString;
        }
    }
    void FireControl()
    {
        if (Input.GetButton("fire"))
        {

        }

    }
    void OnTriggerStay2D(Collider2D col) {

        if (col.gameObject.tag == "Zemin")
        {
            flying = false;
            rb.Sleep();
            rb.WakeUp();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ship")
            saytext.text = "";
        if (col.gameObject.tag == "Zemin")
            flying = true;
    }
}

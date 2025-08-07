using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UnpoweredWire : MonoBehaviour
{

    public bool connected = false;
    public bool lightOn = false;
    public GameObject unpoweredLight;
    public Sprite onSprite;
    public Sprite offSprite;
    public GameObject draggableWire;

    // Start is called before the first frame update
    void Start()
    {
        unpoweredLight.GetComponent<Image>().sprite = offSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (connected == true)
        {
            Debug.Log("Power up the light here");
            unpoweredLight.GetComponent<Image>().sprite = onSprite; 
            connected = false;
            lightOn = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Debug.Log("Tag match!");
            collision.gameObject.transform.position = new Vector3(transform.position.x -20, transform.position.y, transform.position.z);
            Debug.Log("Translation successful");
            draggableWire.GetComponent<WireDragger>().enabled = false;
            connected = true;
        }
    }
}

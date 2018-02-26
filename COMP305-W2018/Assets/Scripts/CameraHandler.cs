using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Area1")
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
        }
        else if (collision.gameObject.tag == "Area2")
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
        }
        else if (collision.gameObject.tag == "Area3")
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
        }
    }
}

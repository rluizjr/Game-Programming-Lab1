using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area3Camera : MonoBehaviour {

    public Transform playerPosition;

    private float moveH;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);

        if (GetComponent<Camera>().enabled)
        {
            moveH = Input.GetAxis("Horizontal");

            if (moveH > 0 && GetComponent<Camera>().orthographicSize > 1f)
            {
                GetComponent<Camera>().orthographicSize -= 0.05f;
            }
            else if (moveH < 0 && GetComponent<Camera>().orthographicSize < 13f)
            {
                GetComponent<Camera>().orthographicSize += 0.05f;
            }

            //GetComponent<Camera>().orthographicSize += Input.GetAxis("Horizontal");
        }
    }
}

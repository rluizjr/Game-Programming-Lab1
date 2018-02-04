using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {
    public GameObject player;
    public Sprite color;

    private SpriteRenderer render;

    // Use this for initialization
    void Start () {
        render = player.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        render.sprite = color;
    }
}

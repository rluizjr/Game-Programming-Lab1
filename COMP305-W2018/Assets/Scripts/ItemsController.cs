using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour {

    public bool collected = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collected = true;
        }

        if (collision.gameObject.tag == "Limit")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

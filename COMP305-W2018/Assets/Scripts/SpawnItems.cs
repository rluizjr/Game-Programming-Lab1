using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnItems : MonoBehaviour {

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    public Text timer;

    private int count = 0;
    private bool lab5Scene = true;
    private GameObject lastItem;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnItem", 0.0f, 1.0f);
    }

    private void Update()
    {
        if (count == 30 && lab5Scene && !lastItem.GetComponent<SpriteRenderer>().enabled) {
            SceneManager.LoadScene("Lab5Score");
            lab5Scene = false;
        }
    }

    void SpawnItem()
    {
        if (count >= 30 || !lab5Scene) {
            return;
        }

        timer.text = (int.Parse(timer.text) - 1).ToString();

        Items item = (Items) Mathf.Round(Random.Range(1, 3.99f));

        lastItem = Instantiate(getItem(item), new Vector3(UnityEngine.Random.Range(-8, 8), 5, 0), Quaternion.identity);
        lastItem.transform.parent = gameObject.transform;

        count++;
    }

    public GameObject getItem(Items item)
    {
        switch (item)
        {
            case Items.Item1:
                return item1;

            case Items.Item2:
                return item2;

            case Items.Item3:
                return item3;
        }

        return item1;
    }
}

public enum Items
{
    Item1 = 1,
    Item2 = 2,
    Item3 = 3
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountItems : MonoBehaviour {

    public Text item1;
    public Text item2;
    public Text item3;

    private int it1 = 0;
    private int it2 = 0;
    private int it3 = 0;

    // Use this for initialization
    void Start () {
        var items = GameObject.Find("Items");

        foreach(Transform item in items.transform)
        {
            if (item.tag == "Item1" && item.GetComponentInParent<ItemsController>().collected)
            {
                it1++;
            }
            else if (item.tag == "Item2" && item.GetComponentInParent<ItemsController>().collected)
            {
                it2++;
            }
            else if (item.tag == "Item3" && item.GetComponentInParent<ItemsController>().collected)
            {
                it3++;
            }
        }

        item1.text = it1.ToString();
        item2.text = it2.ToString();
        item3.text = it3.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

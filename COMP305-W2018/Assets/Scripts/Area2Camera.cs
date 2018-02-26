using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area2Camera : MonoBehaviour {

    public Transform playerPosition;
    public Transform playerMoveThreshold;
    public Transform playerMoveThreshold2;

    // Use this for initialization
    void Start () {
        playerMoveThreshold = transform.GetChild(0);
        playerMoveThreshold = transform.GetChild(1);
    }
	
	// Update is called once per frame
	void Update () {
        bool move = playerPosition.position.x < playerMoveThreshold.position.x || playerPosition.position.x > playerMoveThreshold2.position.x;

        if (move && GetComponent<Camera>().enabled)
        {
            this.transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerMoveThreshold.position, new Vector3(playerMoveThreshold.position.x, playerMoveThreshold.position.y + 100, playerMoveThreshold.position.z));
        Gizmos.DrawLine(playerMoveThreshold.position, new Vector3(playerMoveThreshold.position.x, playerMoveThreshold.position.y - 100, playerMoveThreshold.position.z));

        Gizmos.DrawLine(playerMoveThreshold2.position, new Vector3(playerMoveThreshold2.position.x, playerMoveThreshold2.position.y + 100, playerMoveThreshold2.position.z));
        Gizmos.DrawLine(playerMoveThreshold2.position, new Vector3(playerMoveThreshold2.position.x, playerMoveThreshold2.position.y - 100, playerMoveThreshold2.position.z));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public PlayerController player;

    public bool reloading;
    public bool tryActive;

	// Use this for initialization
	void Start () {
        reloading = false;
    }

    private void Update()
    {
        if(player != null)
            tryActive = (Input.GetButton("A " + player.area.controllerID)) || player.area.controllerID > GameCore.Instance.playerCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player = other.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            player = null;
    }

    public void Swap(Portal other)
    {
        reloading = true;
        Area tempArea = player.area;
        player.area = other.player.area;
        other.player.area = tempArea;

        player.area.player = player;
        other.player.area.player = other.player;


        Vector3 tempPos = player.transform.position;
        player.transform.position = other.player.transform.position;
        other.player.transform.position = tempPos;
        /*
        int tempID = tempPlayer.playerID;



        player.playerID = other.player.playerID;
        other.player.playerID = tempID;

        player = other.player;
        other.player = tempPlayer;
        */
        GameCore.Instance.UpdateUI();

        StartCoroutine(SwapAnim());
    }

    IEnumerator SwapAnim()
    {
        yield return new WaitForSeconds(2f);
        reloading = false;
    }
}

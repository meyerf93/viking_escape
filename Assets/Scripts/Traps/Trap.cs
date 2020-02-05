using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    protected PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.transform.GetComponent<PlayerController>();
            ActivateTrap();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            LeaveTrap();
            player = null;
        }
    }

    public virtual void LeaveTrap()
    {

    }


    public virtual void ActivateTrap()
    {
        // Default Ex : 
        GameCore.Instance.ModifieHealth(-1);
    }
}

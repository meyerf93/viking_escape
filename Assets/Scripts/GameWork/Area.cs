using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    public int id;
    public PlayerController player;
    public int controllerID;
    public SpriteRenderer rendererArea;

    public void UpdateRendererArea(Color colorControler)
    {
        rendererArea.color = colorControler;
    }
    public void UpdateRendererAreaDefault()
    {
        rendererArea.color = Color.clear ;
    }



}

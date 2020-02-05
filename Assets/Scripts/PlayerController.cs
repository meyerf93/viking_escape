using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    //public int playerID;
    public Area area;

    Animator anim;

    bool pressedH;
    bool pressedV;
    public Vector3 lastValidPos;

    CustomAnim cAnim;

	// Use this for initialization
	void Start () {
        //anim = GetComponentInChildren<Animator>();
        cAnim = GetComponentInChildren<CustomAnim>();
        StartCoroutine(UpdateValidePos());

    }
	
	// Update is called once per frame
	void Update () {
        if (Pause.paused) return;

        Move();
        ChangeControls();
        
    }

    IEnumerator UpdateValidePos()
    {
        while (true)
        {
            if (Physics.Raycast(transform.position+0.1f*Vector3.up, Vector3.down, 0.2f)) // 1 << 7
            {
                lastValidPos = transform.position;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Hole")
        {
            transform.position = lastValidPos;
            GameCore.Instance.ModifieHealth(-1);
        }
    }

    void Move()
    {
        float forward = Input.GetAxis("Vertical " + area.controllerID);
        float right = Input.GetAxis("Horizontal " + area.controllerID);
        Vector3 direction = Vector3.forward * forward + Vector3.right * right;
        GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime + GetComponent<Rigidbody>().velocity.y*Vector3.up;
        transform.LookAt(transform.position + direction);

        if (forward != 0 || right != 0)
            cAnim.Walk();
        else
            cAnim.StopWalk();
        //anim.SetBool("walk", forward != 0 || right != 0);
    }
    void ChangeControls()
    {
        //haut
        if (Input.GetAxis("Vertical2 " + area.controllerID) < -0.8f && !pressedV)
        {
            if(area.id == 3)
                GameCore.Instance.SwapPlayer(3, 1);
            else if(area.id == 4)
                GameCore.Instance.SwapPlayer(4, 2);
            //else
                //you can't
            pressedV = true;
        }
        //bas
        else if (Input.GetAxis("Vertical2 " + area.controllerID) > 0.8f && !pressedV)
        {
            if (area.id == 1)
                GameCore.Instance.SwapPlayer(1, 3);
            else if (area.id == 2)
                GameCore.Instance.SwapPlayer(2, 4);
            //else
            //you can't
            pressedV = true;
        }
        else if (Input.GetAxis("Vertical2 " + area.controllerID) == 0f)
            pressedV = false;

        //droite
        if (Input.GetAxis("Horizontal2 " + area.controllerID) < -0.8f && !pressedH)
        {
            if (area.id == 1)
                GameCore.Instance.SwapPlayer(1, 2);
            else if (area.id == 3)
                GameCore.Instance.SwapPlayer(3, 4);
            //else
            //you can't
            pressedH = true;
        }
        //gauche
        else if (Input.GetAxis("Horizontal2 " + area.controllerID) > 0.8f && !pressedH)
        {
            if (area.id == 4)
                GameCore.Instance.SwapPlayer(4, 3);
            else if (area.id == 2)
                GameCore.Instance.SwapPlayer(2, 1);
            //else
            //you can't
            pressedH = true;
        }
        else if (Input.GetAxis("Horizontal2 " + area.controllerID) == 0f)
            pressedH = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnim : MonoBehaviour {

    public bool walking;
    Coroutine co;

    List<Quaternion> defaultPosition = new List<Quaternion>();
    // Use this for initialization
    void Start () {

        transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").Rotate(0, 0, 80);
        transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Rotate(0, 0, 80);

        defaultPosition.Add(transform.Find("Root").transform.rotation);
        defaultPosition.Add(transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").transform.rotation);
        defaultPosition.Add(transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").transform.rotation);

        defaultPosition.Add(transform.Find("Root").Find("Hips").Find("UpperLeg_L").transform.rotation);
        defaultPosition.Add(transform.Find("Root").Find("Hips").Find("UpperLeg_R").transform.rotation);
        defaultPosition.Add(transform.Find("Root").Find("Hips").Find("UpperLeg_L").Find("LowerLeg_L").transform.rotation);
        defaultPosition.Add(transform.Find("Root").Find("Hips").Find("UpperLeg_R").Find("LowerLeg_R").transform.rotation);
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void Walk()
    {
        if (!walking)
        {
            walking = true;
            co = StartCoroutine(Walking());
        }
    }

    public void StopWalk()
    {
        if (walking)
        {
            walking = false;
            StopCoroutine(co);
        }
    }

    public void DefaultPos()
    {
        //transform.Find("Root").transform.position = defaultPosition[0].position;
        transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").transform.rotation = defaultPosition[1];
        transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").transform.rotation = defaultPosition[2];

        transform.Find("Root").Find("Hips").Find("UpperLeg_L").transform.rotation = defaultPosition[3];
        transform.Find("Root").Find("Hips").Find("UpperLeg_R").transform.rotation = defaultPosition[4];
        transform.Find("Root").Find("Hips").Find("UpperLeg_L").Find("LowerLeg_L").transform.rotation = defaultPosition[5];
        transform.Find("Root").Find("Hips").Find("UpperLeg_R").Find("LowerLeg_R").transform.rotation = defaultPosition[6];
    }

    IEnumerator Walking()
    {
        DefaultPos();
        int dist = 30;
        while (walking)
        {
            for (int i = 0; i < dist; i++)
            {
                //transform.Find("Root").Translate(new Vector3(0,-0.002f,0));
                yield return null;
                transform.Find("Root").Find("Hips").Find("UpperLeg_L").Rotate(0, 1, 0);
                transform.Find("Root").Find("Hips").Find("UpperLeg_L").Find("LowerLeg_L").Rotate(0, 0, -1);
                transform.Find("Root").Find("Hips").Find("UpperLeg_R").Rotate(0, -1, 0);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").Rotate(0, 1, 0);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Rotate(0, -1, 0);
                //transform.Find("Root").Find("Hips").Find("UpperLeg_R").Find("LowerLeg_R").Rotate(0, 0, -1);
            }
            for (int i = 0; i < dist; i++)
            {
                //transform.Find("Root").Translate(new Vector3(0, 0.002f, 0));
                yield return null;
                transform.Find("Root").Find("Hips").Find("UpperLeg_L").Rotate(0, -1, 0);
                transform.Find("Root").Find("Hips").Find("UpperLeg_L").Find("LowerLeg_L").Rotate(0, 0, 1);
                transform.Find("Root").Find("Hips").Find("UpperLeg_R").Rotate(0, 1, 0);
                //transform.Find("Root").Find("Hips").Find("UpperLeg_R").Find("LowerLeg_R").Rotate(0, 0, 1);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").Rotate(0, -1, 0);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Rotate(0, 1, 0);
            }

            for (int i = 0; i < dist; i++)
            {
                //transform.Find("Root").Translate(new Vector3(0, -0.002f, 0));
                yield return null;
                transform.Find("Root").Find("Hips").Find("UpperLeg_L").Rotate(0, -1, 0);
                //transform.Find("Root").Find("Hips").Find("UpperLeg_L").Find("LowerLeg_L").Rotate(0, 0, 1);
                transform.Find("Root").Find("Hips").Find("UpperLeg_R").Rotate(0, 1, 0);
                transform.Find("Root").Find("Hips").Find("UpperLeg_R").Find("LowerLeg_R").Rotate(0, 0, -1);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").Rotate(0, -1, 0);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Rotate(0, 1, 0);
            }
            for (int i = 0; i < dist; i++)
            {
                //transform.Find("Root").Translate(new Vector3(0, 0.002f, 0));
                yield return null;
                transform.Find("Root").Find("Hips").Find("UpperLeg_L").Rotate(0, 1, 0);
                //transform.Find("Root").Find("Hips").Find("UpperLeg_L").Find("LowerLeg_L").Rotate(0, 0, -1);
                transform.Find("Root").Find("Hips").Find("UpperLeg_R").Rotate(0, -1, 0);
                transform.Find("Root").Find("Hips").Find("UpperLeg_R").Find("LowerLeg_R").Rotate(0, 0, 1);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_L").Find("Shoulder_L").Rotate(0, 1, 0);
                transform.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Rotate(0, -1, 0);
            }
        }
    }
}

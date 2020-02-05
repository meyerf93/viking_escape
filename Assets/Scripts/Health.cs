using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] GameObject[] healthPoints;
    public int startHealth;
    public int health;

    private void Start()
    {
        health = startHealth;
        ChangeHealth(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ChangeHealth(-1);
        if (Input.GetKeyDown(KeyCode.D))
            ChangeHealth(+1);
    }

    public void ChangeHealth(int modif)
    {
        health = Mathf.Max(0, Mathf.Min(health+modif, startHealth));

        for (int i = 0; i < startHealth; i++)
        {
            healthPoints[i].SetActive(i < health);
        }

        if (health == 0)
            GameCore.Instance.GameOver();
    }
}

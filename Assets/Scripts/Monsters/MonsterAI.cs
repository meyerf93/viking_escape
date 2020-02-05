using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {

    [SerializeField] GameObject area;

    public Item[] itemTreasure;

    public int health;
    public int strength;
    public float attackRange;
    public float agressiveRange;
    public float areaRange;
    public float atkTimer;
    public float moveSpeed;

    bool atkReady;
    bool playerAtAtkRange;
    bool outOfArea;
    bool playerAtWarningRange;
    Rigidbody body;

    PlayerController player;
    CustomAnim anim;

    // Use this for initialization
    void Start() {
        atkReady = true;
        body = GetComponent<Rigidbody>();
        anim = GetComponent<CustomAnim>();
    }

    // Update is called once per frame
    void Update() {

        UpdateBehaviour();

        if (outOfArea)
        {
            MoveToCenter();
            anim.Walk();
        } else if (playerAtAtkRange && player != null)
        {
            MoveToPlayer();
            anim.Walk();
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                TryAttack();
        } else if (playerAtWarningRange && player != null)
        {
            LookAtPlayer();
            anim.StopWalk();

        }
        else if (Vector3.Distance(area.transform.position, transform.position) > 1f)
        {
            MoveToCenter();
            anim.Walk();
        } else
        {
            anim.StopWalk();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player = other.transform.GetComponent<PlayerController>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            player = null;
    }

    void UpdateBehaviour()
    {
        if (player != null)
        {
            playerAtWarningRange = true;
            playerAtAtkRange = Vector3.Distance(player.transform.position, transform.position) <= agressiveRange;
        }
    }

    void MoveToCenter()
    {
        body.velocity = (area.transform.position - transform.position).normalized * moveSpeed/2f;
        transform.LookAt(area.transform.position);
    }

    void MoveToPlayer()
    {
        body.velocity = (player.transform.position - transform.position).normalized * moveSpeed;
        transform.LookAt(player.transform.position);
    }
    void LookAtPlayer()
    {
        transform.LookAt(player.transform.position);
    }

    void TryAttack()
    {
        if (atkReady)
        {
            atkReady = false;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        GameCore.Instance.ModifieHealth(-strength);
        yield return new WaitForSeconds(atkTimer);
        atkReady = true;
    }

    public void Damages(int qty, PlayerController player)
    {
        health -= qty;
        if (health <= 0)
        {
            print("DEAD! Drop ?");
            foreach(Item item in itemTreasure)
            {
                player.GetComponent<Inventory>().AddItem(item);
            }
            Destroy(gameObject);
        }
    }
}

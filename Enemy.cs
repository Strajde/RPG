using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    // Logic
    public float triggerLenth = 1;
    public float chaseLength = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    protected Transform playerTranform;
    protected Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTranform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    protected virtual void FixedUpdate()
    {
        //Czy gracz jest w zasi?gu?
        if (Vector3.Distance(playerTranform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTranform.position, startingPosition) < triggerLenth)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTranform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }

        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //sprawd? czy nachodzi - kopia z collidable
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            // czyszczenie warto?ci tabeli
            hits[i] = null;
        }

    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GrantXp(xpValue);
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}

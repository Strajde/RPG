using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : Enemy
{
    public float distance = 0.25f;
    public float hideCooldown = 1.0f;
    public int summonLength = 3;
    public float summonCooldown = 2.0f;

    private float[] fireballSpeed = { 2.0f, -2.0f };
    private float hideLastCount = 0;
    private float summonLastCount = 0;
    private bool isVisible = true;

    public Transform[] fireballs;
    public GameObject[] summoned;
    public Renderer rend;

    private void Update()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            fireballs[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * fireballSpeed[i]) 
                * distance, Mathf.Sin(Time.time * fireballSpeed[i]) * distance, 0);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        HideShow();
        Summon();
    }

    protected override void Death()
    {
        base.Death();
        GameManager.instance.winMenuAnim.SetTrigger("Show");
    }

    private void HideShow()
    {
        rend = GetComponent<Renderer>();

        if (Time.time - hideLastCount > hideCooldown)
        {
            hideLastCount = Time.time;
            if (isVisible)
            {
                rend.enabled = true;
                isVisible = false;
            }

            else
            {
                rend.enabled = false;
                isVisible = true;
            }
        }
    }

    private void Summon()
    {
        if (Vector3.Distance(playerTranform.position, startingPosition) < summonLength)
            if (Time.time - summonLastCount > summonCooldown)
            {
                summonLastCount = Time.time;
                Instantiate(summoned[Random.Range(0,summoned.Length)], transform.position + new Vector3(Random.Range(-0.3f, 0.3f), 
                    Random.Range(-0.3f, 0.3f), 0), Quaternion.Euler(0, 0, 0));
            }
    }
}

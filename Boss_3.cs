using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3 : Enemy
{
    public GameObject summoned;

    public int summonLength = 3;
    public float cooldown = 2.0f;

    private float lastCount = 0;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Summon();
    }

    private void Summon()
    {
        if (Vector3.Distance(playerTranform.position, startingPosition) < summonLength)
            if (Time.time - lastCount > cooldown)
        {
            lastCount = Time.time;
            Instantiate(summoned, transform.position + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0), Quaternion.Euler(0, 0, 0));
        }
    }
}

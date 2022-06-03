using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : Enemy
{
    public Renderer rend;
    public float cooldown = 1.0f;
    private float lastCount = 0;
    private bool isVisible = true;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        HideShow();
    }

    protected virtual void HideShow()
    {
        rend = GetComponent<Renderer>();

        if (Time.time - lastCount > cooldown)
        {
            lastCount = Time.time;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable
{
    public string[] messages;

    protected float cooldown = 5.0f;
    protected float lastShout;
    protected int count = 0;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name != "Player")
            return;
        if (Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            ShowCountedText();
        }
    }

    protected virtual void ShowCountedText()
    {
        GameManager.instance.ShowText(messages[count], 15, Color.white, transform.position + new Vector3(0, 0.2f, 0), Vector3.zero, cooldown);
        count++;
        if (count == messages.Length)
            count = 0;
    }
}

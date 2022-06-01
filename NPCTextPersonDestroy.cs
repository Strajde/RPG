using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPersonDestroy : NPCTextPerson
{
    protected override void ShowCountedText()
    {
        GameManager.instance.ShowText(messages[count], 15, Color.white, transform.position + new Vector3(0, 0.2f, 0), Vector3.zero, cooldown);
        count++;
        if (count == messages.Length)
            Destroy(gameObject);
        
    }
}

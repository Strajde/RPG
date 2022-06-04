using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPersonDestroyFinal : NPCTextPerson
{
    public GameObject summoned;

    protected override void ShowCountedText()
    {
        GameManager.instance.ShowText(messages[count], 15, Color.white, transform.position + new Vector3(0, 0.2f, 0), Vector3.zero, cooldown);
        count++;
        if (count == messages.Length)
            SummonFinalBoss();
            Destroy(gameObject);

    }

    private void SummonFinalBoss()
    {
        Instantiate(summoned, GameObject.Find("BossSpawnPoint").transform.position, Quaternion.Euler(0, 0, 0));
    }
}

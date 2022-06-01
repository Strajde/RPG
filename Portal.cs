using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{

    public static Portal instance;
    public string[] sceneNames;
    public Animator bossPortalOpen;

    private void Awake()
    {
        instance = this;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            // Teleport the player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}

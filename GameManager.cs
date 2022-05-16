using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//nosi za nami na plecach wszystko co chcemy, �eby by�o niesione i nie przepad�o
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        //nie tw�rz dubli GameManagera
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }


        // przy kazdej nowej scenie wykonuje si�:
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    // public weapon weapon; ...
    //po co tworzy� nowy jak mozna nosi� zawsze ze sob�
    public FloatingTextManager floatingTextManager;

    //Logic
    public int pesos;
    public int experience;

    // wszelkie odwo�ania do FloatingTextu s� zawsze do GameManagera. Nie do FloatingTextManagera
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void SaveState()
    {
        string save = "";

        save += "0" + "|";
        save += pesos.ToString() + "|";
        save += experience.ToString() + "|";
        save += "0";

        //zapisuje string z danymi i nadaje mu klucz SaveState
        PlayerPrefs.SetString("SaveState", save);
        Debug.Log("Save");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        //rozdziela zapisany string i zamienia go w tabel�, kt�r� p�niej rozdaje zmiennym
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // Change weapon level

        Debug.Log("Load");

    }
}

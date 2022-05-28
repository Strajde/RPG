using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//nosi za nami na plecach wszystko co chcemy, ¿eby by³o niesione i nie przepad³o
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        //nie twórz dubli GameManagera
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }


        // przy kazdej nowej scenie wykonuje siê:
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
    public Weapon weapon;
    //po co tworzyæ nowy jak mozna nosiæ zawsze ze sob¹
    public FloatingTextManager floatingTextManager;

    //Logic
    public int pesos;
    public int experience;

    // wszelkie odwo³ania do FloatingTextu s¹ zawsze do GameManagera. Nie do FloatingTextManagera
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Upgreade weapon
    public bool TryUpgreadeWeapon()
    {
        //czy broñ jest na max lvlu?
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        //czy masz hajs?
        if (pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgreadeWeapon();
            return true;
        }

        return false;
    }

    public void SaveState()
    {
        string save = "";

        save += weapon.weaponLevel + "|";
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
        //rozdziela zapisany string i zamienia go w tabelê, któr¹ pó¿niej rozdaje zmiennym
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        weapon.SetWeaponLevel(int.Parse(data[0]));
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        Debug.Log("Load");

    }
}

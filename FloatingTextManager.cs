using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        //FloatingText w tej funkcji adresuje si� jako floatingText, ten ma zmienn�  "public Text txt;", Text jest klas� unity i ma zmienn� text do zmiany tekstu.
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        //UI korzysta z innego skalowania �wiata (World Space). Nadaj� tu takie jakie jest w kamerze main - (Screen Space), �eby tekst wy�wietla� si� w zale�no�ci od tego co jest wy�wietlane na ekranie a nie od wielko�ci instancji.
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    // Sprawdza czy jest dost�pny jakis ukryty Floating text, je�li nie to go tworzy
    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            //i dodaje do listy na potem
            floatingTexts.Add(txt);
        }

        return txt;
    }
}

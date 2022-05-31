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
        //FloatingText w tej funkcji adresuje siê jako floatingText, ten ma zmienn¹  "public Text txt;", Text jest klas¹ unity i ma zmienn¹ text do zmiany tekstu.
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        //UI korzysta z innego skalowania œwiata (World Space). Nadajê tu takie jakie jest w kamerze main - (Screen Space), ¿eby tekst wyœwietla³ siê w zale¿noœci od tego co jest wyœwietlane na ekranie a nie od wielkoœci instancji.
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    // Sprawdza czy jest dostêpny jakis ukryty Floating text, jeœli nie to go tworzy
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

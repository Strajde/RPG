using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Text fields
    public Text levelText, hitpointText, pesosText, upgardeCostText, xpText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite, weaponSprite;
    public RectTransform xpBar;

    //Character selection

    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            //Jeœli skoñczy³y siê w tym kierunku postaci
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChange();
        }
        else
        {
            currentCharacterSelection--;

            //Jeœli skoñczy³y siê w tym kierunku postaci
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChange();
        }
    }

    private void OnSelectionChange()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    //Weapon upgrade
    public void OnUpgradeClick()
    { 
        
    }

    //Updated the character information
    public void UpdateMenu()
    {
        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[0];
        upgardeCostText.text = "NOT IMPLEMENTED";

        //Meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();
        levelText.text = "NOT IMPLEMENTED";

        //Xp Bar
        xpText.text = "NOT IMPLEMENETED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);

    }


}

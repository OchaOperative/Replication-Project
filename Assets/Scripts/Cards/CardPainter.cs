using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPainter : MonoBehaviour
{
    [SerializeField] CardColors cardColors;

    public void PaintCard(GameObject card, CardInformation cardInfo)
    {
        // Set Bottom.
        card.transform.GetChild(0).GetComponent<Image>().color = CardBottomColor(cardInfo);

        // Set icon.
        card.transform.GetChild(1).GetComponent<Image>().sprite = cardInfo.icon;

        // Set flavour text.
        card.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardInfo.flavourText;

        // Set description text.
        card.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = cardInfo.cardDescription;
    }

    private Color CardBottomColor(CardInformation cardInfo)
    {
        switch (cardInfo.CardType)
        {
            case CardInformation.CardTypes.Weapon:
                return cardColors.weapon;
            case CardInformation.CardTypes.Buff:
                return cardColors.buff;
            case CardInformation.CardTypes.Effect:
                return cardColors.effect;
            default:
                Debug.LogError("Missing card type!");
                return Color.magenta;
        }
    }
}
        
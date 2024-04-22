using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPainter : MonoBehaviour
{
    [SerializeField] CardColors cardColors;

    [SerializeField] CardInformation[] infoArray;

    public void PaintCard(GameObject card)
    {
        CardInformation cardInfo = infoArray[Random.Range(0, infoArray.Length)];

        // Set Bottom.
        card.transform.GetChild(2).GetComponent<Image>().color = CardBottomColor(cardInfo);

        // Set icon.
        card.transform.GetChild(3).GetComponent<Image>().sprite = cardInfo.icon;

        // Set flavour text.
        card.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = cardInfo.flavourText;

        // Set description text.
        card.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = cardInfo.cardDescription;

        // Set name text.
        card.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = cardInfo.cardName;

        card.GetComponent<CardSelector>().cardInfo = cardInfo;
    }

    // Color the bottom bar on the card to indicate what type of card it is.
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
        
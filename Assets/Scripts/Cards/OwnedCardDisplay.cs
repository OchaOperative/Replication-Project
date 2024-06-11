using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnedCardDisplay : MonoBehaviour
{
    private List<GameObject> ownedCards = new List<GameObject>();

    public GameObject cardIconPrefab;

    public CardInformation testInfo;

    // Adds the icon for a card a player has selcted to the display at the topp of the screen.
    public void AddOwnedCard(CardInformation info)
    {
        GameObject newCard = Instantiate(cardIconPrefab, gameObject.transform);

        ownedCards.Add(newCard);

        RectTransform cardTransform = newCard.GetComponent<RectTransform>();

        // Space out the cards.
        cardTransform.anchoredPosition = new Vector2(0 - (cardTransform.sizeDelta.x * (ownedCards.Count - 1)) * 1.1f, 0); 

        newCard.transform.GetChild(1).GetComponent<Image>().sprite = info.icon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCards : MonoBehaviour
{
    private List<GameObject> ownedCards = new List<GameObject>();

    public GameObject cardIconPrefab;

    public CardInformation testInfo;

    public void AddOwnedCard(CardInformation info)
    {
        GameObject newCard = Instantiate(cardIconPrefab, gameObject.transform);

        ownedCards.Add(newCard);

        RectTransform cardTransform = newCard.GetComponent<RectTransform>();

        cardTransform.anchoredPosition = new Vector2(0 - (cardTransform.sizeDelta.x * (ownedCards.Count - 1)) * 1.1f, 0); // Space out the cards.

        newCard.GetComponent<Image>().sprite = info.icon;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddOwnedCard(testInfo);
        }
    }
}

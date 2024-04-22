using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    public CardInformation cardInfo;
    public OwnedCardDisplay displayManager;
    public CardSelectionHandler selectionManager;

    private void Start()
    {
        displayManager = GameObject.Find("PlayerOwnedCards").GetComponent<OwnedCardDisplay>();
        selectionManager = GameObject.Find("CardSelector").GetComponent<CardSelectionHandler>();
    }

    public void SelectCard()
    {
        displayManager.AddOwnedCard(cardInfo);

        selectionManager.ClearCards();
    }
}

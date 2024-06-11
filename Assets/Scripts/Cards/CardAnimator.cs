using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAnimator : MonoBehaviour
{
    [SerializeField] private List<GameObject> otherCards = new List<GameObject>();

    private Vector2 originalSize;
    private Vector2 originalPosition;

    private Vector2 slideOutTarget;

    private void Start()
    {
        // Reduce size of outline to hide it.
        transform.GetChild(0).localScale = Vector2.one * 0.8f;

        // Store the original Vectors of the card to reset back to if interrupted.
        originalSize = transform.localScale;
        originalPosition = GetComponent<RectTransform>().localPosition;
    }

    /// <summary>
    /// Increases the size of a card when moused over.
    /// </summary>
    public void Open()
    {
        // Reset size of card back to closed.
        GetComponent<RectTransform>().localScale = originalSize;

        // Increase card size to desired size.
        transform.LeanScale(Vector2.one * 1.1f, 0.1f);

        // Increase size of outline until visible;
        transform.GetChild(0).LeanScale(Vector2.one * 1.02f, 0.1f);
    }

    /// <summary>
    /// Decreases the size of a card back to normal when mouse isn't over anymore.
    /// </summary>
    public void Close()
    {
        // Reset size of card back to open.
        GetComponent<RectTransform>().localScale = originalSize * 1.1f;

        // Decrease card size to desired size.
        transform.LeanScale(originalSize, 0.1f);

        // Decrease size of outline until hidden.
        transform.GetChild(0).LeanScale(Vector2.one * 0.8f, 0.1f);
    }

    /// <summary>
    /// Triggers other cards to slide aside when a card is moused over.
    /// </summary>
    public void MoveCardsOut()
    {
        Transform cardHolder = transform.parent.transform;

        // Compile all other cards that are not the currently selected one into a list.
        for (int i = 0; i < cardHolder.childCount; i++)
        {
            if (i != transform.GetSiblingIndex())
            {
                otherCards.Add(cardHolder.GetChild(i).gameObject);
            }
        }

        // For each of the cards in the list, make them move themselves either to the left or the right depending on if they are to the left or the right on the screen.
        for (int i = 0; i < otherCards.Count; i++)
        {
            // Make the card about to be moved reset it's position to its starting position before it moves, incase its current tween is being interrupted.
            otherCards[i].GetComponent<RectTransform>().localPosition = otherCards[i].GetComponent<CardAnimator>().originalPosition;

            if (otherCards[i].transform.GetSiblingIndex() < transform.GetSiblingIndex())
            {
                otherCards[i].GetComponent<CardAnimator>().Shift(true);
            }
            else
            {
                otherCards[i].GetComponent<CardAnimator>().Shift(false);
            }
        }

        // Clear the list so it can be written over next time it is used.
        otherCards.Clear();
    }

    public void MoveCardsIn()
    {
        Transform cardHolder = transform.parent.transform;

        // Compile all other cards that are not the recently un-selected one into a list.
        for (int i = 0; i < cardHolder.childCount; i++)
        {
            if (i != transform.GetSiblingIndex())
            {
                otherCards.Add(cardHolder.GetChild(i).gameObject);
            }
        }

        // For each of the cards in the list, make them move themselves either to the left or the right depending on if they are to the left or the right on the screen.
        for (int i = 0; i < otherCards.Count; i++)
        {
            // Make the card about to be moved reset it's position to its starting position before it moves, incase its current tween is being interrupted.
            otherCards[i].GetComponent<RectTransform>().localPosition = otherCards[i].GetComponent<CardAnimator>().slideOutTarget;

            if (otherCards[i].transform.GetSiblingIndex() < transform.GetSiblingIndex())
            {
                otherCards[i].GetComponent<CardAnimator>().Shift(false);
            }
            else
            {
                otherCards[i].GetComponent<CardAnimator>().Shift(true);
            }

        }

        // Clear the list so it can be written over next time it is used.
        otherCards.Clear();
    }


    /// <summary>
    /// Makes a card slide away/towards another card based on whether or not it is moused over.
    /// </summary>
    /// <param name="left">Is a certain card to the left of the currently moused over card.</param>
    public void Shift(bool left)
    {
        // Gather the current position and size so that they can be used to move the card proportionally.
        float pos = GetComponent<RectTransform>().localPosition.x;
        float size = GetComponent<RectTransform>().sizeDelta.x;

        // Set whether the card will be moving left or right.
        if (left)
        {
            slideOutTarget = new Vector2(pos - size * 0.1f, 0);
        }
        else
        {
            slideOutTarget = new Vector2(pos + size * 0.1f, 0);
        }

        //Move the card.
        transform.LeanMoveLocal(slideOutTarget, 0.1f);
    }
}

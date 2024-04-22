using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardSelectionHandler : MonoBehaviour
{
    [Range(1, 4)]
    public int cardAmount;

    [SerializeField] private GameObject cardPrefab;

    private int startIndex;

    private int currentCardAmount;

    public GameObject[] onscreenCards;

    private CardPainter painter;

    public List<GameObject> cards = new List<GameObject>();


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        currentCardAmount = 0;

        onscreenCards = new GameObject[cardAmount];

        painter = GetComponent<CardPainter>();
    }

    private void Update()
    {
        // If the amount of cards in the inspector changes, rewrite all the cards with the correct amount.
        if (currentCardAmount != cardAmount)
        {
            ClearCards();

            currentCardAmount = cardAmount;

            SpawnCards();
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // The cards are spawned in 'pairs', using the for loop to iterate through each cards position
    // and ensure the correct amount of cards in the correct arrangement are placed.
    private void SpawnCards()
    {
        // This makes the cards spawn on alternating sides.
        bool leftIndex = true;

        // Reference for modifying each card individually as it is spawned.
        GameObject newCard;

        // If there is an odd number of cards to be spawned then there will be one central card surrounded by
        // other cards, if there is an even number then there will be two that take up the middle space.
        //
        // This index is used so that there doesn't have to be duplicates of the same code for pretty much the
        // same function. By using it we can offset the below 'i' for loop by 1 we can make it so that cards spawn slightly
        // offset to the side making the cards spawn evenly across the screen.

        if (cardAmount % 2 == 0)
        {
            startIndex = 1;
        }
        else
        {
            startIndex = 0;
        }

        // This array is storing the cards currently shown on screen, allows us to destroy them easily if cards need rerolling.
        onscreenCards = new GameObject[cardAmount];

        // The index is needed because the for loop 'i' doesn't always start at 0, and we need to sequentially add each card
        // to the array as we are creating them.
        int arrayIndex = 0;

        for (int i = startIndex; i < cardAmount; i++)
        {
            // If the card amount is odd and it's the first card, then we can place that in the middle and then continue as
            // normal afterwards as if it was an even number of cards.
            if (i == 0 && startIndex == 0)
            {
                newCard = Instantiate(cardPrefab, gameObject.transform);
                newCard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                
                // We increment here because we are artificially completing a 'pair' with only one card already.
                i++;

                // Add all of the correct info.
                painter.PaintCard(newCard);

                onscreenCards[0] = newCard;
                arrayIndex++;
            } // To be brutally honest I can't remember why. It's been a long day and if it's not here it doesn't work.
            else if (i % 2 == startIndex)
            {
                newCard = Instantiate(cardPrefab, gameObject.transform);

                // Each card is set to either be the correct distance on the left or the right respectively using i.
                if (leftIndex)
                {
                    newCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 - (210 * i), 0);

                    i--;
                }
                else
                {
                    newCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0 + (210 * i), 0);
                }

                // Add it to the array.
                onscreenCards[arrayIndex] = newCard;

                // Add all of the correct info.
                painter.PaintCard(newCard);

                // And all that's left to do is to increment the array index and swap the side we want the next card to spawn on
                // ready for the next one to spawn.
                arrayIndex++;
                leftIndex = !leftIndex;
            }

        }

        // Order the cards descending in the hierarchy from left to right on screen.

        onscreenCards = onscreenCards.OrderBy(c => c.GetComponent<RectTransform>().localPosition.x).ToArray();

        for (int i = 0; i < onscreenCards.Length; i++)
        {
            onscreenCards[i].transform.SetSiblingIndex(i);
        }
    }

    /// <summary>
    /// Removes all cards currently shown on screen.
    /// </summary>
    public void ClearCards()
    {
        foreach (GameObject card in onscreenCards)
        {
            Destroy(card);
        }
    }
}

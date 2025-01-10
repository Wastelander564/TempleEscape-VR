using System.Collections;
using UnityEngine;

public class MemoryScript : MonoBehaviour
{
    [System.Serializable]
    public class Card
    {
        public GameObject button;  // Button representing the card
        public GameObject image;   // Image child of the button
        public string cardID;      // Unique identifier for matching
    }

    public Card[] cards;                 // Array of all cards
    public bool activationSignal = false; // Bool signal for ProgressScript
    private Card firstSelectedCard;
    private Card secondSelectedCard;

    public void OnCardSelected(GameObject selectedCard)
    {
        Card clickedCard = GetCardByButton(selectedCard);
        if (clickedCard == null || clickedCard == firstSelectedCard) return;

        clickedCard.image.SetActive(true);

        if (firstSelectedCard == null)
        {
            firstSelectedCard = clickedCard;
        }
        else
        {
            secondSelectedCard = clickedCard;
            StartCoroutine(CheckMatch());
        }
    }

    private Card GetCardByButton(GameObject button)
    {
        foreach (Card card in cards)
        {
            if (card.button == button)
                return card;
        }
        return null;
    }

    private IEnumerator CheckMatch()
    {
        if (firstSelectedCard.cardID == secondSelectedCard.cardID)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(firstSelectedCard.button);
            Destroy(secondSelectedCard.button);

            // Explicitly set button references to null
            firstSelectedCard.button = null;
            secondSelectedCard.button = null;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            firstSelectedCard.image.SetActive(false);
            secondSelectedCard.image.SetActive(false);
        }

        firstSelectedCard = null;
        secondSelectedCard = null;

        // Check if all cards are destroyed
        if (AllCardsDestroyed())
        {
            activationSignal = true; // Set the signal to true
            Debug.Log("All cards destroyed! Signal activated.");
        }
    }

    private bool AllCardsDestroyed()
    {
        foreach (Card card in cards)
        {
            if (card.button != null)
            {
                Debug.Log($"Card with ID {card.cardID} is still active.");
                return false;
            }
        }
        Debug.Log("All cards are destroyed.");
        return true;
    }
}

using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Deck
{
    public int total = 52;
    // All 52 cards. Built in code by RebuildDeck 
    public List<Card> cardList;

    public Deck()
    {
        RebuildDeck();
    }

    // Throw away the old list and create a new full 52-card deck.
    public void RebuildDeck()
    {
        cardList = new List<Card>();
        char[] suites = { 'H', 'C', 'S', 'D' };
        string[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K"};

        foreach (char suite in suites)
        {
            foreach (string rank in ranks)
            {
                // num = points for blackjack (10 for face cards, 1 for ace in the card data).
                int num = -1;
                if (rank == "J" || rank == "Q" || rank == "K" || rank == "10")
                {
                    num = 10;
                }
                else if (rank == "A")
                {
                    num = 1;
                }
                else
                {
                    num = rank[0] - '0';
                }

                cardList.Add(new Card(suite, rank, num));
            }
        }

        total = cardList.Count;
    }

    // Mark every card as not dealt yet. Call this before each new hand so the deck never runs out.
    public void ResetUsedCards()
    {
        if (cardList == null)
            return;
        for (int i = 0; i < cardList.Count; i++)
            cardList[i].used = false;
    }

    // Pick a random card that is not used yet, then mark it used.
    public Card DrawRandomUnused()
    {
        if (cardList == null || cardList.Count == 0)
            return null;

        int unusedCount = 0;
        for (int i = 0; i < cardList.Count; i++)
        {
            if (!cardList[i].used)
                unusedCount++;
        }

        if (unusedCount == 0)
        {
            Debug.LogError("Deck: no unused cards left. ResetUsedCards should run before each new deal.");
            return null;
        }

        const int maxAttempts = 10000;
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int indx = UnityEngine.Random.Range(0, cardList.Count);
            Card card = cardList[indx];
            if (!card.used)
            {
                card.used = true;
                return card;
            }
        }

        Debug.LogError("Deck: random draw failed unexpectedly.");
        return null;
    }
}

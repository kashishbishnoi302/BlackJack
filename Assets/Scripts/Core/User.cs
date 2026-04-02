using UnityEngine;
using System.Collections.Generic;

// Shared by player and dealer: a list of cards and the hand total (score).
public class User
{
    public int score;
    public List<Card> cards;

    public User()
    {
        this.score = 0;
        this.cards = new List<Card>();
    }

    // Adds up the hand. Aces can count as 11 if the total stays at 21 or below.
    private int ComputeBlackjackValueFromCards()
    {
        if (cards == null || cards.Count == 0)
            return 0;

        int sum = 0;
        int aceCount = 0;
        foreach (var c in cards)
        {
            if (IsAce(c))
                aceCount++;
            else
                sum += c.num;
        }

        sum += aceCount;

        // Turn aces from 1 into 11 when it fits (each step adds 10).
        for (int i = 0; i < aceCount; i++)
        {
            if (sum + 10 <= 21)
                sum += 10;
        }

        return sum;
    }

    private bool IsAce(Card c)
    {
        if (c == null)
            return false;
        if (c.num == 1)
            return true;
        return c.rank == "A";
    }

    public void Hit()
    {
        Debug.Log("pressed hit button");
    }

    public void Reset()
    {
        cards.Clear();
        this.score = 0;
    }

    public void GiveCard(Card card)
    {
        this.cards.Add(card);
        score = ComputeBlackjackValueFromCards();
    }
    
}

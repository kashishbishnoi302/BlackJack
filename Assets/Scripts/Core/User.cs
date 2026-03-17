using UnityEngine;
using System.Collections.Generic;
public class User
{
    public int score;
    public List<Card> cards; // user cards
    public User()
    {
        this.score = 0;
        this.cards = new List<Card>();
    }
    
    // hit button:
    public void Hit()
    {
        Debug.Log("pressed hit button");
        // get a random card and pass to the display function in DisplayCard script:
        
    }

    public void Reset()
    {
        cards.Clear();
        this.score = 0;
    }

    public void GiveCard(Card card)
    {
        this.cards.Add(card);
        // access the value and add to the score
        int value = card.num;
        score += value;
    }
    
    // stand button:
    public void Stand()
    {
        
    }
    
    
    
    
}
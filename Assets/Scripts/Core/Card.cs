using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Card
{
    public char suite;
    // Card name for pictures, e.g. H10, CK.
    public string rank;
    // Points stored on the card (ace is 1 here; the hand total fixes aces to 11 when it helps).
    public int num;
    // True after this card has been dealt from the deck.
    public bool used;
    public Card(char suite, string rank, int num)
    {
        this.suite = suite;
        this.rank = rank;
        this.num = num;
    }
}

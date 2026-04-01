using UnityEngine;
using System.Collections.Generic;


[System.Serializable] public class Deck
{
    public int total = 52;
    public List<Card> cardList;

    public Deck()
    {
        this.cardList = new List<Card>(); 
        char[] suites = { 'H', 'C', 'S', 'D' };
        string[] values = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K"};
        
        foreach(char suite in suites)
        {
            foreach (string value in values)
            {
                int num = -1;
                if (value == "J" || value == "Q" || value == "K" || value == "10")
                {
                    num = 10;
                } else if (value == "A")
                {
                    num = 1;
                }
                else
                {
                    num = value[0] - '0';
                }

                Card card = new Card(suite, value, num);
                cardList.Add(card);
            }
        }

        total = cardList.Count;
    }
    
    
}

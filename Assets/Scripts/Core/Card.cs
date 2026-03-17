using UnityEngine;

[System.Serializable] public class Card
{
    public char suite;
    public char value;
    public int num;
    public bool used;
    public Card(char suite, char value, int num)
    {
        this.suite = suite;
        this.value = value;
        this.num = num;
    }
}



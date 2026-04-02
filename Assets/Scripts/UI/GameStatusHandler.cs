using UnityEngine;
using TMPro;

// Big win/lose message at the end of a hand.
public class GameStatusHandler : MonoBehaviour
{
    public TMP_Text resultText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowResult(bool playerWon)
    {
        if (playerWon == true)
        {
            resultText.text = "YOU WON!";
        }
        else
        {
            resultText.text = "YOU LOST!";
        }
    }
}

using UnityEngine;
using TMPro;
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

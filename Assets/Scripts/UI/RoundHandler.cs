using UnityEngine;
using TMPro;

// Shows the current round number in the UI.
public class RoundHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text roundText;

    public void changeRound(int round)
    {
        roundText.text = round.ToString();
    }
}

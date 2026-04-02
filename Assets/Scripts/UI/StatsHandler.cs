using UnityEngine;
using TMPro;

// End-of-game panel: how many rounds, wins, and losses.
public class StatsHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text roundText;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text lossText;

    public void ShowStats(int rounds, int wins, int losses)
    {
        roundText.text = rounds.ToString();
        winText.text = wins.ToString();
        lossText.text = losses.ToString();
    }
}

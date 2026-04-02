using UnityEngine;
using TMPro;

// Shows a number on screen for player or dealer total. Grabs TMP once in Awake.
public class DisplayScore : MonoBehaviour
{
    private TextMeshProUGUI _tmp;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    public void ShowScore(int score)
    {
        _tmp.text = score.ToString();
    }
}

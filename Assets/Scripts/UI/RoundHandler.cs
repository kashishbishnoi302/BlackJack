using UnityEngine;
using TMPro;
public class RoundHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text roundText;
    public void changeRound(int round)
    {
        roundText.text = round.ToString();
    }
    
}

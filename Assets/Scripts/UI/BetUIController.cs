using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Text fields for money and bet, plus showing or hiding the bet slider panel.
public class BetUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text userMoney;
    [SerializeField] private TMP_Text dealerMoney;
    [SerializeField] private TMP_Text userBet;
    [SerializeField] private TMP_Text dealerBet;
    [SerializeField] private GameObject BetSlider;

    // Refresh labels from MoneyManager (call after bet changes).
    public void ResetBetUI()
    {
        userMoney.text = MoneyManager.Instance.UserMoney.ToString();
        dealerMoney.text = MoneyManager.Instance.DealerMoney.ToString();
        userBet.text = MoneyManager.Instance.UserBet.ToString();
        if (dealerBet != null)
            dealerBet.text = "—";
    }

    public void ActivateBetSlider()
    {
        BetSlider.SetActive(true);
    }

    public void DeActivateBetSlider()
    {
        BetSlider.SetActive(false);
    }
}

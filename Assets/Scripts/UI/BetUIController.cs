using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BetUIController : MonoBehaviour
{
   [SerializeField] private TMP_Text userMoney;
   [SerializeField] private TMP_Text dealerMoney;
   [SerializeField] private TMP_Text userBet;
   [SerializeField] private TMP_Text dealerBet;
   [SerializeField] private MoneyManager moneyManager;
   [SerializeField] private GameObject BetSlider;

   
   public void ResetBetUI()
   {
      Debug.Log("resetting");
      userMoney.text = MoneyManager.Instance.UserMoney.ToString();
      dealerMoney.text = MoneyManager.Instance.DealerMoney.ToString();
      Debug.Log(MoneyManager.Instance.UserBet);
      userBet.text = MoneyManager.Instance.UserBet.ToString();
      dealerBet.text = MoneyManager.Instance.DealerBet.ToString();
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

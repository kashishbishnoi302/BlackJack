using UnityEngine;
using UnityEngine.UI;
public class ConfirmButtonHandler : MonoBehaviour
{

    [SerializeField] private BetUIController betUIController;
    [SerializeField] private Button dealbutton;
    public void OnClickHandler()
    {
        Debug.Log("confirm clicked");
        MoneyManager.Instance.BetConfirmed = true;
        // remove the slider , reset UI and activate the deal button
        betUIController.DeActivateBetSlider();
        betUIController.ResetBetUI();

        dealbutton.interactable = true;


    }
    
}

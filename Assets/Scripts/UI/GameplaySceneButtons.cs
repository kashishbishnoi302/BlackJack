using UnityEngine;
using UnityEngine.UI;

// Button clicks from the game screen are handled here. Link each button to these methods in the Inspector.
public class GameplaySceneButtons : MonoBehaviour
{
    [SerializeField] private Main main;
    [SerializeField] private BetUIController betUIController;
    [SerializeField] private Button dealButton;
    [SerializeField] private Button standButton;
    [SerializeField] private Button hitButton;
    [SerializeField] private Button nextRoundButton;

    public void OnDealClicked()
    {
        main.Initiate();
        dealButton.interactable = false;
        standButton.interactable = true;
        hitButton.interactable = true;
    }

    public void OnHitClicked()
    {
        main.PlayerHit();
    }

    public void OnStandClicked()
    {
        main.Stand();
    }

    public void OnConfirmBetClicked()
    {
        MoneyManager.Instance.BetConfirmed = true;
        betUIController.DeActivateBetSlider();
        betUIController.ResetBetUI();
        dealButton.interactable = true;
    }

    public void OnNextRoundClicked()
    {
        main.ResetUI();
        main.StartRound();
        nextRoundButton.gameObject.SetActive(false);
    }
}

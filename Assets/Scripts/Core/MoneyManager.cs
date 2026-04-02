using UnityEngine;

// One place for player money, house money, and the current bet.
// Only one of these should exist in the scene (extra copies get deleted).
[DefaultExecutionOrder(-100)]
public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    public int UserMoney { get; set; } = 100;
    public int DealerMoney { get; set; } = 100;
    public int UserBet { get; set; }
    public int MinBet { get; set; } = 5;
    public int MaxBet { get; set; } = 100;

    public bool BetConfirmed { get; set; }

    [SerializeField] private BetUIController betUIController;
    [SerializeField] private SliderHandler sliderHandler;

    void Awake()
    {
        // If another MoneyManager is already there, destroy this duplicate.
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("MoneyManager: duplicate instance — destroying this component's GameObject.", this);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    // Show the bet slider so the player can pick how much to bet.
    public void chooseBet()
    {
        betUIController.ActivateBetSlider();
        sliderHandler.ResetSlider();
    }

    // Player won: add bet to player, take it from the house.
    public void handleUserWin()
    {
        UserMoney += UserBet;
        DealerMoney -= UserBet;
    }

    // Player lost: take bet from player, give it to the house.
    public void handleUserLose()
    {
        UserMoney -= UserBet;
        DealerMoney += UserBet;
    }
}

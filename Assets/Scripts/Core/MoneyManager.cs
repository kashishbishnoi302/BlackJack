using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int UserMoney { get; set; } = 100;
    public int DealerMoney { get; set; } = 100;
    public int DealerBet { get; set; } = 20; // fixed
    public int UserBet { get; set; }         // user will decide
    public int MinBet { get; set; } = 5;
    public int MaxBet { get; set; } = 100;

    public bool BetConfirmed { get; set; } = false;

    public static MoneyManager Instance; // can be used anywhere without any exports -> only one instance will be created -> same instance will be used everywhere

    [SerializeField] private BetUIController betUIController;
    [SerializeField] private SliderHandler sliderHandler;
    void Awake()
    {
        Instance = this;
    }

    public void chooseBet()
    {
        // show the slider to choose bet:
        betUIController.ActivateBetSlider();
        sliderHandler.ResetSlider();
    }
    
    public void handleUserWin()
    {
        UserMoney += DealerBet;
        DealerMoney -= DealerBet;
    }

    public void handleUserLose()
    {
        UserMoney -= UserBet;
        DealerMoney += UserBet;
    }
    
    
   
}

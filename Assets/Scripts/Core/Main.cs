using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    [SerializeField] private Deck deck; // unity creates an object of Deck class and stores it in this field
    // which means deck ka constructor call ho jayega apne aap ->cardList will be created
    public List<Card> cardList; // all the cards
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    [SerializeField] private DisplayCards displayPlayerCards;
    [SerializeField] private DisplayCards displayDealerCards;
    [SerializeField] private DisplayScore displayPlayerScore;
    [SerializeField] private DisplayScore displayDealerScore;
    [SerializeField] private GameStatusHandler gameStatusHandler;
    [SerializeField] private GameObject gameStatusObj;
    //[SerializeField] private MoneyManager moneyManager; -> will not be visible in Inspector
    [SerializeField] private Button dealButton;
    [SerializeField] private Button standButton;
    [SerializeField] private Button hitButton;
    [SerializeField] private BetUIController betUIController;
    [SerializeField] private Button NextRoundButton;
    [SerializeField] private RoundHandler roundHandler;
    [SerializeField] private StatsHandler statsHandler;
    public int round;
    public bool isRoundOver;
    public bool isGameOn;
    public bool playerWon;
    public int wins;
    public int losses;
    
    
    void Start()
    {
        cardList = deck.cardList;
        StartRound();
        round = 1;
    }
    
    public void StartRound()
    {
        // ask user to pick a bet:
        MoneyManager.Instance.chooseBet(); // specific to player
    }

    public void Initiate()
    {
        isGameOn = true;
        // distribute 2 random cards to player and dealer:
        Card card1 = PickRandomCard();
        player.GiveCard(card1);
        Card card2 = PickRandomCard();
        player.GiveCard(card2);
        Card card3 = PickRandomCard();
        dealer.GiveCard(card3);
        Card card4 = PickRandomCard();
        dealer.GiveCard(card4);
        
        // display the score of player and dealer:
        displayPlayerScore.ShowScore(player.score);
        displayDealerScore.ShowScore(dealer.score);
        
        // display the cards of player
        displayPlayerCards.Display(card1);
        displayPlayerCards.Display(card2);
        
        // display the cards of dealer
        displayDealerCards.Display(card3);
        displayDealerCards.Display(card4);
        
        
    }
    
    
    public Card PickRandomCard()
    {
        // pick 1 random card from the deck and give it to user
        bool found = false;
        Card card = null;
        while (!found)
        {
            int indx = UnityEngine.Random.Range(0, 48);
            card = cardList[indx];
            if(card.used == false)
            {
                card.used = true;
                found = true;
            }
        }
        
        return card;
    }
    

    public void gameStatus()
    {
        // dealer can take cards till it has score less than 17 
        if (player.score > 21)
        {
            playerWon = false;
            isRoundOver = true;
        } else if (player.score == 21 || dealer.score > 21)
        {
            playerWon = true;
            isRoundOver = true;
        } else if (dealer.score >= 17)
        {
            playerWon = player.score > dealer.score;
            isRoundOver = true;
        }

        if (isRoundOver)
        {
            settleRound();
        }
        
    }

    public void settleRound()
    {
        // activate gameStatus 
        gameStatusObj.SetActive(true);
        gameStatusHandler.ShowResult(playerWon);
        hitButton.interactable = false;
        standButton.interactable = false;
        // update user and dealer bet
        if (playerWon)
        {
            MoneyManager.Instance.handleUserWin();
            wins++;
        }
        else
        {
            MoneyManager.Instance.handleUserLose();
            losses++;
        }

        // check if game is over:
        if (isGameOver())
        {
            // show stats
            statsHandler.gameObject.SetActive(true);
            statsHandler.ShowStats(round, wins, losses);
            
        }
        else
        {
            // update the UI
            betUIController.ResetBetUI();
            
            // show the button to proceed to next round
            NextRoundButton.gameObject.SetActive(true);
        }
    }
    
    public void ResetUI()
    {
        // disable the buttons, remove gamestatus , cards from screen
        gameStatusObj.SetActive(false);
        displayPlayerCards.ClearCards();
        displayDealerCards.ClearCards();
        
        // reset the scores and cards of player and dealer
        player.Reset();
        dealer.Reset();

        displayPlayerScore.ShowScore(player.score);
        displayDealerScore.ShowScore(dealer.score);
        
        // reset round:
        round++;
        roundHandler.changeRound(round);
        isRoundOver = false;
        playerWon = false;
    }

    public bool isGameOver()
    {
        if (MoneyManager.Instance.UserMoney < MoneyManager.Instance.MinBet || MoneyManager.Instance.DealerMoney < MoneyManager.Instance.DealerBet)
        {
            return true;
        }
        
        return false;
    }
    
    public void PlayerHit()
    {
       Card card = PickRandomCard();
       player.GiveCard(card);
       displayPlayerScore.ShowScore(player.score);
       displayPlayerCards.Display(card);
       gameStatus();
    }
    
    // Doubt:  removed Hit() because of the difference in scripts of display score and display cards, how to reuse?
    public void DealerHit()
    {
        Card card = PickRandomCard();
        dealer.GiveCard(card);
        displayDealerScore.ShowScore(dealer.score);
        displayDealerCards.Display(card);
        gameStatus();
    }

    public void Stand()
    {
        if (dealer.score < 17 )
        {
            DealerHit();
        }
        else
        {
            gameStatus();
            
        }

    }
    
   
    
    
    

    
}

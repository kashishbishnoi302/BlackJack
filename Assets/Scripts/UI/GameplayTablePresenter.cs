using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Updates what you see on the table: cards, scores, win/lose text, buttons, next round.
// It does not decide rules or money; the round controller does.
public class GameplayTablePresenter
{
    private readonly DisplayCards _playerCards;
    private readonly DisplayCards _dealerCards;
    private readonly DisplayScore _playerScore;
    private readonly DisplayScore _dealerScore;
    private readonly GameStatusHandler _gameStatusHandler;
    private readonly GameObject _gameStatusRoot;
    private readonly TextMeshProUGUI _questionMark;
    private readonly Button _hitButton;
    private readonly Button _standButton;
    private readonly BetUIController _betUI;
    private readonly Button _nextRoundButton;
    private readonly RoundHandler _roundHandler;
    private readonly StatsHandler _statsHandler;

    public GameplayTablePresenter(
        DisplayCards displayPlayerCards,
        DisplayCards displayDealerCards,
        DisplayScore displayPlayerScore,
        DisplayScore displayDealerScore,
        GameStatusHandler gameStatusHandler,
        GameObject gameStatusObj,
        TextMeshProUGUI questionMark,
        Button hitButton,
        Button standButton,
        BetUIController betUIController,
        Button nextRoundButton,
        RoundHandler roundHandler,
        StatsHandler statsHandler)
    {
        _playerCards = displayPlayerCards;
        _dealerCards = displayDealerCards;
        _playerScore = displayPlayerScore;
        _dealerScore = displayDealerScore;
        _gameStatusHandler = gameStatusHandler;
        _gameStatusRoot = gameStatusObj;
        _questionMark = questionMark;
        _hitButton = hitButton;
        _standButton = standButton;
        _betUI = betUIController;
        _nextRoundButton = nextRoundButton;
        _roundHandler = roundHandler;
        _statsHandler = statsHandler;
    }

    public void ShowInitialDeal(int playerScore, int dealerUpValue, Card playerCard1, Card playerCard2, Card dealerUp, Card dealerHole)
    {
        _playerScore.ShowScore(playerScore);
        _dealerScore.ShowScore(dealerUpValue);

        _playerCards.Display(playerCard1);
        _playerCards.Display(playerCard2);

        _dealerCards.Display(dealerUp);
        _dealerCards.Display(dealerHole);
        _dealerCards.CoverHoleCardWithHidden();
    }

    public void UpdatePlayerScore(int score)
    {
        _playerScore.ShowScore(score);
    }

    public void AddPlayerCard(Card card)
    {
        _playerCards.Display(card);
    }

    public void RevealHoleClearQuestionMarkAndShowDealerScore(int dealerScore)
    {
        _dealerCards.RevealHoleCard();
        if (_questionMark != null)
            _questionMark.text = "";
        _dealerScore.ShowScore(dealerScore);
    }

    public void AppendDealerCardAndScore(Card card, int dealerScore)
    {
        _dealerScore.ShowScore(dealerScore);
        _dealerCards.Display(card);
    }

    public void PresentRoundEnd(int dealerScore, bool playerWon)
    {
        _dealerCards.RevealHoleCard();
        _dealerScore.ShowScore(dealerScore);
        _gameStatusRoot.SetActive(true);
        _gameStatusHandler.ShowResult(playerWon);
        _hitButton.interactable = false;
        _standButton.interactable = false;
    }

    public void ShowSessionStatsOrNextRoundPrompt(int round, int wins, int losses, bool sessionOver)
    {
        if (sessionOver)
        {
            _statsHandler.gameObject.SetActive(true);
            _statsHandler.ShowStats(round, wins, losses);
        }
        else
        {
            _betUI.ResetBetUI();
            _nextRoundButton.gameObject.SetActive(true);
        }
    }

    public void ResetTableForNextRound(Player player, Dealer dealer, int nextRoundNumber)
    {
        _gameStatusRoot.SetActive(false);
        _playerCards.ClearCards();
        _dealerCards.ClearCards();

        player.Reset();
        dealer.Reset();

        _playerScore.ShowScore(player.score);
        _dealerScore.ShowScore(dealer.score);

        _roundHandler.changeRound(nextRoundNumber);
    }
}

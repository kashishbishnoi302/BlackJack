// Runs one blackjack game: dealing, hits, stand, who wins, and money updates.
// It does not touch Unity UI directly; GameplayTablePresenter does that.
public class BlackjackRoundController
{
    private readonly Deck _deck;
    private readonly Player _player;
    private readonly Dealer _dealer;
    private readonly GameplayTablePresenter _ui;

    private int _round;
    private bool _playerWon;
    private int _wins;
    private int _losses;

    public BlackjackRoundController(Deck deck, Player player, Dealer dealer, GameplayTablePresenter ui)
    {
        _deck = deck;
        _player = player;
        _dealer = dealer;
        _ui = ui;
    }

    // Called once when the game scene loads -> create the deck and starts the round
    public void StartSession()
    {
        _deck.RebuildDeck();
        StartRound();
        _round = 1;
    }

    // Show bet UI for a new round.
    public void StartRound()
    {
        MoneyManager.Instance.chooseBet();
    }

    // Deal first four cards after the player bets (2 player, 2 dealer) and show them.
    public void Initiate()
    {
        _deck.ResetUsedCards();

        Card card1 = _deck.DrawRandomUnused();
        _player.GiveCard(card1);
        Card card2 = _deck.DrawRandomUnused();
        _player.GiveCard(card2);
        Card card3 = _deck.DrawRandomUnused();
        _dealer.GiveCard(card3);
        Card card4 = _deck.DrawRandomUnused();
        _dealer.GiveCard(card4);

        // Show 11 on screen if the dealer’s up card is an ace (looks right for players).
        int dealerUpShown = card3.rank == "A" ? 11 : card3.num;
        _ui.ShowInitialDeal(_player.score, dealerUpShown, card1, card2, card3, card4);
    }

    private void EvaluateRoundOutcome()
    {
        
        // if round does'nt end, we simply return
        if (!TryResolveRound(_player.score, _dealer.score, out _playerWon))
            return;

        SettleRound();
    }

    // Show result, move money, then either end game stats or “next round”.
    private void SettleRound()
    {
        _ui.PresentRoundEnd(_dealer.score, _playerWon);

        if (_playerWon)
        {
            MoneyManager.Instance.handleUserWin();
            _wins++;
        }
        else
        {
            MoneyManager.Instance.handleUserLose();
            _losses++;
        }

        _ui.ShowSessionStatsOrNextRoundPrompt(_round, _wins, _losses, IsSessionOver());
    }

    // Game over if player cannot afford min bet or house has no money left.
    private bool IsSessionOver()
    {
        return MoneyManager.Instance.UserMoney < MoneyManager.Instance.MinBet
            || MoneyManager.Instance.DealerMoney <= 0;
    }

    // Clear table, bump round number, get ready for another bet.
    public void ResetUI()
    {
        _round++;
        _ui.ResetTableForNextRound(_player, _dealer, _round);
        _playerWon = false;
    }

    public void PlayerHit()
    {
        Card card = _deck.DrawRandomUnused();
        _player.GiveCard(card);
        _ui.UpdatePlayerScore(_player.score);
        _ui.AddPlayerCard(card);
        EvaluateRoundOutcome();
    }

    private void DealerDrawOneCard()
    {
        Card card = _deck.DrawRandomUnused();
        _dealer.GiveCard(card);
        _ui.AppendDealerCardAndScore(card, _dealer.score);
    }

    // Player stays; reveal dealer hole card, dealer draws until 17+, then decide winner.
    public void Stand()
    {
        _ui.RevealHoleClearQuestionMarkAndShowDealerScore(_dealer.score);

        while (_dealer.score < 17)
        {
            DealerDrawOneCard();
            if (_dealer.score > 21)
                break;
        }

        EvaluateRoundOutcome();
    }

    // Returns true if the round should end. Sets playerWon when the round ends.
    private bool TryResolveRound(int playerScore, int dealerScore, out bool playerWon)
    {
        playerWon = false;

        if (playerScore > 21)
        {
            playerWon = false;
            return true;
        }

        if (playerScore == 21 || dealerScore > 21)
        {
            playerWon = true;
            return true;
        }

        if (dealerScore >= 17)
        {
            playerWon = playerScore > dealerScore;
            return true;
        }
        return false;
    }
}

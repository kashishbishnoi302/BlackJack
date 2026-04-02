using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Hooks the game scene together. Unity fills the fields below from the Inspector.
// It creates the game logic object and sends button calls to it.
public class Main : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    [SerializeField] private DisplayCards displayPlayerCards;
    [SerializeField] private DisplayCards displayDealerCards;
    [SerializeField] private DisplayScore displayPlayerScore;
    [SerializeField] private DisplayScore displayDealerScore;
    [SerializeField] private GameStatusHandler gameStatusHandler;
    [SerializeField] private GameObject gameStatusObj;
    [SerializeField] private TextMeshProUGUI questionMark;
    [SerializeField] private Button dealButton;
    [SerializeField] private Button standButton;
    [SerializeField] private Button hitButton;
    [SerializeField] private BetUIController betUIController;
    [SerializeField] private Button NextRoundButton;
    [SerializeField] private RoundHandler roundHandler;
    [SerializeField] private StatsHandler statsHandler;

    private BlackjackRoundController _game;

    private void Awake()
    {
        // Build the round controller and give it all UI helpers it needs to update the screen.
        _game = new BlackjackRoundController(
            deck,
            player,
            dealer,
            new GameplayTablePresenter(
                displayPlayerCards,
                displayDealerCards,
                displayPlayerScore,
                displayDealerScore,
                gameStatusHandler,
                gameStatusObj,
                questionMark,
                hitButton,
                standButton,
                betUIController,
                NextRoundButton,
                roundHandler,
                statsHandler));
    }

    private void Start()
    {
        // First time: fresh deck, show bet, set round to 1.
        _game.StartSession();
    }

    public void StartRound()
    {
        _game.StartRound();
    }

    public void Initiate()
    {
        _game.Initiate();
    }

    public void PlayerHit()
    {
        _game.PlayerHit();
    }

    public void Stand()
    {
        _game.Stand();
    }

    public void ResetUI()
    {
        _game.ResetUI();
    }
}

using UnityEngine;
using UnityEngine.UI;
public class NextRoundButtonHandler : MonoBehaviour
{

    [SerializeField] private Button nextRoundBtn;
    [SerializeField] private Main gameManager;

    public void OnClickHandler()
    {
        // reset the UI
        gameManager.ResetUI();
        // start new round
        gameManager.StartRound();
        nextRoundBtn.gameObject.SetActive(false);
    }
}

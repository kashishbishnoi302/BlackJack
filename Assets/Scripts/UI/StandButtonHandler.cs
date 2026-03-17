using UnityEngine;

public class StandButtonHandler : MonoBehaviour
{
    [SerializeField] private Main gameManager;
    public void OnButtonClicked()
    {
        // dealer turn should start
        Debug.Log("stand button clicked!");
        gameManager.Stand();
    }
}

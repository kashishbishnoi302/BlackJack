using UnityEngine;
using UnityEngine.SceneManagement;

// Home screen: load the main blackjack scene when the player presses Play.
public class StartGame : MonoBehaviour
{
    public void SwitchToGameScene()
    {
        Debug.Log("Switching scene");
        SceneManager.LoadScene("GameScene");
    }
}

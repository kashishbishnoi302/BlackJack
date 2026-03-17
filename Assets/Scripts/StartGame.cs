using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void SwitchToGameScene()
    {
        Debug.Log("Switching scene");
        SceneManager.LoadScene("GameScene");
    }
}

using UnityEngine;
using UnityEngine.UI;
public class HitButtonHandler : MonoBehaviour

{

    [SerializeField] private Main gameManager;

    [SerializeField] private Button hitbutton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnButtonClicked()
    {
        Debug.Log("pressed hit button!");
        gameManager.PlayerHit();
    }

    void Update()
    {
        
    }
    
    
}

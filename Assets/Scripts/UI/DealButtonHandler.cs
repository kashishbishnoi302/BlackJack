using UnityEngine;
using UnityEngine.UI;
public class DealButtonHandler : MonoBehaviour
{
   [SerializeField] private Main gameController;
   [SerializeField] private Button dealButton;
   [SerializeField] private Button standButton;
   [SerializeField] private Button hitButton;
   public void OnButtonClicked()
   {
      Debug.Log("Deal button clicked!");
      gameController.Initiate();
      
      // disable the button:
      dealButton.interactable = false;
      standButton.interactable = true;
      hitButton.interactable = true;

   }
   
   
   
}

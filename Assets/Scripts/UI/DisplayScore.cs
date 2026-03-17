using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
  
   public void ShowScore(int score)
   {
      TextMeshProUGUI tmp = gameObject.GetComponent<TextMeshProUGUI>();
      tmp.text = score.ToString();
   }
   
   
   
   
   
   
   
}

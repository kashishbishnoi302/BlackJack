using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SliderHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text betText;

    void Start()
    {
        slider.wholeNumbers = true; // allow only whole numbers
        slider.onValueChanged.AddListener(OnSliderValueChanged); // slider move hone pe function call
        ResetSlider();
    }

    void OnSliderValueChanged(float value)
    {
        betText.text = value.ToString(); // change the text of bet on screen
        MoneyManager.Instance.UserBet = (int)value;
    }

    public void ResetSlider()
    {
        slider.minValue = MoneyManager.Instance.MinBet;
        slider.maxValue = Mathf.Min(MoneyManager.Instance.MaxBet, MoneyManager.Instance.UserMoney);
        slider.value = MoneyManager.Instance.MinBet; // set default value to min
        betText.text = slider.value.ToString();
    }
    
    

    
    
    
    
    
    

}

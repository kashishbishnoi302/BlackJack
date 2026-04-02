using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Bet slider: moving it updates the bet text and saves the value on MoneyManager.
public class SliderHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text betText;

    void Start()
    {
        slider.wholeNumbers = true;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        ResetSlider();
    }

    void OnSliderValueChanged(float value)
    {
        betText.text = value.ToString();
        MoneyManager.Instance.UserBet = (int)value;
    }

    // Set slider range from min bet, max bet, and how much cash the player has.
    public void ResetSlider()
    {
        slider.minValue = MoneyManager.Instance.MinBet;
        slider.maxValue = Mathf.Min(MoneyManager.Instance.MaxBet, MoneyManager.Instance.UserMoney);
        slider.value = MoneyManager.Instance.MinBet;
        betText.text = slider.value.ToString();
    }
}

using UnityEngine.UI;
using UnityEngine;

public enum SliderType
{
    MIN_VALUE,
    MAX_VALUE
}

public class SliderBehavior : MonoBehaviour
{
    [SerializeField]
    private SliderType sliderType = SliderType.MIN_VALUE;
    public SlidersManager manager; // Reference to the SlidersManager
    public Slider slider; // Reference to the Slider component
    private Image fillRectImage;

    void Start()
    {
        fillRectImage = slider.fillRect.GetComponent<Image>();
        if (fillRectImage == null)
        {
            Debug.LogError("SliderBehavior: No Image component found in children for background.");
        }
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
        if (manager == null)
        {
            Debug.LogError("SlidersManager reference is not set in SliderBehavior");
        }
        slider.onValueChanged.AddListener(delegate { NotifyManager(); ChangeColor(); });
        if (sliderType == SliderType.MIN_VALUE)
        {
            slider.minValue = 0f;
            slider.maxValue = 1f;
            slider.value = 0f; // Initialize to minimum
            fillRectImage.color = Color.cyan;
        }
        else if (sliderType == SliderType.MAX_VALUE)
        {
            slider.minValue = 0f;
            slider.maxValue = 1f;
            slider.value = 1f; // Initialize to maximum
            fillRectImage.color = Color.red;
        }
    }

    // Actions taken when the slider value changes
    private void NotifyManager()
    {
        if (manager != null)
        {
            manager.Notify(sliderType, (float)slider.value);
        }
        return;
    }
    private void ChangeColor()
    {
        if (slider.value <= 0.33f)
        {
            float localValue = slider.value/0.33f;
            fillRectImage.color = Color.Lerp(Color.cyan, Color.green, localValue);
        }
        else if (slider.value > 0.33f && slider.value <= 0.66f)
        {
            float localValue = (slider.value - 0.33f)/0.33f;
            fillRectImage.color = Color.Lerp(Color.green, Color.yellow, localValue);
        }
        else if (slider.value > 0.66f && slider.value < 1f)
        {
            float localValue = (slider.value - 0.66f)/0.34f;
            fillRectImage.color = Color.Lerp(Color.yellow, Color.red, localValue);
        }
        else
        {
            fillRectImage.color = Color.red;
        }
        return;
    }

    // Getter and Setter for slider value
    public void SetValue(float value)
    {
        slider.value = value;
        Debug.Log($"Slider value set to {value}");
        return;
    }

    public float GetValue()
    {
        return slider.value;
    }
}
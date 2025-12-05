// using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine;

public class SlidersManager : MonoBehaviour
{
    public ControlPanel controlPanel;
    public SliderBehavior minThresholdSlider;
    public SliderBehavior maxThresholdSlider;

    void Start()
    {
        if (minThresholdSlider == null || maxThresholdSlider == null)
        {
            Debug.LogError("SlidersManager: One or both SliderBehavior references are not set");
            return;
        }
        if (controlPanel == null)
        {
            Debug.LogError("SlidersManager: ControlPanel reference is not set");
            return;
        }
    }


    /// <summary>
    /// Notify slider change to the other slider, the controlled value, and update the value accordingly
    /// </summary>
    public void Notify(SliderType sender, float value)
    {
        if (sender == SliderType.MIN_VALUE)
        {
            float max = maxThresholdSlider.GetValue();
            if (value > max)
            {
                maxThresholdSlider.SetValue(value);
            }
            // Notify to the ControlPanel about the change
            // Debug.Log($"Min Threshold Slider changed to {value}");
            controlPanel.NotifyThresholdChange(value, max);
        }
        else if (sender == SliderType.MAX_VALUE)
        {
            float min = minThresholdSlider.GetValue();
            if (value < min)
            {
                minThresholdSlider.SetValue(value);
            }
            // Notify to the ControlPanel about the change
            // Debug.Log($"Max Threshold Slider changed to {value}");
            controlPanel.NotifyThresholdChange(min, value);
        }
        else
        {
            Debug.LogWarning("Sender slider is not recognized by SlidersManager");
        }

    }
    
    public void ResetSliders()
    {
        minThresholdSlider.SetValue(0f);
        maxThresholdSlider.SetValue(1f);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private ButtonBehavior[] buttons;
    [SerializeField]
    [Tooltip("By default, the first button is the Direct Volume Rendering button")]
    private ButtonBehavior lastActiveButton;
    [SerializeField]
    private ControlPanel controlPanel;

    private void Start()
    {
        if (controlPanel == null)
        {
            Debug.LogError("ButtonsManager: ControlPanel reference is missing.");
        }
        foreach (var button in buttons)
        {
            if (button == null)
            {
                Debug.LogError("ButtonsManager: One or more ButtonBehavior references are missing.");
            }
        }
    }
    
    /// <summary>
    /// Notify ControlPanel about the render mode change
    /// </summary>  
    public void Notify(UnityVolumeRendering.RenderMode mode, ButtonBehavior button)
    { 
        controlPanel.NotifyRenderModeChange(mode);
        if (button == null)
        {
            Debug.LogError("ButtonsManager: ButtonBehavior reference is null.");
            return;
        }
        if (lastActiveButton == null)
        {
            Debug.LogError("ButtonsManager: Last active button reference is null.");
            return;
        }
        lastActiveButton.ToogleInteractable(); // last active button is re-enabled
        button.ToogleInteractable(); // just clicked button is disabled
        lastActiveButton = button; // update last active button
    }
}

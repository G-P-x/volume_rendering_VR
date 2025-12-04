using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private ButtonBehavior dynamicVolumeRenderingButton, isosurfaceRenderingButton, maximumIntensityProjectionButton;
    [SerializeField]
    private ControlPanel controlPanel;

    private void Start()
    {
        if (controlPanel == null)
        {
            Debug.LogError("ButtonsManager: ControlPanel reference is missing.");
        }
        if (dynamicVolumeRenderingButton == null || isosurfaceRenderingButton == null || maximumIntensityProjectionButton == null)
        {
            Debug.LogError("ButtonsManager: One or more ButtonBehavior references are missing.");
        }
    }

    public void Notify(UnityVolumeRendering.RenderMode mode)
    { 
        controlPanel.NotifyRenderModeChange(mode);
    }
}

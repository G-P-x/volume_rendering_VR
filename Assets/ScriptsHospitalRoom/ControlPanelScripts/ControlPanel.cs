using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [Tooltip("Linker is VolumeObjControlPanelLinker that connects ControlPanel with VolumeRenderedObject")]
    public VolumeObjControlPanelLinker linker;

    [SerializeField]
    private SlidersManager slidersManager;

    private void Start()
    {
        if (linker == null)
        {
            Debug.LogError("ControlPanel: VolumeObjControlPanelLinker reference is missing.");
        }
        if (slidersManager == null)
        {
            Debug.LogError("ControlPanel: SlidersManager reference is missing.");
        }
    }

    /// <summary>
    /// Notify render mode change to the linked VolumeRenderedObject
    /// </summary>
    /// <param name="mode"></param>
    public void NotifyRenderModeChange(UnityVolumeRendering.RenderMode mode)
    {
        Debug.Log($"ControlPanel: Render mode changed to {mode}");
        linker.NotifyRenderModeChange(mode);
        slidersManager.ResetSliders();
    }
    
    /// <summary>
    /// Notify threshold changes to the linked VolumeRenderedObject
    /// </summary>
    /// <param name="minThreshold">Threshold from minimum slider</param>
    /// <param name="maxThreshold">Threshold from maximum slider</param>
    public void NotifyThresholdChange(float minThreshold, float maxThreshold)
    {   
        // Debug.Log($"ControlPanel: Thresholds changed to Min: {minThreshold}, Max: {maxThreshold}");
        linker.NotifyThresholdChange(minThreshold, maxThreshold);
    }
}

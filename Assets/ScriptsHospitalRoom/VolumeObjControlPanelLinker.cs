using UnityEngine;
using UnityVolumeRendering;

public class VolumeObjControlPanelLinker : MonoBehaviour
{
    [SerializeField]
    private ControlPanel controlPanel;
    private VolumeRenderedObject volumeObject;

    // public method to link ControlPanel with VolumeRenderedObject
    public void Link()
    {
        if (controlPanel == null)
        {
            Debug.LogError("VolumeObjControlPanelLinker: No ControlPanel found in the scene.");
            return;
        }

        volumeObject = FindAnyObjectByType<VolumeRenderedObject>();
        if (volumeObject == null)
        {
            Debug.LogError("VolumeObjControlPanelLinker: Cannot link ControlPanel, VolumeRenderedObject is null.");
            return;
        }

        // Here you would set up the ControlPanel to interact with the volumeObject
        Debug.Log("VolumeObjControlPanelLinker: Successfully linked ControlPanel with VolumeRenderedObject.");
    }

    /// <summary>
    /// Notify the VolumeRenderedObject of threshold changes from the ControlPanel
    /// </summary>
    /// <param name="minThreshold"></param>
    /// <param name="maxThreshold"></param>
    public void NotifyThresholdChange(float minThreshold, float maxThreshold)
    {
        if (volumeObject == null)
        {
            Debug.LogError("VolumeObjControlPanelLinker: VolumeRenderedObject is null. Cannot notify threshold change.");
            return;
        }

        Debug.Log($"VolumeObjControlPanelLinker: Notifying VolumeRenderedObject of threshold change. Min: {minThreshold}, Max: {maxThreshold}");
        // Here you would implement the logic to update the volumeObject's thresholds
        ChangeVisibleValueRange(minThreshold, maxThreshold);
    }

    /// <summary>
    /// Notify the VolumeRenderedObject of render mode changes from the ControlPanel
    /// </summary>
    /// <param name="mode"></param>
    public void NotifyRenderModeChange(UnityVolumeRendering.RenderMode mode)
    {
        if (volumeObject == null)
        {
            Debug.LogError("VolumeObjControlPanelLinker: VolumeRenderedObject is null. Cannot notify render mode change.");
            return;
        }

        Debug.Log($"VolumeObjControlPanelLinker: Notifying VolumeRenderedObject of render mode change to {mode}");
        // Here you would implement the logic to update the volumeObject's render mode
        ChangeRenderMode(mode);
    }


    // Logic to interact with the VolumeRenderedObject would go here

    /// <summary>
    /// Change the visible value range of the VolumeRenderedObject
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    private void ChangeVisibleValueRange(float minValue, float maxValue)
    {
        if (volumeObject == null)
        {
            Debug.LogError("VolumeObjControlPanelLinker: VolumeRenderedObject is null. Cannot change visible value range.");
            return;
        }

        // Debug.Log($"VolumeObjControlPanelLinker: Changing visible value range to Min: {minValue}, Max: {maxValue}");
        // Here you would implement the logic to change the visible value range of the volumeObject
        volumeObject.SetVisibilityWindow(new Vector2(minValue, maxValue));
    }

    /// <summary>
    /// Change the render mode of the VolumeRenderedObject
    /// </summary>
    /// <param name="mode"></param>
    private void ChangeRenderMode(UnityVolumeRendering.RenderMode mode)
    {
        if (volumeObject == null)
        {
            Debug.LogError("VolumeObjControlPanelLinker: VolumeRenderedObject is null. Cannot change render mode.");
            return;
        }

        // Debug.Log($"VolumeObjControlPanelLinker: Changing render mode to {mode}");
        // Here you would implement the logic to change the render mode of the volumeObject
        volumeObject.SetRenderMode(mode);
    }

}

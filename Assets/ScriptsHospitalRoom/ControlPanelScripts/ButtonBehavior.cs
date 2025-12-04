using UnityEngine.UI;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private ButtonsManager buttonsManager;
    private Button button;
    // Serialized field so the RenderMode can be chosen per-button in the Inspector
    [SerializeField]
    private UnityVolumeRendering.RenderMode renderMode = UnityVolumeRendering.RenderMode.DirectVolumeRendering;
    private void Start()
    {
        if (buttonsManager == null)
        {
            Debug.LogError("ButtonBehavior: ButtonsManager not found in the scene.");
        }
        button = gameObject.GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("ButtonBehavior: No Button component found on this GameObject.");
        }

        button.onClick.AddListener(delegate { NotifyManager(); });
    }

    private void NotifyManager()
    {
        if (buttonsManager != null)
        {
            buttonsManager.Notify(renderMode);
        }
        else
        {
            Debug.LogError("ButtonBehavior: ButtonsManager not found in the scene.");
        }
    }
}

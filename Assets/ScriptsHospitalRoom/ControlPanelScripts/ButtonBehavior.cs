using UnityEngine.UI;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private ButtonsManager buttonsManager;
    private Button button;
    [SerializeField]
    private Color selectedColor = Color.green;
    private Color defaultColor;
    // Serialized field so the RenderMode can be chosen per-button in the Inspector
    [SerializeField]
    private UnityVolumeRendering.RenderMode renderMode = UnityVolumeRendering.RenderMode.DirectVolumeRendering; // set individually in Inspector
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
        defaultColor = button.colors.normalColor;
        button.onClick.AddListener(delegate { NotifyManager(); });
    }

    private void NotifyManager()
    {
        if (buttonsManager != null)
        {
            buttonsManager.Notify(renderMode, this);
        }
        else
        {
            Debug.LogError("ButtonBehavior: ButtonsManager not found in the scene.");
        }
    }

    public void ToogleInteractable()
    {
        if (button != null)
        {
            button.interactable = !button.interactable;
        }
    }
}

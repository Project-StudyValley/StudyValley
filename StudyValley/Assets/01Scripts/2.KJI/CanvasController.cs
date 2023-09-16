using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
        
        canvas.SetActive(false);

        
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ToggleCanvas);
        }
        else
        {
            Debug.LogError("Button component not found.");
        }
    }

    void ToggleCanvas()
    {
        
        canvas.SetActive(!canvas.activeSelf);
    }
}
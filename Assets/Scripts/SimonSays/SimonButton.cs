using UnityEngine;
using TMPro;
using System.Collections;

public class SimonButton : MonoBehaviour
{
    public SimonColor color;

    private TextMeshProUGUI tmpText;
    private Color originalColor;

    private void Awake()
    {
        tmpText = GetComponentInChildren<TextMeshProUGUI>();
        if (tmpText != null)
        {
            originalColor = tmpText.color;
        }

    }

    public void OnClick()
    {
        if (SimonGameManager.Instance != null && SimonGameManager.Instance.InputHandler != null)
        {
            SimonGameManager.Instance.InputHandler.RegisterInput(color);
        }
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        if (tmpText != null)
        {
            tmpText.color = Color.white;
            yield return new WaitForSeconds(0.5f);
            tmpText.color = originalColor;
        }
    }
}

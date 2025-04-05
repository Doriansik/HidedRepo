using TMPro;
using UnityEngine;

public class SimonGameUIManager : MonoBehaviour
{
    public static SimonGameUIManager Instance { get; private set; }

    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI endGameMessage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void UpdateRound(int round)
    {
        if (roundText != null)
            roundText.text = "Runda: " + round;
    }

    public void ShowGameplayPanel()
    {
        if (gameplayPanel != null)
        {
            gameplayPanel.SetActive(true);
            winGamePanel.SetActive(false);
            endGamePanel.SetActive(false);
        }
    }

    public void ShowWinPanel()
    {
        if (winGamePanel != null)
        {
            winGamePanel.SetActive(true);
            gameplayPanel.SetActive(false);
            endGamePanel.SetActive(false);
        }
    }

    public void ShowEndPanel()
    {
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
            gameplayPanel.SetActive(false);
            winGamePanel.SetActive(false);
        }
    }

    public void HideGameplayPanel()
    {
        winGamePanel.SetActive(false);
    }

    public void HideWinPanel()
    {
        winGamePanel.SetActive(false);
    }

    public void HideEndPanel()
    {
        endGamePanel.SetActive(false);
    }
}




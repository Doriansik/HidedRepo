using System.Collections;
using UnityEngine;

public class SimonGameManager : MonoBehaviour
{
    public static SimonGameManager Instance { get; private set; }
    public IInputHandler InputHandler { get; private set; }

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;

    private ISequenceProvider sequenceProvider;
    private Coroutine gameLoopCoroutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void InitializeGame()
    {
        CrosshairManager.Instance.HideCrosshair();
        SimonGameUIManager.Instance.ShowGameplayPanel();

        if (gameLoopCoroutine != null)
            StopCoroutine(gameLoopCoroutine);

        sequenceProvider = new SimonSequence();
        InputHandler = new SimonInput(sequenceProvider);

        gameLoopCoroutine = StartCoroutine(GameLoop());
        playerMovement.enabled = false;
        mouseLook.enabled = false;
    }

    private IEnumerator GameLoop()
    {
        yield return new WaitForSeconds(2f);
        int round = 5;
        int roundAmount = 0;
        for (int i = 0; i < round; i++)
        {
            roundAmount++;
            if (SimonGameUIManager.Instance != null)
                SimonGameUIManager.Instance.UpdateRound(roundAmount);

            sequenceProvider.AddRandomStep();
            yield return sequenceProvider.PlaySequence();

            InputHandler.StartInput();
            yield return InputHandler.WaitForInput();

            if (!InputHandler.IsCorrect())
            {
                if (SimonGameUIManager.Instance != null)
                    SimonGameUIManager.Instance.ShowEndPanel();

                yield break;
            }

            yield return new WaitForSeconds(.75f);
        }

        if (SimonGameUIManager.Instance != null)
            SimonGameUIManager.Instance.ShowWinPanel();
    }



    public void ResetGame()
    {
        InitializeGame();
    }

    public void ExitSimonSays()
    {
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        SimonGameUIManager.Instance.HideEndPanel();
        SimonGameUIManager.Instance.HideGameplayPanel();
        SimonGameUIManager.Instance.HideWinPanel();
        CrosshairManager.Instance.ShowCrosshair();
    }
}

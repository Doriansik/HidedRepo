using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class SimonGameManager : MonoBehaviour
{
    public static SimonGameManager Instance { get; private set; }
    public IInputHandler InputHandler { get; private set; }

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private BlockCursor blockCursor;

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

    public void StartSimonSaysGame()
    {
        CrosshairManager.Instance.HideCrosshair();
        SimonGameUIManager.Instance.ShowGameplayPanel();
        blockCursor.ShowCursor();

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
        float timeToStartGame = 0.5f;
        yield return new WaitForSeconds(timeToStartGame);
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

            float delayBetweenRounds = 0.3f;
            yield return new WaitForSeconds(delayBetweenRounds);
        }

        if (SimonGameUIManager.Instance != null)
            SimonGameUIManager.Instance.ShowWinPanel();
    }



    public void ResetGame()
    {
        StartSimonSaysGame();
    }

    public void ExitSimonSays()
    {
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        blockCursor.HideCursor();
        SimonGameUIManager.Instance.HideEndPanel();
        SimonGameUIManager.Instance.HideGameplayPanel();
        SimonGameUIManager.Instance.HideWinPanel();
        CrosshairManager.Instance.ShowCrosshair();
    }
}

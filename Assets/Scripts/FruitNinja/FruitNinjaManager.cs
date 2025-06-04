using System.Collections;
using UnityEngine;
using TMPro;

public class FruitNinjaManager : MonoBehaviour
{
    public static FruitNinjaManager Instance;

    [Header("UI & Managers")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject fruitNinjaManagers;

    [Header("Player")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private BlockCursor blockCursor;
    [SerializeField] private MouseLook mouseLook;

    [Header("Gameplay")]
    [SerializeField] private FruitNinjaBlade blade;
    [SerializeField] private FruitNinjaSpawner spawner;
    [SerializeField] private Fruit[] fruitPool;
    [SerializeField] private Bomb[] bombPool;

    private int score = 0;

    private void Awake()
    {
        Instance = this;

    }

    private void Update()
    {
        CompleteGame();
    }

    public void NewGame()
    {
        CameraManager.Instance.CameraManage(2);

        scoreTextObject.SetActive(true);
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        blockCursor.ShowCursor();
        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        ClearScene();
    }

    private void ClearScene()
    {
        foreach (Fruit fruit in fruitPool)
        {
            if (fruit != null && fruit.gameObject.activeInHierarchy)
                Destroy(fruit.gameObject);
        }

        foreach (Bomb bomb in bombPool)
        {
            if (bomb != null && bomb.gameObject.activeInHierarchy)
                Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        yield return new WaitForSecondsRealtime(1f);
        NewGame();
    }

    private void CompleteGame()
    {
        if (score >= 30)
        {
            playerMovement.enabled = true;
            mouseLook.enabled = true;
            blockCursor.HideCursor();
            score = 0;
            scoreText.text = score.ToString();
            scoreTextObject.SetActive(false);
            CameraManager.Instance.CameraManage(0);
            fruitNinjaManagers.SetActive(false);
        }
    }
}

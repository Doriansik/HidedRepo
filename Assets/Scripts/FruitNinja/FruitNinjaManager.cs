using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class FruitNinjaManager : MonoBehaviour
{
    public static FruitNinjaManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject fruitNinjaManagers;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private BlockCursor blockCursor;
    [SerializeField] private MouseLook mouseLook;


    private FruitNinjaBlade blade;
    private FruitNinjaSpawner spawner;

    private int score = 0;

    private void Awake()
    {
        Instance = this;

        blade = FindFirstObjectByType<FruitNinjaBlade>();
        spawner = FindFirstObjectByType<FruitNinjaSpawner>();
    }

    private void Update()
    {
        CompleteGame();
    }

    public void NewGame()
    {
        CameraManager.Instance.CameraManage(2);
        
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
        Fruit[] fruits = FindObjectsOfType<Fruit>(false);

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>(false);

        foreach (Bomb bomb in bombs)
        {
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
        //float elapsed = 0f;
        //float duration = 0.5f;
        
        //while (elapsed < duration)
        //{
        //    float t = Mathf.Clamp01(elapsed / duration);
        //    //fadeImage.color = Color.Lerp(Color.clear, Color.white, t);


        //    Time.timeScale = 1f - t;
        //    elapsed += Time.unscaledDeltaTime;

        //    yield return null;
        //}
        
        yield return new WaitForSecondsRealtime(1f);

        NewGame();

        //elapsed = 0f;

        //while (elapsed < duration)
        //{
        //    float t = Mathf.Clamp01(elapsed / duration);
        //    fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

        //    elapsed += Time.unscaledDeltaTime;

        //    yield return null;
        //}
    }

    private void CompleteGame()
    {
        if(score >= 30)
        {
            playerMovement.enabled = true;
            mouseLook.enabled = true;
            blockCursor.HideCursor();
            score = 0;
            scoreText.text = score.ToString();
            CameraManager.Instance.CameraManage(0);
            fruitNinjaManagers.SetActive(false);
        }
    }
}

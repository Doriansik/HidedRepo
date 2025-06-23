using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RoomOne");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("das");
    }
}

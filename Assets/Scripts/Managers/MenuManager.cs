using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("RoomOne");
    }

    public void OnCreditsScene()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void OnQuitGame()
    {
        Application.Quit();
        Debug.Log("das");
    }
}

using System.Collections;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject insertCodePanel;
    [SerializeField] private GameObject winText;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;
    private float timeToChangeScene = 3f;


    private void Update()
    {
        EndGame();
    }

    private void EndGame()
    {
        if (insertCodePanel == null)
        {
            winText.SetActive(true);
            playerMovement.enabled = false;
            mouseLook.enabled = false;
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeToChangeScene);
        MenuManager.Instance.GoToMenu();
    }
}

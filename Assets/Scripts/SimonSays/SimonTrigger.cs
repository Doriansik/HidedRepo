using UnityEngine;

public class SimonTrigger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SimonGameManager.Instance.StartSimonSaysGame();
        Debug.Log("SimosSays");
    }
}

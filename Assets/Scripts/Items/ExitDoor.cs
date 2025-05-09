using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private GameObject insertCodePanel;
    [SerializeField] private BlockCursor blockCursor;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            insertCodePanel.SetActive(true);
            blockCursor.ShowCursor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            insertCodePanel.SetActive(false);
            blockCursor.HideCursor();
        }
    }
}

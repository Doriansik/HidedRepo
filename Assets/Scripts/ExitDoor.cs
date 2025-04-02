using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private GameObject insertCodePanel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            insertCodePanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            insertCodePanel.SetActive(false);
        }
    }
}

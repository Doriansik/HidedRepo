using UnityEngine;
using TMPro;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private BlockCursor blockCursor;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GameObject insertCodePanel;
    [SerializeField] private string correctCode;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text messageText;

    public void OnCheckCode()
    {
        if (inputField.text == correctCode)
        {
            messageText.text = "Valid Code!";
            exitDoor.SetActive(false);
            blockCursor.HideCursor();
            Destroy(insertCodePanel);
        }
        else
        {
            messageText.text = "Invalid Code!";
        }
    }
}


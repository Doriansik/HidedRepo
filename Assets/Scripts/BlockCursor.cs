using UnityEngine;

public class BlockCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        HideCursor();
    }


    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}

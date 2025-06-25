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
        ConfinedCursor();
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        LockCursor();
    }

    private void ConfinedCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}

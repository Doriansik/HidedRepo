using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera puzzleCamera;
    private int manager;



    public void CameraManage()
    {
        if(manager == 0)
        {
            SwitchToGameplayCamera();
            manager = 1;
        }
        else
        {
            SwitchToPuzzleCamera();
            manager = 0;
        }
    }


    private void SwitchToPuzzleCamera()
    {
        playerCamera.gameObject.SetActive(false);
        puzzleCamera.gameObject.SetActive(true);
    }

    private void SwitchToGameplayCamera()
    {
        puzzleCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private List<Camera> cameras = new List<Camera>();
    private int currentCameraIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void CameraManage(int index)
    {
        if (index < 0 || index >= cameras.Count)
        {
            return;
        }

        currentCameraIndex = index;
        ActivateCamera(currentCameraIndex);
        Debug.Log(currentCameraIndex);
    }

    private void ActivateCamera(int indexToActivate)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(i == indexToActivate);
        }
    }


}

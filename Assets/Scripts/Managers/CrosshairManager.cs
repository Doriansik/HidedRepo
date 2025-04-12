using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public static CrosshairManager Instance;

    [SerializeField] private GameObject crosshairObject;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowCrosshair()
    {
        crosshairObject.SetActive(true);
    }

    public void HideCrosshair()
    {
        crosshairObject.SetActive(false);
    }

}

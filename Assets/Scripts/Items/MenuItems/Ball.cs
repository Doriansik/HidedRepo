using FMODUnity;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float scale = 1.3f;
    FMOD.Studio.EventInstance instance;
    private void OnMouseEnter()
    {
        instance = AudioManager.instance.CreateInstance(FMODEvents.instance.BallHover);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(this.transform.position));
        instance.start();
        instance.release();
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnMouseExit()
    {
        instance.release();
        transform.localScale = Vector3.one;
    }
    private void OnMouseDown()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.BallClick, this.transform.position);
        MenuManager.Instance.StartGame();
    }
}

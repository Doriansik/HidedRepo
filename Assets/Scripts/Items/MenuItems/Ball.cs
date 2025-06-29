using UnityEngine;
using FMODUnity;

public class Ball : MonoBehaviour
{
    [SerializeField] private float scale = 1.3f;
    [SerializeField] private EventReference clickSound; 
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnMouseExit()
    {
        transform.localScale = Vector3.one;
    }
    private void OnMouseDown()
    {
        AudioManager.instance.PlayOneShot(clickSound, this.transform.position);
        MenuManager.Instance.StartGame();
    }
}

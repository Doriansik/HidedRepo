using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float scale = 1.3f;
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
        AudioManager.instance.PlayOneShot(FMODEvents.instance.UIClick, this.transform.position);
        MenuManager.Instance.StartGame();
    }
}

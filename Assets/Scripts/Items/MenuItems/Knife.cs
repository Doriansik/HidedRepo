using UnityEngine;

public class Knife : MonoBehaviour
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
        MenuManager.Instance.QuitGame();
    }
}

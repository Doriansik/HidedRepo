using UnityEngine;

public class SlidingPuzzleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject exitSlidingPuzzleButton;
    private void OnMouseDown()
    {
        SlidingPuzzleGameManager.Instance.ChangeCameraToPuzzle();
        exitSlidingPuzzleButton.SetActive(true);
    }
}

using UnityEngine;

public class SlidingPuzzleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject exitSlidingPuzzleButton;
    [SerializeField] private GameObject completeSlidingPuzzleButton;
    private void OnMouseDown()
    {
        SlidingPuzzleGameManager.Instance.ChangeCameraToPuzzle();
        exitSlidingPuzzleButton.SetActive(true);
        completeSlidingPuzzleButton.SetActive(true);
    }
}

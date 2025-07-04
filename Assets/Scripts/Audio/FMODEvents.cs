using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("UIClick")]
    [field: SerializeField] public EventReference UIClick { get; private set; }
    [field: Header("PlayerFootsteps")]
    [field: SerializeField] public EventReference PlayerFootsteps { get; private set; }
    [field: Header("BallHover")]
    [field: SerializeField] public EventReference BallHover { get; private set; }
    [field: Header("BallClick")]
    [field: SerializeField] public EventReference BallClick { get; private set; }
    [field: Header("PuzzleSlide")]
    [field: SerializeField] public EventReference PuzzleSlide { get; private set; }
    [field: Header("ColorPuzzle1")]
    [field: SerializeField] public EventReference ColorPuzzle1 { get; private set; }
    [field: Header("ColorPuzzle2")]
    [field: SerializeField] public EventReference ColorPuzzle2 { get; private set; }
    [field: Header("ColorPuzzle3")]
    [field: SerializeField] public EventReference ColorPuzzle3 { get; private set; }
    [field: Header("ColorPuzzle4")]
    [field: SerializeField] public EventReference ColorPuzzle4 { get; private set; }
    [field: Header("Squish")]
    [field: SerializeField] public EventReference Squish { get; private set; }
    [field: Header("BombA")]
    [field: SerializeField] public EventReference BombA { get; private set; }
    [field: Header("OST")]
    [field: SerializeField] public EventReference OST { get; private set; }


    public static FMODEvents instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You Idiot!!!");
        }
        instance = this;
    }
}
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
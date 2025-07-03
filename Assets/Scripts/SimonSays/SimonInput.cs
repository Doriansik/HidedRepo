using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonInput : IInputHandler
{
    private List<SimonColor> playerInput = new List<SimonColor>();
    private List<SimonColor> sequence;
    private bool inputFinished = false;

    public SimonInput(ISequenceProvider sequenceProvider)
    {
        sequence = sequenceProvider.GetSequence();
    }

    public void RegisterInput(SimonColor color)
    {
        playerInput.Add(color);
        if (color == SimonColor.Red && !inputFinished)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ColorPuzzle1, new Vector3(0, 0, 0));
        }
        else if (color == SimonColor.Green && !inputFinished)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ColorPuzzle2, new Vector3(0, 0, 0));
        }
        else if (color == SimonColor.Blue && !inputFinished)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ColorPuzzle3, new Vector3(0, 0, 0));
        }
        else if (color == SimonColor.Yellow && !inputFinished)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ColorPuzzle4, new Vector3(0, 0, 0));
        }
        if (playerInput.Count == sequence.Count)
            inputFinished = true;
    }

    public void StartInput()
    {
        playerInput.Clear();
        inputFinished = false;
    }

    public IEnumerator WaitForInput()
    {
        while (!inputFinished)
            yield return null;
    }

    public bool IsCorrect()
    {

        if (playerInput.Count != sequence.Count)
            return false;

        for (int i = 0; i < sequence.Count; i++)
        {
            if (sequence[i] != playerInput[i])
                return false;
        }
        return true;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSequence : ISequenceProvider
{
    private List<SimonColor> sequence = new List<SimonColor>();
    private SimonColor[] availableColors = { SimonColor.Red, SimonColor.Green, SimonColor.Blue, SimonColor.Yellow };

    public void AddRandomStep()
    {
        sequence.Add(availableColors[Random.Range(0, availableColors.Length)]);
    }

    public IEnumerator PlaySequence()
    {
        float delayBetweenFlashes = 1f;

        foreach (var color in sequence)
        {
            SimonButton button = SimonButtonManager.Instance.GetButton(color);
            if (button != null)
            {
                button.Flash();
            }
            yield return new WaitForSeconds(delayBetweenFlashes);
        }
    }


    public List<SimonColor> GetSequence()
    {
        return sequence;
    }
}

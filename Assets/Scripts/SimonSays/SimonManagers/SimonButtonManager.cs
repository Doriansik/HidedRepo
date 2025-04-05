using System.Collections.Generic;
using UnityEngine;

public class SimonButtonManager : MonoBehaviour
{
    public static SimonButtonManager Instance { get; private set; }

    public SimonButton[] simonButtons;

    private Dictionary<SimonColor, SimonButton> buttonDictionary = new Dictionary<SimonColor, SimonButton>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        foreach (SimonButton btn in simonButtons)
        {
            if (!buttonDictionary.ContainsKey(btn.color))
                buttonDictionary.Add(btn.color, btn);
        }
    }

    public SimonButton GetButton(SimonColor color)
    {
        if (buttonDictionary.TryGetValue(color, out SimonButton button))
            return button;
        return null;
    }
}

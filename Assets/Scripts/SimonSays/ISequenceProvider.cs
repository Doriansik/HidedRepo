using System.Collections;
using System.Collections.Generic;

public interface ISequenceProvider
{
    void AddRandomStep();
    IEnumerator PlaySequence();
    List<SimonColor> GetSequence();
}

public interface IInputHandler
{
    void RegisterInput(SimonColor color);
    void StartInput();
    IEnumerator WaitForInput();
    bool IsCorrect();
}


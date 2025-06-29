using UnityEngine;
using FMODUnity;
using System;
using FMOD.Studio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You Idiot!");
        }
        instance = this;
    }
    public void PlayOneShot(EventReference sound, Vector3 pos)
    {
        RuntimeManager.PlayOneShot(sound, pos);
    }

    internal void PlayOneShot(object uI_click, Vector3 position)
    {
        throw new NotImplementedException();
    }
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
    
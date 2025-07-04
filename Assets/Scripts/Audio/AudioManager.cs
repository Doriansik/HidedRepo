using UnityEngine;
using FMODUnity;
using System;
using FMOD.Studio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private EventInstance ambientMusic;

    private void Start()
    {

        InitializeSoundtrack(FMODEvents.instance.OST);
    }
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

    private void InitializeSoundtrack(EventReference soundtrackReference)
    {
        ambientMusic = CreateInstance(soundtrackReference);
        ambientMusic.start();
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
    
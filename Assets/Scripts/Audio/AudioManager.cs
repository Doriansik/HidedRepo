using UnityEngine;
using FMODUnity;
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
}
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class NowPlaying : MonoBehaviour
{
    public FMODUnity.EventReference pianoMusicEvent;
    FMOD.Studio.EventInstance pianoMusicInstance;
    
    void Start()
    {
        pianoMusicInstance = FMODUnity.RuntimeManager.CreateInstance(pianoMusicEvent);
        
        
    }

    void Update()
    {
        
    }
}

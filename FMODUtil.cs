using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODUtil : MonoBehaviour
{ 
    public static void PlayEvent(FMODUnity.EventReference eventRef, GameObject gameObject)
    {
        FMOD.Studio.EventInstance instance;
        instance = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }

    public static void PlayEvent(FMODUnity.EventReference eventRef, GameObject gameObject, string param, string value)
    {
        FMOD.Studio.EventInstance instance;
        instance = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        instance.setParameterByNameWithLabel(param, value);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }

    public static void PlayEvent(FMODUnity.EventReference eventRef, GameObject gameObject, string param, float value)
    {
        FMOD.Studio.EventInstance instance;
        instance = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        instance.setParameterByName(param, value);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }

    public static void PlayEvent(FMODUnity.EventReference eventRef, GameObject gameObject, string[] param, string[] value)
    {
        FMOD.Studio.EventInstance instance;
        instance = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        foreach (string userParameter in param)
            foreach (string parameterValue in value)
                instance.setParameterByNameWithLabel(userParameter, parameterValue);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }

    public static void PlayEvent(FMODUnity.EventReference eventRef, GameObject gameObject, string[] param, float[] value)
    {
        FMOD.Studio.EventInstance instance;
        instance = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        foreach (string userParameter in param)
            foreach (float parameterValue in value)
                instance.setParameterByName(userParameter, parameterValue);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }

    public static void SetGlobalParameter(string param, float value)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(param, value);
    }

    public static void SetGlobalParameter(string param, string value)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel(param, value);
    }

    public static bool isPlayingOrStarting(FMOD.Studio.EventInstance instance)
    {
        instance.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);
        return state == FMOD.Studio.PLAYBACK_STATE.PLAYING || state == FMOD.Studio.PLAYBACK_STATE.STARTING;
    }

    public static bool isStoppedOrStopping(FMOD.Studio.EventInstance instance)
    {
        instance.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);
        return state == FMOD.Studio.PLAYBACK_STATE.STOPPED || state == FMOD.Studio.PLAYBACK_STATE.STOPPING;
    }
}
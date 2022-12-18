using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AmbiencePiano : MonoBehaviour
{
    public EventReference aEvent;
    EventInstance aInstance;

    void Start()
    {
        aInstance = RuntimeManager.CreateInstance(aEvent);
        aInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
    }

    void Update()
    {
        aInstance.getPlaybackState(out PLAYBACK_STATE playbackState);

        if (TimeOfDay.get() >= 8f && TimeOfDay.get() < 21f)
        {
            if (FMODUtil.isStoppedOrStopping(aInstance))
            {
                aInstance.start();
            }
        }
        else
        {
            if (FMODUtil.isPlayingOrStarting(aInstance))
            {
                aInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }

        /*if (playbackState != PLAYBACK_STATE.PLAYING && 
            playbackState != PLAYBACK_STATE.STARTING && 
            TimeOfDay.get() >= 8f && TimeOfDay.get() < 21f)

            aInstance.start();

        if ((playbackState == PLAYBACK_STATE.PLAYING || 
            playbackState == PLAYBACK_STATE.STARTING) &&
            (TimeOfDay.get() < 8f || TimeOfDay.get() >= 21f))

            aInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);*/
    }
}

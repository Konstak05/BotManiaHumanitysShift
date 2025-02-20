using UnityEngine;

public class AudioMain : MonoBehaviour
{
    //Required for saving system
    public SavingSystem SavingSystem;

    public AudioSource SoundsSource,AmbienceSource;
    public AudioClip[] NormalSounds;
    public AudioClip[] SoundtrackSounds;
    public bool IsMuted;

    public void CloseAmbience(){AmbienceSource.enabled = false;}
    public void OpenAmbience(){AmbienceSource.enabled = true;}

    public void AudioChecker()
    {
        if(IsMuted == false){SoundsSource.volume = 1; AmbienceSource.volume = 0.1f;}
        else{SoundsSource.volume = 0; AmbienceSource.volume = 0;}
    }
    public void SaveMuteSettings(){
        SavingSystem.IsMuted = IsMuted;
        SavingSystem.SaveNight();
    }
}

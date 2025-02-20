using UnityEngine;

public class AudioOutput : MonoBehaviour
{
    public AudioMain AudioMain;
    public int MusicPlaying,SoundPlaying;
    public bool PlayAmbienceStart,PlaySoundStart;

    //Mute Button
    public GameObject MutedIndicator;

    //GetAudioMain
    void Awake()
    {
        GameObject targetObject = GameObject.Find("MainSystem");
        AudioMain = targetObject.GetComponent<AudioMain>();
    }
    //PlayAmbience
    void Start()
    {
        if(MutedIndicator != null){MutedIndicator.SetActive(AudioMain.IsMuted);}
        AudioMain.AudioChecker();
        AudioMain.AmbienceSource.clip = AudioMain.SoundtrackSounds[MusicPlaying];
        if(PlayAmbienceStart){AudioMain.AmbienceSource.Play();}
        if(PlaySoundStart){PlaySound(SoundPlaying);}
    }

    public void PlaySound(int SoundID)
    {
        AudioMain.AudioChecker();
        AudioMain.SoundsSource.PlayOneShot(AudioMain.NormalSounds[SoundID]);
    }
    public void StopSound(){if(AudioMain != null){AudioMain.SoundsSource.Stop();}}

    public void CloseAmbienceStarter(){AudioMain.CloseAmbience();}
    public void OpenAmbienceStarter(){AudioMain.OpenAmbience();}

    public void MuteToggle(){
        AudioMain.IsMuted = !AudioMain.IsMuted;
        MutedIndicator.SetActive(AudioMain.IsMuted);
        AudioMain.AudioChecker();
        AudioMain.SaveMuteSettings();
    }

    void OnDestroy(){if(AudioMain != null){AudioMain.AmbienceSource.Stop();}}
}

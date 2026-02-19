using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    public static AudioManager instance; //Can be accessed from anywhere, from any script. To call this, use AudoManager.instance.[function();].

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";


    void Awake()
    {
        if (instance == null) //If an instance of this singleton doesn't exist.
        {
            instance = this;  //Make the object that this script is attached to the instance.
            DontDestroyOnLoad(gameObject); //And don't destroy it when loading new scenes.
        }
        else
        {
            Destroy(gameObject); //If there's more than 1 of this gameobject, destroy it.
        }
        LoadVolume(); //Call loading volume set from memory on awake.
    }

    void LoadVolume() //Volume is saved in VolumeSettings.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f); //The second value is the 'default' for if the 'music key' doesn't load. Sets the music volume value attached to the slider to whatever value the MUSIC_KEY has, I think?
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20); //You have to mathf log to convert this value's counting system here to avoid having this break in other scenes.
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}

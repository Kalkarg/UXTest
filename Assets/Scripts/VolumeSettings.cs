using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_MUSIC = "MusicVolume"; //A constant string, for an unknown reason. Something to do with an exposed volume parameter we addded to the music mixer.
    public const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume); //Whenever the value of the music slider is changed, execute 'set music volume' void.
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f); //Sets the slider values to the ones that are saved.
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    }

    void OnDisable() //If the scene switches or the object is disabled...
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value); //Saves the music slider value.
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20); //Giving the music mixer and the value from the music slider. The Mathf part is to use the Logarithmic value that the mixers use.
    }
    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
}

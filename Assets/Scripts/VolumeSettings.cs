using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume); //Whenever the value of the music slider is changed, execute 'set music volume' void.
    }

    private void SetMusicVolume(float value)
    {
        
    }
}

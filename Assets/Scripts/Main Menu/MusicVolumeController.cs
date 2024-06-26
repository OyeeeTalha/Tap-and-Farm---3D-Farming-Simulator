using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicAudioSource;

    private void Start()
    {
        // Initialize the slider value with the current volume
        volumeSlider.value = musicAudioSource.volume;
    }

    public void SetMusicVolume()
    {
        // Update the music volume based on the slider value
        musicAudioSource.volume = volumeSlider.value;
    }
}

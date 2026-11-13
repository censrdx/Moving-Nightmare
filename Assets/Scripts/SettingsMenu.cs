using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    // Reference the audio mixer.
    [SerializeField] private AudioMixer audioMixer;
    
    // Graphics Manager
    
    // Apply quality settings depending on player's choice.
    public void SetQuality(int qualityIndex)
    {
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    // Audio Manager
    
    // Add Master Volume controls.
    private void SetMasterVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", volume);
    }

    // Add Music Volume controls.
    private void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }
    
    // Add SFX Volume controls.
    private void SetSfxVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("SFXVolume", volume);
    }
}

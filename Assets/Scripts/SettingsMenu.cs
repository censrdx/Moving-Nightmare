using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    // Reference the audio mixer.
    [SerializeField] private AudioMixer audioMixer;
    
    // Reference the text mesh pro dropdown for the resolution.
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    
    // Resolution Manager.

    // Reference resolutions array.
    private Resolution[] _resolutions;
    
    // Start is called before the first frame update.
    private void Start()
    {
        // Get all available resolutions and organize them by avoiding duplicates.
        _resolutions = Screen.resolutions
            .GroupBy(r => new { r.width, r.height })
            .Select(g => g.First())
            .ToArray();
        
        // Clear all default options provided in the dropdown.
        resolutionDropdown.ClearOptions();
        
        // Create an empty list to store formated resolutions.
        List<string> options = new List<string>();
        
        // Initialize the current resolution index to 0.
        int currentResolutionIndex = 0;

        // Loop through the resolutions array and format each one into a string for the dropdown.
        for (int i = 0; i < _resolutions.Length; i++)
        {
            var option = _resolutions[i].width + " x " + _resolutions[i].height + " @ " + _resolutions[i].refreshRateRatio + "hz";
            options.Add(option);

            // Check if this resolution matches the player's current screen resolution.
            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        // Apply the options to the dropdown and set the default value.
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Apply Resolution settings depending on player's choice.
    public void SetResolution(int resolutionIndex)
    {
        Debug.Log(resolutionIndex);
        var resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
    }
    
    // Graphics Manager.
    
    // Apply Vsync setting depending on player's choice.
    public void SetVsync(bool isVsync)
    {
        Debug.Log(isVsync);
        QualitySettings.vSyncCount = isVsync ? 1 : 0;
    }
    
    // Apply quality settings depending on player's choice.
    public void SetQuality(int qualityIndex)
    {
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Apply fullscreen.
    public void SetFullScreen(bool isFullScreen)
    {
        Debug.Log(isFullScreen);
        Screen.fullScreen = isFullScreen;
    }
    
    // Audio Manager.
    
    // Add Master Volume controls.
    public void SetMasterVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", volume);
    }

    // Add Music Volume controls.
    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }
    
    // Add SFX Volume controls.
    public void SetSfxVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
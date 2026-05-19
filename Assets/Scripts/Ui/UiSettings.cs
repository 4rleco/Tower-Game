using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UiSettings : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioMixer mixer;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    private void OnDestroy()
    {
        masterSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
    }

    private void ChangeMasterVolume(float currentValue) => mixer.SetFloat("VolumeMaster", currentValue);

    private void ChangeMusicVolume(float currentValue) => mixer.SetFloat("VolumeMusic", currentValue);

    private void ChangeSFXVolume(float currentValue) => mixer.SetFloat("VolumeSFX", currentValue);
}

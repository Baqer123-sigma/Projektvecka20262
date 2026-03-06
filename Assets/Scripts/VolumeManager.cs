using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
        [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; // Set volume according to slider
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume"); // Load set volume
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value); // Save set volume
    }
}
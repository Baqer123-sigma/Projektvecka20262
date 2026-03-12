using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVolume : MonoBehaviour
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetInt("volume"); // Changes volume in the level according to saved settings
    }
}

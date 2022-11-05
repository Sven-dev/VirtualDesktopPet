using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public void SetVolume(float value)
    {
        AudioManager.Instance.MasterVolume = value;
    }
}
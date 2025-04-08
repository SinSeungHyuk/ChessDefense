using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveUIController : MonoBehaviour
{
    [SerializeField] private WaveView waveView;


    public void InitializeWaveUIController()
    {
        waveView.InitializeWaveView();
    }
}

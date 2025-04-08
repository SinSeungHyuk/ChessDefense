using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIController : MonoBehaviour
{
    [SerializeField] private PauseView pauseView;


    public void InitializePauseUIController()
    {
        Time.timeScale = 0f;

        pauseView.gameObject.SetActive(true);
    }
}

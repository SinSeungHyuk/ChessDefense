using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnContinue;


    private void Start()
    {
        btnExit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        });


        btnContinue.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        });
    }
}

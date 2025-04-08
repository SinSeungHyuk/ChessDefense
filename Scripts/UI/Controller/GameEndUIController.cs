using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndUIController : MonoBehaviour
{
    [SerializeField] private GameEndView gameEndView;


    public void InitializeGameEndUIController(bool isWon)
    {
        gameEndView.gameObject.SetActive(true);
        gameEndView.InitializeGameEndView(isWon);
    }
}

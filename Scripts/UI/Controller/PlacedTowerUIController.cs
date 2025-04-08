using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedTowerUIController : MonoBehaviour
{
    [SerializeField] private PlacedTowerView placedTowerView;


    public void InitializePlacedTowerUIController()
    {
        placedTowerView.InitializePlacedTowerView();
    }
}

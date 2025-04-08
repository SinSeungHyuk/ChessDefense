using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUIController : MonoBehaviour
{
    [SerializeField] private GoldView goldView;


    public void InitializeGoldUIController()
    {
        goldView.InitializeGoldView();
    }
}

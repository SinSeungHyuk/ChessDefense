using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumberCheck : MonoBehaviour
{
    private bool isGround = false;

    public bool IsGround => isGround;
    public int Number {  get; private set; }


    private void Awake()
    {
        Number = int.Parse(gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        isGround = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGround = false;
    }
}

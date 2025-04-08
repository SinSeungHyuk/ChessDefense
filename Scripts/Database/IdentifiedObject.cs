using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IdentifiedObject : ScriptableObject, ICloneable
{
    [SerializeField,HideInInspector] private int id = -1;

    public int ID => id;


    // ICloneable �������̽��� Clone �Լ� ���� => ��ü�� �����ؼ� ����
    public virtual object Clone() => Instantiate(this);
}
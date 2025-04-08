using System;
using UnityEngine;

[DisallowMultipleComponent]
public class MonsterDestroyedEvent : MonoBehaviour
{
    public event Action<MonsterDestroyedEvent> OnMonsterDestroyed;

    public void CallMonsterDestroyedEvent()
    {
        OnMonsterDestroyed?.Invoke(this);
    }
}

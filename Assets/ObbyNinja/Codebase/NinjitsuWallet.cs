using System;
using UnityEngine;

public class NinjitsuWallet : MonoBehaviour
{
    public event Action<float> Added;

    [field: SerializeField] public int ValueForAdd { get; private set; }

    [field: SerializeField] public int MaxValue { get; private set; } = 2000;

    [field: SerializeField] public int Value { get; private set; }

    public void AddValue()
    {
        if (Value >= MaxValue)
            return;

        Value += ValueForAdd;
        Added?.Invoke(Value);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenWallet : MonoBehaviour
{
    public event Action<float> Added;

    [field: SerializeField] public int ValueForAdd {  get; private set; }

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public event Action <int> Changed;

    [field:SerializeField] public int Value {  get; private set; }

    public void Add(int value)
    {
        Value += value;
        Changed?.Invoke(Value);
    }
}

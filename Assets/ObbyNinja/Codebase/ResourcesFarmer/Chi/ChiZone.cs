using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiZone : MonoBehaviour
{
    public event Action Entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ChiFarmer _))
        {
            Entered?.Invoke();

            Debug.Log("вошел");
        }
    }
}

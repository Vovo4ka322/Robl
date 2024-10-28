using Codebase.Game.Gameplay.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiFarmer : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private Coroutine _coroutine;
    private float _timeToFarm = 1f;
    private int _minValue = 10;
    private int _maxValue = 15;
    private int _fullValue = int.MaxValue;

    public event Action<float> Changed;

    [field: SerializeField] public int Value { get; private set; } = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ChiZone _))
        {
            if (_playerController.Meditate())
                _coroutine = StartCoroutine(FarmChi());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ChiZone _))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _playerController.StopMeditate();
            }
        }
    }

    private IEnumerator FarmChi()
    {
        WaitForSeconds oneSecond = new(_timeToFarm);

        while (Value < _fullValue)
        {
            int randomValue = UnityEngine.Random.Range(_minValue, _maxValue + 1);

            Value += randomValue;
            Changed?.Invoke(Value);

            yield return oneSecond;
        }
    }
}
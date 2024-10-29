using System;
using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Gold _gold;
    [SerializeField] private ChiFarmer _chiFarmer;
    [SerializeField] private int _valueForAdd;
    [SerializeField] private string _nameOfAward;

    private Coroutine _coroutine;
    private string _nameGold = "Gold";
    private string _nameChi = "Chi";
  
    public event Action<float> Opened;
    public event Action<string> Added;
    public event Action<int> ValueAdded;

    [field: SerializeField] public float TimeToOpen { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ChiFarmer _))
        {
            _coroutine = StartCoroutine(Open()); 
        }
    }

    private void OnDisable()
    {
        //if (_coroutine != null)
        //    StopCoroutine(_coroutine);
    }

    private IEnumerator Open()
    {
        WaitForSeconds timeToOpen = new(TimeToOpen);

        while (enabled)
        {
            TakeAward();

            yield return timeToOpen;
        }
    }

    private void TakeAward()
    {
        if (_nameOfAward == _nameGold)
        {
            _gold.Add(_valueForAdd);
            Added?.Invoke(_nameOfAward);
            ValueAdded?.Invoke(_valueForAdd);
        }
        else if (_nameOfAward == _nameChi)
        {
            _chiFarmer.Add(_valueForAdd);
            Added?.Invoke(_nameOfAward);
            ValueAdded?.Invoke(_valueForAdd);
        }
    }
}

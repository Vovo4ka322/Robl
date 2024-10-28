using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChiViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private ChiFarmer _chiFarmer;

    private float _minValueViewChange = 1000;

    private string[] _lettersMoneySymbols =
    {
        "" ,"K", "M", "B", "T"
    };

    private void OnEnable()
    {
        _chiFarmer.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _chiFarmer.Changed -= OnChanged;
    }

    private void OnChanged(float value)
    {
        if (value == 0)
            return;

        value = Mathf.Round(value);

        int i = 0;

        while (i + 1 < _lettersMoneySymbols.Length && value >= _minValueViewChange)
        {
            value /= _minValueViewChange;
            i++;
        }

        _textMeshPro.text = value.ToString() + _lettersMoneySymbols[i];
    }
}

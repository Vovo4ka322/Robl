using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestViewer : MonoBehaviour
{
    [SerializeField] private Chest _chest;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _awardText;
    [SerializeField] private TextMeshProUGUI _timeText;

    private void OnEnable()
    {
        _chest.ValueAdded += OnValueAdded;
        _chest.Added += OnAwardAdded;
        _chest.Opened += OnTimeOpened;
    }

    private void OnDisable()
    {
        _chest.ValueAdded -= OnValueAdded;
        _chest.Added -= OnAwardAdded;
        _chest.Opened -= OnTimeOpened;
    }

    private void OnValueAdded(int value)
    {
        _valueText.text = value.ToString();
    }

    private void OnAwardAdded(string award)
    {
        _valueText.text = award;
    }

    private void OnTimeOpened(float time)
    {
        time = _chest.TimeToOpen;

        _timeText.text = Mathf.Round(time).ToString() + " до следующего открытия.";
    }
}

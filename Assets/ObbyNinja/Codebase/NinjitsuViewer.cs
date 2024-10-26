using TMPro;
using UnityEngine;

public class NinjitsuViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private NinjitsuWallet _collector;

    private float _minValueViewChange = 1000;

    private string[] _lettersMoneySymbols =
    {
        "" ,"K", "M", "B", "T"
    };

    private void OnEnable()
    {
        _collector.Added += OnChanged;
    }

    private void OnDisable()
    {
        _collector.Added -= OnChanged;
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

        _textMeshPro.text = value.ToString() + _lettersMoneySymbols[i] + " / " + _collector.MaxValue;
    }
}

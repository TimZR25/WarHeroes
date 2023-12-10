using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _tMP;
    [SerializeField] protected TextMeshProUGUI _textMeshProUGUI;

    private void Start()
    {
        _tMP.onValueChanged.AddListener(Change);
    }

    public void Change(int value)
    {
        _textMeshProUGUI.text = _tMP.options[value].text;
    }
}

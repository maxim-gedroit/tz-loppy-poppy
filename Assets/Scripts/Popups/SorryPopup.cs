using System;
using UnityEngine;
using UnityEngine.UI;

public class SorryPopup : Popup
{
    public static event Action OnNewEquation;

    [SerializeField] private Button _newEquation;
    [SerializeField] private Button _quit;

    private void Awake()
    {
        _newEquation.onClick.AddListener(OnNewEquationClick);
        _quit.onClick.AddListener(OnQuitClick);
    }

    private void OnQuitClick()
    {
        Hide();
    }

    private void OnNewEquationClick()
    {
       OnNewEquation?.Invoke();
       Hide();
    }
}

// Здесь реализован простейший пример MVP.
// Можно было бы докинуть dependency inversion,
// но так как в задании только один экран,
// ради экономии времени сделал все по-простому.

using System;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private MainView _view;

    private MainPresenter _presenter;
    private void Awake()
    {
        _presenter = new MainPresenter();
    }

    private void Start()
    {
        _presenter.Init(_view);
    }
}

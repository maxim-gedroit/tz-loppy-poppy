// Здесь реализован простейший пример MVP.
// Можно было бы докинуть dependency inversion,
// но так как в задании только один экран,
// ради экономии времени сделал все по-простому.

using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private MainView _view;
    private void Awake()
    {
        MainPresenter presenter = new MainPresenter(_view);
    }
}

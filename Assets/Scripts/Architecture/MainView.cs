using System;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public event Action OnDispose;
    public event Action<String> OnButtonClicked;

    [SerializeField] private Button _button;
    
    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        
    }

    public void PrintResult()
    {
        
    }

    private void OnButtonClick()
    {
        OnButtonClicked?.Invoke("--");
    }

    private void OnDestroy()
    {
        OnDispose?.Invoke();
    }
}

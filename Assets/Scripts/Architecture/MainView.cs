using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public event Action OnDispose;
    public event Action<String> OnButtonClicked;

    [SerializeField] private Button _button;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _buttonText;
    
    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClick);
    }
    
    public void PrintResult(string res)
    {
        _buttonText.text = res;
    }

    public void SetUI(String valueInput, String resValue)
    {
        _inputField.text = valueInput;
        _buttonText.text = resValue;
    }

    public void ResetUI()
    {
        _inputField.text = string.Empty;
        _buttonText.text = "Result";
    }

    private void OnButtonClick()
    {
        OnButtonClicked?.Invoke(_inputField.text);
    }

    private void OnDestroy()
    {
        OnDispose?.Invoke();
    }
}

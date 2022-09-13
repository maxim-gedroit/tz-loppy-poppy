using System;
using System.Globalization;
using UnityEngine;
using Exception = System.Exception;

public class MainPresenter
{
    private MainData _data;
    private MainView _view;

    private String _tempInput;
    
    public void Init(MainView view)
    {
        _view = view;
        _view.OnDispose += Save;
        _view.OnButtonClicked += Division;
        SorryPopup.OnNewEquation += Reset;
        
        Load();
        
        if(_tempInput != string.Empty)
            Division(_tempInput);
    }

    private void Reset()
    {
       _view.ResetUI();
    }

    private void Division(String input)
    {
        _tempInput = input;
        var arr = Validate(input);
        if (arr == null)
        {
            PopupManager.Instance.Show("sorry");
            return;
        }

        var number1 = TryParse(arr[0]);
        var number2 = TryParse(arr[1]);

        if (number1 == -1 || number2 == -1)
        {
            PopupManager.Instance.Show("sorry");
            return;
        }

        var res = number1 / number2;
        _view.SetUI(_tempInput,res.ToString());
    }

    private String[] Validate(String input)
    {
        try
        {
            var arr = input.Split('/');
            return arr.Length == 2 ? arr: null;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString("LoppyPoppyState",_tempInput);
    }

    private void Load()
    {
        _tempInput = PlayerPrefs.GetString("LoppyPoppyState");
    }

    private float TryParse(String input)
    {
        try
        {
            return float.Parse(input, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            return -1;
        }
    }
}

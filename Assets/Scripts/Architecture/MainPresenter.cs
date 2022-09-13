using System;
using System.Globalization;
using Exception = System.Exception;

public class MainPresenter
{
    private MainData _data;
    private MainView _view;
    
    public void Init(MainView view)
    {
        _data = new MainData();
        _view = view;
        _view.OnDispose += Save;
        _view.OnButtonClicked += Division;
        SorryPopup.OnNewEquation += Reset;
        
        if(_data.State != string.Empty)
            Division(_data.State);
    }

    private void Reset()
    {
       _view.ResetUI();
    }

    private void Division(String input)
    {
        _data.State = input;
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
        _view.SetUI(_data.State,res.ToString());
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
        _data.Save();
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

using System;
using System.IO;

public class MainPresenter
{
    private MainData _data;
    private MainView _view;

    public MainPresenter(MainView view)
    {
        _view = view;
        Load();

        _view.OnDispose += Save;
        _view.OnButtonClicked += Division;

        SorryPopup.OnQuit += Save;
        SorryPopup.OnNewEquation += Reset;
    }

    private void Reset()
    {
       
    }

    private void Division(String input)
    {
        _view.PrintResult();
    }

    private void Save()
    {
        
    }

    private void Load()
    {
        
    }
}

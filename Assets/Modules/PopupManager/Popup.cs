using UnityEngine;

public class Popup : MonoBehaviour
{
    private enum State
    {
        Shown,
        Hidden,
    }
    
    private State state;
    
    public virtual void Initialize()
    {
        gameObject.SetActive(false);
        state = State.Hidden;
    }
    
    public void Show()
    {
        if (state != State.Hidden)
            return;

        state = State.Shown;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        state = State.Hidden;
        gameObject.SetActive(false);
    }
    
}
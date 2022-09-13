using System.Collections.Generic;
using UnityEngine;

public class PopupManager : SingletonComponent<PopupManager>
{
    [System.Serializable]
    private class PopupInfo
    {
        public string popupId = "";
        public Popup popup = null;
    }
    
    [SerializeField] private List<PopupInfo> popupInfos = null;
    
    private List<Popup> activePopups;
    
    protected override void Awake()
    {
        base.Awake();

        activePopups = new List<Popup>();

        for (int i = 0; i < popupInfos.Count; i++)
        {
            popupInfos[i].popup.Initialize();
        }
    }
    
    public void Show(string id)
    {
        Popup popup = GetPopupById(id);

        if (popup != null)
        {
            popup.Show();
            activePopups.Add(popup);
        }
        else
        {
            Debug.LogErrorFormat("[PopupController] Popup with id {0} does not exist", id);
        }
    }
    
    private Popup GetPopupById(string id)
    {
        for (int i = 0; i < popupInfos.Count; i++)
        {
            if (id == popupInfos[i].popupId)
            {
                return popupInfos[i].popup;
            }
        }
        return null;
    }
}
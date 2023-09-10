
using UnityEngine;

public class Statue: Exhibit
{

    private bool _used;
    public override void Interact()
    {
        if(_used)
            return;

        Cursor.lockState = CursorLockMode.None;
        _used = true;
        
        UIManager.Instance.InfoPanel.SetDescription(config.Description);
        UIManager.Instance.InfoPanel.SetMedia(config.Media);
        UIManager.Instance.InfoPanel.SetPanelActivity(true);
    }
}

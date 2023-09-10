
using System;
using System.Collections;
using UnityEngine;

public class Statue: Exhibit
{

    private bool _used;

    private void Awake()
    { 
        //Instantiate(config.Prefab, transform);
    }

    public void Start()
    {
        UIManager.Instance.InfoPanel.SetCloseButtonAction(FinishInteract);
    }

    public override void Interact()
    {
        if(_used)
            return;
        
        StopAllCoroutines();
        UIManager.Instance.InfoPanel.SetDescription(config.Description);
        UIManager.Instance.InfoPanel.SetMedia(config.Media);
        UIManager.Instance.InfoPanel.SetPanelActivity(true);
        
        _used = true;
    }

    public override void FinishInteract()
    {
        StartCoroutine(SetUsedState(false, 2f));
    }

    private IEnumerator SetUsedState(bool state, float duration)
    {
        yield return new WaitForSeconds(duration);
        _used = state;
    }
}

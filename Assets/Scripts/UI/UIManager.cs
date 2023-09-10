using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : Singleton<UIManager>
{ 
    [SerializeField] private InfoPanel infoPanel;
    public InfoPanel InfoPanel => infoPanel;
    
    
}

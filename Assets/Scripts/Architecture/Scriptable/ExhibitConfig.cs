using UnityEngine;

[CreateAssetMenu(menuName = "Source/Exhibit/ExhibitConfig", fileName = "ExhibitConfig", order = 0)]
public class ExhibitConfig: ScriptableObject
{
    [TextArea(7, 10)][SerializeField] private string description;
    [SerializeField] private Sprite media;

    public string Description => description;
    public Sprite Media => media;
}
 
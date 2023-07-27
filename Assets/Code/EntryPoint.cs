using System.Collections.Generic;
using Code.Inventory;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private UiRoot _uiRoot;
    [SerializeField] private string _longDescription;
    [SerializeField] private string _shortDescription;
    [SerializeField] private Sprite[] _icons;

    private List<List<InventoryItem>> _rewardsPacks;

    public void Start()
    {
        _rewardsPacks = new List<List<InventoryItem>>();
        
        _rewardsPacks.Add(new List<InventoryItem>()
        {
            new(GetTitle(1), GetDescription(1), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(2), GetDescription(2), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(3), GetDescription(3), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(4), GetDescription(4), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(5), GetDescription(5), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(6), GetDescription(6), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(7), GetDescription(7), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(8), GetDescription(8), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(9), GetDescription(9), _icons[Random.Range(0, _icons.Length)]),
        });
        
        _rewardsPacks.Add(new List<InventoryItem>()
        {
            new(GetTitle(1), GetDescription(1), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(2), GetDescription(2), _icons[Random.Range(0, _icons.Length)]),
            new(GetTitle(3), GetDescription(3), _icons[Random.Range(0, _icons.Length)]),
        });

        _uiRoot.GetWindow<MainWindow>().Set(_rewardsPacks);
    }
    
    private string GetTitle(int index)
    {
        return index % 2 == 1 ? $"Title {index}" : $"A very long Title {index}";
    }

    private string GetDescription(int index)
    {
        return index % 2 == 0 ? _longDescription : _shortDescription;
    }
}
using System.Collections.Generic;
using Code.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : Window
{
    [SerializeField] private Button[] _rewardButtons;

    private RewardsWindow _rewardsWindow;

    public void Set(List<List<InventoryItem>> packs)
    {
        for (int i = 0; i < packs.Count; i++)
        {
            int packNumber = i;
            _rewardButtons[i].onClick.AddListener(() => ShowRewards(packs[packNumber], packNumber));
        }
        
        Show();
    }
    
    protected override void OnInit()
    {
        _rewardsWindow = UiRoot.GetWindow<RewardsWindow>();
    }

    private void ShowRewards(List<InventoryItem> pack, int index)
    {
        _rewardsWindow.Set(pack, index);
        Hide();
    }
}
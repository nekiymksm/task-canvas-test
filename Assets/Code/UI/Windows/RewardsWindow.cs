using System.Collections.Generic;
using Code.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class RewardsWindow : Window
{
    [SerializeField] private RewardItemView _rewardItemViewPrefab;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Text _rewardsLabelText;
    [SerializeField] private Transform _poolTransform;

    private MainWindow _mainWindow;
    private TooltipWindow _tooltipWindow;
    private List<RewardItemView> _rewardItemViews;
    private List<RewardItemView> _rewardItemsPool;

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(Hide);
    }

    public void Set(List<InventoryItem> itemsPack, int packId)
    {
        _rewardsLabelText.SetText($"REWARD {packId + 1}");
        
        for (int i = 0; i < itemsPack.Count; i++)
        {
            var itemView = GetRewardItem();
            itemView.transform.SetParent(_scrollRect.content);
            itemView.Set(itemsPack[i], _tooltipWindow);
            _rewardItemViews.Add(itemView);
        }
        
        Show();
        TrySetScrollPanelPosition();
    }

    private void TrySetScrollPanelPosition()
    {
        var scrollRectTransform = (RectTransform)_scrollRect.transform;
        var rewardItemRectTransform = (RectTransform) _rewardItemViewPrefab.transform;
        var panelWidth = rewardItemRectTransform.rect.width * _rewardItemViews.Count;

        if (panelWidth < scrollRectTransform.rect.width)
        {
            _scrollRect.enabled = false;
            
            var position = _scrollRect.content.localPosition;
            position.x = (scrollRectTransform.rect.width - panelWidth) / 2;
            _scrollRect.content.localPosition = position;
        }
    }

    protected override void OnInit()
    {
        _mainWindow = UiRoot.GetWindow<MainWindow>();
        _tooltipWindow = UiRoot.GetWindow<TooltipWindow>();
        _rewardItemViews = new List<RewardItemView>();
        _rewardItemsPool = new List<RewardItemView>();
        
        _closeButton.onClick.AddListener(Hide);
    }

    protected override void OnHide()
    {
        _scrollRect.enabled = true;
        
        foreach (var rewardItemView in _rewardItemViews)
        {
            rewardItemView.transform.SetParent(_poolTransform);
            rewardItemView.gameObject.SetActive(false);
        }
        
        _rewardItemViews.Clear();
        _mainWindow.Show();
    }

    private RewardItemView GetRewardItem()
    {
        for (int i = 0; i < _rewardItemsPool.Count; i++)
        {
            if (_rewardItemsPool[i].gameObject.activeSelf == false)
            {
                return _rewardItemsPool[i];
            }
        }
        
        var itemView = Instantiate(_rewardItemViewPrefab, _poolTransform);
        _rewardItemsPool.Add(itemView);
        itemView.gameObject.SetActive(false);

        return itemView;
    }
}
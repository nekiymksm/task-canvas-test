using System.Threading.Tasks;
using Code.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardItemView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int _tapDuration;
    [SerializeField] private Image _iconImage;

    private TooltipWindow _tooltipWindow;
    private InventoryItem _inventoryItem;
    private bool _isDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDown = true;
        
        AsyncDelayShowTooltip();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _isDown = false;
    }

    public void Set(InventoryItem inventoryItem, TooltipWindow tooltipWindow)
    {
        gameObject.SetActive(true);
        
        _iconImage.sprite = inventoryItem.Icon;
        _tooltipWindow = tooltipWindow;
        _inventoryItem = inventoryItem;
    }

    private async void AsyncDelayShowTooltip()
    {
        await Task.Delay(_tapDuration);
        TryShow();
    }
    
    private void TryShow()
    {
        if (_isDown)
        {
            _tooltipWindow.Set(_inventoryItem);
        }
    }
}
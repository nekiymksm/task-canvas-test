using Code.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipWindow : Window
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _tooltipBackgroundImage;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _infoText;
    [SerializeField] private Button _closeButton;
    [SerializeField] private float _maxWidthValue;
    [SerializeField] private float _maxHeightValue;
    [SerializeField] private float _minWidthValue;
    [SerializeField] private float _minHeightValue;

    private float _currentWidth;
    private float _currentHeight;

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(Hide);
    }

    protected override void OnInit()
    {
        _closeButton.onClick.AddListener(Hide);
    }

    public void Set(InventoryItem inventoryItem)
    {
        Show();
        
        _titleText.SetText(inventoryItem.Title);
        _itemImage.sprite = inventoryItem.Icon;
        _infoText.SetText(inventoryItem.Description);

        _currentWidth = _infoText.preferredWidth;
        _currentHeight = _infoText.preferredHeight;
        
        TrySetWidth();
        TrySetHeight();
        
        _infoText.rectTransform.sizeDelta = new Vector2(_currentWidth, _currentHeight);
        _tooltipBackgroundImage.rectTransform.sizeDelta = _infoText.rectTransform.sizeDelta;
    }

    private void TrySetWidth()
    {
        if (_currentWidth > _maxWidthValue)
        {
            _currentWidth = _maxWidthValue;
        }
        
        if(_currentWidth < _minWidthValue)
        {
            _currentWidth  = _minWidthValue;
        }
    }
    
    private void TrySetHeight()
    {
        if (_currentHeight > _maxHeightValue)
        {
            _currentHeight = _maxHeightValue;
        }
        
        if(_currentHeight < _minHeightValue)
        {
            _currentHeight = _minHeightValue;
        }
    }
}
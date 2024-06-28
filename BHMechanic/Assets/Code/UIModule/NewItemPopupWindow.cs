using BHMechanic.Code.EntityModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BHMechanic.Code.UIModule
{
    public class NewItemPopupWindow : BaseWindow
    {
        [SerializeField] private GameObject _equippedItemExistsPanel;
        [SerializeField] private GameObject _equippedItemNotExistsPanel;
        [SerializeField] private Button _takeButton;
        [SerializeField] private Button _dropButton;
        
        [Header("Equipped Item")]
        [SerializeField] private Image _equippedItemIcon;
        [SerializeField] private TextMeshProUGUI _equippedItemCharacteristics;
        [SerializeField] private TextMeshProUGUI _equippedItemName;
        
        [Header("New Item")]
        [SerializeField] private Image _newItemIcon;
        [SerializeField] private TextMeshProUGUI _newItemCharacteristics;
        [SerializeField] private TextMeshProUGUI _newItemName;

        private InventoryItemEntity _newItemEntity;
        protected override void Awake()
        {
            SubscribeActions();
            
            base.Awake();
        }

        protected override void OnShow(object[] __args)
        {
            _newItemEntity = (InventoryItemEntity)__args[0];
            InventoryItemEntity equippedItem = (InventoryItemEntity)__args[1];

            if (equippedItem == null)
            {
                _dropButton.enabled = false;
                ShowItemNotExistsPanel();
            }
            else
            {
                _dropButton.enabled = true;
                UpdateItemInfo(equippedItem, _equippedItemIcon, _equippedItemCharacteristics, _equippedItemName);
                ShowItemExistsPanel();
            }

            UpdateItemInfo(_newItemEntity, _newItemIcon, _newItemCharacteristics, _newItemName);
                
            SubscribeActions();
        }
        
        private void UpdateItemInfo(InventoryItemEntity __item, Image __icon, TextMeshProUGUI __quality, TextMeshProUGUI __name)
        {
            __icon.sprite = __item.Icon;
            
            // ATK HP DEF SPD
            __quality.text = $"{__item.Attack}\n{__item.Health}\n{__item.Defence}\n{__item.Speed}";
            __name.text = __item.Name;
        }

        private void SubscribeActions()
        {
            _dropButton.onClick.AddListener(this.Hide);
            _takeButton.onClick.AddListener(OnTakeAction);
        }

        private void OnTakeAction()
        {
            _windowsMediator.UpdateItemRollWindow(_newItemEntity);
            
            this.Hide();
        }

        private void ShowItemNotExistsPanel() => _equippedItemNotExistsPanel.SetActive(true);
        private void HideItemNotExistsPanel() => _equippedItemNotExistsPanel.SetActive(false);
        private void ShowItemExistsPanel() => _equippedItemExistsPanel.SetActive(true);
        private void HideItemExistsPanel() => _equippedItemExistsPanel.SetActive(false);
        
        protected override void OnHide()
        {
            HideItemExistsPanel();
            HideItemNotExistsPanel();
            Cleanup();
        }

        private void Cleanup()
        {
            _dropButton.onClick.RemoveAllListeners();
            _takeButton.onClick.RemoveAllListeners();
        }
    }
}
using BHMechanic.Code.CollectionModule;
using BHMechanic.Code.EntityModule;
using BHMechanic.Code.LogicModule;
using BHMechanic.Code.ServiceModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BHMechanic.Code.UIModule
{
    public class RollWindow : BaseWindow
    {
        [SerializeField] private Button _rollButton;
        [SerializeField] private Image _itemIcon;
        
        [Header("In Seconds")]
        [SerializeField] private float _manaRestoreTime;
        [SerializeField] private uint _startManaCount;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _manaCountText;
        
        private InventoryItemsCollection _inventoryItemsCollection;
        private ManaVessel _manaVessel; 
        private TimerCoroutineService _timerService;

        private InventoryItemEntity _equippedItem;
        protected override void Awake()
        {
            _timerService = new TimerCoroutineService(this, _manaRestoreTime, RestoreMana, UpdateManaTimerText);
            _manaVessel = new ManaVessel(_startManaCount, UnBlockRollButton, BlockRollButton);
            
            base.Awake();
        }
        
        private void UpdateManaTimerText(float __count) => _timerText.text = __count + "s";
        private void UpdateManaCountText(uint __count) => _manaCountText.text = __count.ToString();
        private void BlockRollButton() => _rollButton.interactable = false;
        private void UnBlockRollButton() => _rollButton.interactable = true;
        private void ShowNewItemPopup() =>
            _windowsMediator.Get<NewItemPopupWindow>().Show(_inventoryItemsCollection.GetRandomItem(), _equippedItem);
        private void UpdateItemIcon(Sprite __icon) => _itemIcon.sprite = __icon;
        private void RestoreMana()
        {
            _manaVessel.Add(1);
            UpdateManaCountText(_manaVessel.ManaCount);
        }
        private void SubscribeActions()
        {
            _rollButton.onClick.AddListener(()=>_manaVessel.Use(1));
            _rollButton.onClick.AddListener(()=> UpdateManaCountText(_manaVessel.ManaCount));
            _rollButton.onClick.AddListener(ShowNewItemPopup);
        }
        public void UpdateEquippedItem(InventoryItemEntity __item)
        {
            _equippedItem = __item;
            
            UpdateItemIcon(__item.Icon);
        }

        protected override void OnShow(object[] __args)
        {
            _inventoryItemsCollection = (InventoryItemsCollection) __args[0];

            UpdateManaCountText(_startManaCount);
            UpdateManaTimerText(_manaRestoreTime);
            _timerService.RunLoopTimer();
            
            SubscribeActions();
        }

        protected override void OnHide()
        {
            CleanUp();
        }
        
        private void CleanUp()
        {
            _inventoryItemsCollection = null;
            _rollButton.onClick.RemoveAllListeners();
        }
    }
}
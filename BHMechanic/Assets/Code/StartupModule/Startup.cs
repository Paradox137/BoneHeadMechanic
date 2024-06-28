using System;
using System.Collections.Generic;
using System.Linq;
using BHMechanic.Code.CollectionModule;
using BHMechanic.Code.ConfigModule;
using BHMechanic.Code.EntityModule;
using BHMechanic.Code.UIModule;
using JetBrains.Annotations;
using UnityEngine;

namespace BHMechanic.Code.StartupModule
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private InventoryItemsConfig _inventoryItemsConfig;
        [SerializeField] private RollWindow _rollWindow; 
        [SerializeField] private NewItemPopupWindow _newItemPopupWindow; 
        
        private InventoryItemsCollection _inventoryItemsCollection;
        private WindowsMediator _windowsMediator;
        private void Awake()
        {
            CreateWorld();
        }

        private void Start()
        {
            _windowsMediator.Get<RollWindow>().Show(_inventoryItemsCollection);
        }

        private void CreateWorld()
        {
            Application.targetFrameRate = 60;

            _windowsMediator = new WindowsMediator();
            _windowsMediator.Add(_rollWindow);
            _windowsMediator.Add(_newItemPopupWindow);
            CreateInventoryCollection();
        }

        private void CreateInventoryCollection()
        {
            List<InventoryItemEntity> entities = 
                _inventoryItemsConfig.InventoryItemEntities.Select(item => new InventoryItemEntity(item)).ToList();

            _inventoryItemsCollection = new InventoryItemsCollection(entities);
        }
        
    }
}
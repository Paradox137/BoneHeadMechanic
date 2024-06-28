using System.Collections.Generic;
using BHMechanic.Code.EntityModule;
using BHMechanic.Code.ExtensionsModule;

namespace BHMechanic.Code.CollectionModule
{
    public class InventoryItemsCollection
    {
        private readonly List<InventoryItemEntity> _inventoryItemEntities;

        public InventoryItemsCollection(List<InventoryItemEntity> __inventoryItemEntities)
        {
            _inventoryItemEntities = __inventoryItemEntities;
        }

        public InventoryItemEntity GetRandomItem()
        {
            return _inventoryItemEntities.RandomElement();
        }
    }
}
using System;
using BHMechanic.Code.EntityModule;

namespace BHMechanic.Code.PlayerData
{
    [Serializable]
    public class PlayerData
    {
        private InventoryItemEntity _entity;

        public InventoryItemEntity Entity
        {
            get => _entity;
            set => _entity = value;
        }
    }
}
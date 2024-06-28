using System;
using System.Collections.Generic;
using BHMechanic.Code.EntityModule;
using UnityEngine;

namespace BHMechanic.Code.ConfigModule
{
    [CreateAssetMenu(fileName = "InventoryItemsConfig", menuName = "MyAssets/Game/Configs/InventoryItemsConfig")]
    public class InventoryItemsConfig : ScriptableObject
    {
        public List<InventoryItemSettings> InventoryItemEntities;
    }

    [Serializable]
    public class InventoryItemSettings
    {
        public string Name;   
        public uint Attack;   
        public uint Health;   
        public uint Defence;  
        public uint Speed;    
        public Sprite Icon;
    }
}
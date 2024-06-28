using System;
using BHMechanic.Code.ConfigModule;
using UnityEngine;

namespace BHMechanic.Code.EntityModule
{
    [Serializable]
    public class InventoryItemEntity
    {
        public string Name   { get; private set; }
        public uint Attack   { get; private set; }
        public uint Health   { get; private set; }
        public uint Defence  { get; private set; }
        public uint Speed    { get; private set; }
        public Sprite Icon   { get; private set; }

        public InventoryItemEntity(InventoryItemSettings __settings)
        {
            Attack = __settings.Attack;
            Health = __settings.Health;
            Defence = __settings.Defence;
            Speed = __settings.Speed;
            Icon = __settings.Icon;
            Name = __settings.Name;
        }
    }
}
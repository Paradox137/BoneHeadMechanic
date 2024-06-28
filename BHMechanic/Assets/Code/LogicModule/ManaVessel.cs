using System;

namespace BHMechanic.Code.LogicModule
{
    public class ManaVessel : IDisposable
    {
        private uint _manaCount;
        private event Action onManaRestore;
        private event Action onManaEmpty;
        public uint ManaCount => _manaCount;
        public ManaVessel(uint __manaCount, Action __onManaRestoreCallBack, Action __onManaEmptyCallBack)
        {
            _manaCount = __manaCount;

            onManaRestore += __onManaRestoreCallBack;
            onManaEmpty += __onManaEmptyCallBack;
        }
        
        public void Add(uint __count)
        {
            _manaCount = ManaCount + __count;
            
            if (ManaCount == 1)
                onManaRestore?.Invoke();
        }

        public void Use(uint __count)
        {
            _manaCount = ManaCount - __count;
            
            if (ManaCount == 0)
                onManaEmpty?.Invoke();
        }

        public void Dispose()
        {
            onManaRestore = null;
            onManaEmpty = null;
        }
    }
}
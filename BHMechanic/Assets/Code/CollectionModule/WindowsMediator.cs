using System;
using System.Collections.Generic;
using BHMechanic.Code.EntityModule;
using BHMechanic.Code.UIModule;

namespace BHMechanic.Code.CollectionModule
{
    public class WindowsMediator : IDisposable
    {
        private List<BaseWindow> _windows;
        
        public WindowsMediator()
        {
            _windows = new List<BaseWindow>();
        }

        public void UpdateItemRollWindow(InventoryItemEntity __item)
        {
            RollWindow rollWindow = (RollWindow)_windows.Find((w => w.GetType() == typeof(RollWindow)));
            
            rollWindow.UpdateEquippedItem(__item);
        }

        public void Add<TWindow>(TWindow __window) where TWindow : BaseWindow
        {
            _windows.Add(__window);
            
            __window.AddMediator(this);
        }

        public BaseWindow Get<TWindow>() where TWindow : BaseWindow
        {
            Type window = typeof(TWindow);
			
            return _windows.Find((w => w.GetType() == window));
        }
		
        public void Dispose()
        {
            _windows = null;
        }
    }
}
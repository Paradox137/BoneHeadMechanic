using BHMechanic.Code.CollectionModule;
using UnityEngine;

namespace BHMechanic.Code.UIModule
{
    public interface IWindow
    {
        void Show(params object[] __args);
        void Hide();
        void OnShow(object[] __args);
        void OnHide();
    }
    public abstract class BaseWindow : MonoBehaviour
    {
        protected Canvas _windowCanvas;
        protected WindowsMediator _windowsMediator;
        protected virtual void Awake()
        {
            _windowCanvas = gameObject.GetComponent<Canvas>();
            
            _windowCanvas.enabled = false;
        }

        public void AddMediator(WindowsMediator __mediator)
        {
            _windowsMediator = __mediator;
        }
        
        public void Show(params object[] __args)
        {
            OnShow(__args);
            
            _windowCanvas.enabled = true;
        }
		
        public void Show()
        {
            _windowCanvas.enabled = true;
        }

        protected void Hide()
        {
            _windowCanvas.enabled = false;
            
            OnHide();
        }

        protected abstract void OnShow(object[] __args);

        protected abstract void OnHide();
    }
}
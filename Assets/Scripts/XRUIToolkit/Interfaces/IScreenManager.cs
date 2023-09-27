using UnityEngine;

namespace XRProtoUIToolKit
{
    public interface IScreenManager
    {
        Transform Transform { get; set; }
        bool IsActive { get; set; }
        void ExecuteAction(Object sender);
        void Hide(ScreenManagerCallback Callback);
        void Show();
        IUIElement[] Elements { get; set; }
        int GetUIElementArrayPosition(IUIElement element);
    }
}

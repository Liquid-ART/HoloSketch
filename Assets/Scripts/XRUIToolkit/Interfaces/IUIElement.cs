
namespace XRProtoUIToolKit
{
    public interface IUIElement
    {
        ScreenManager ScreenManager { get; set; }
        int ElementIndex { get; set; }
        bool IgnoreGroupEvents { get; set; }
        bool IsHiden { get; set; }
        void Init();
        void UpdateHierarchyIndex();
        void Show(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback);
        void Show(float delay);
        void Hide(float delay, float interval, bool sendToNextElement, ElementsOrder elementsOrder, ScreenManagerCallback Callback);
        void Hide(float delay);
    }
}

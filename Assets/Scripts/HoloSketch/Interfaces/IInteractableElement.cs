using UnityEngine.EventSystems;

namespace HoloSketch
{

    public interface IInteractableElement
    {
        bool DisabledInPrototype { get; }
        bool IsLocked { get; set; }

        void Unlock();
        void Lock();
        void SetDisabledInPrototype();

        void OnPointerClick();
        void OnPointerDown();
        void OnPointerEnter();
        void OnPointerExit();
        void OnPointerUp();
    }
}
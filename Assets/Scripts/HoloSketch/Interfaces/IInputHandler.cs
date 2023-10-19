using UnityEngine;
using System.Collections;

public interface IInputHandler
{
    void Init();
    void SetInteractionLocked();
    void SetInteractionUnlocked();

}

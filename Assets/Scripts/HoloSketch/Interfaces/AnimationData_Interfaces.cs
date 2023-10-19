using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HoloSketch
{
    public interface IAnimationData_Screen
    {
        public ITweenAnimation Show { get; set; }
    }
    
    public interface IAnimationData_UI_Element
    {
      //  void Init(GameObject _thisObj);

        public ITweenAnimation Show { get; set; }
    }

    public interface IAnimationData_InteractableElement : IAnimationData_UI_Element
    {
        ITweenAnimation Hover { get; set; }
        ITweenAnimation Press { get; set; }
        ITweenAnimation Block { get; set; }
    }

    public interface IAnimationData_CheckBox : IAnimationData_InteractableElement
    {
        public ITweenAnimation HoverSelected { get; set; }
    }

    public interface IAnimationData_RadioButtonVolumetric: IAnimationData_InteractableElement
    {
        public ITweenAnimation ShowSelected { get; set; }
    }


}
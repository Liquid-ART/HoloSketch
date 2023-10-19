using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace HoloSketch
{
    //Сделать метод Action универсальным

    // Сделать чтобы все анимации кешировали начальное состояние а надо ли?
    //УБрать связь с одином
    //Расширить палитру
    //Избавиться от обязательно назначения OnComplete, Delay, Ease в TweenAnimation
    //Понять как взаимодействовать с курсорами и системами ввода

    //Попробовать добавить сериализацию значений анимаций
    //Сделать чтобы Init GroupManager вызывался в абстракте, переименовать в ScreenManager
    //Разрезать 
    //Обьеденить EventRecieverы, прописать RequireComponenet в IE
    //SnapMove - пофиксить очередь, сейчас можно кликнуть когда играет и нельзя отключить добавление 
    //Добавить поддержку вложенности GroupManager и SnapMove
    //Баг TweenAnimation: IsPLaying true когда анимация завершена, SetDuration не работает по крайней мере у ServerList Group
    //Баг SnapMove: 2й каллбек в очереди вызывается немедленно, очередь работает неправильно(не дожидается окончания прокрутки)

    [AddComponentMenu("InterfacePrototyping/Button")]
    public class Button : InteractableElement, IButton
    {
        public override void Init()
        {
            base.Init();
        }

        public override void OnPointerClick()
        {
            base.OnPointerClick();

        }
 
    }

}

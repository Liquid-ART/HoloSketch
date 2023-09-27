using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace XRProtoUIToolKit
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ButtonDefaultAnims : UIElementDefaultAnims, IAnimationData_CheckBox
    {
        [Space]
        public Image bg;

        [Space]
        [HideInInspector]
        public bool
            HasText = false,
            HasIcon = false,
            HasGraphicElement = false,
            HasGraphicElement2 = false,
            HasShape;



        [HideInInspector]
        public TMP_Text text;

        [HideInInspector]
        public Image icon;

        [HideInInspector]
        public Image graphicElement;

        [HideInInspector]
        public Image graphicElement2;

        [HideInInspector]
        public Transform shape;

        [HideInInspector]
        public Ease

        HoverEasePlay = Ease.InSine,
        HoverEasePlayBackwards = Ease.OutSine,

        PressEasePlay = Ease.InSine,
        PressEasePlayBackwards = Ease.OutSine,

        LockEasePlay = Ease.InSine,
        LockEasePlayBackwards = Ease.OutSine;

        [HideInInspector]
        public float
        HoverDuration = 0.3f,
        PressDuration = 0.3f,
        LockDuration = 0.3f;


        [HideInInspector, Space]
        public bool HasHoverAnimation = false;

        [HideInInspector, Space]
        public bool HasPressAnimation = false;

        [HideInInspector, Space]
        public bool HasLockAnimation = false;


        [HideInInspector]
        public float
            scaleHover = 1f,
            scalePress = 1f,

            iconScaleHover = 1f,
            iconScalePress = 1f,
            zMoveIconHover = 0f,//
            zMoveIconPress = 0f,//

            textScaleDefault = 1f,
            textScaleHover = 1f,

            scaleGraphicElementHover = 1f,
            scaleGraphicElementPress = 1f,
            zMoveGrElmntHover = 0f,//
            zMoveGrElmntPress = 0f,//

            scaleGraphicElement2Hover = 1f,//
            scaleGraphicElement2Press = 1f,//
            zMoveGrElmnt2Hover = 0f,//
            zMoveGrElmnt2Press = 0f,//

            zMoveHover = 0f,
            zMovePress = 0f;



        [HideInInspector]
        public Vector3
            StartPosLocal,

            IconStartPosLocal,

            GrElementPosDefault,
            GrElementRotDefault,
            GrElementRotHover,
            GrElementRotPress,

            GrElement2PosDefault,
            GrElement2RotDefault,
            GrElement2RotHover,
            GrElement2RotPress,

            ShapeRotHover;



        [HideInInspector]
        public Color

            bgDefaultColor = Color.black,
            bgHoverColor = Color.black,
            bgPressColor = Color.black,
            bgLockColor = Color.black,

            textDefaultColor = Color.black,
            textHoverColor = Color.black,
            textPressColor = Color.black,
            textLockColor = Color.black,

            iconDefaultColor = Color.black,
            iconHoverColor = Color.black,
            iconPressColor = Color.black,
            iconLockColor = Color.black, 

            grElementDefaultColor = Color.black,
            grElementHoverColor = Color.black,
            grElementPressColor = Color.black,
            grElementLockColor = Color.black, 

            grElement2DefaultColor = Color.black,
            grElement2HoverColor = Color.black,
            grElement2PressColor = Color.black,
            grElement2LockColor = Color.black; 


        
        public ITweenAnimation Hover { get; set; }
        public ITweenAnimation HoverSelected { get; set; }
        public ITweenAnimation Press { get; set; }
        public ITweenAnimation Block { get; set; }

        public override void Init()
        {
            base.Init();

            StartPosLocal = transform.localPosition;



            bgDefaultColor = bg.color;


            if (HasIcon) 
            { 
              iconDefaultColor = icon.color;
              IconStartPosLocal = icon.transform.localPosition;

            }
            if (HasText) 
            {
                textScaleDefault = text.transform.localScale.x;
                textDefaultColor = text.color;
            }

            if (HasGraphicElement) 
            {
                grElementDefaultColor = graphicElement.color;
                GrElementRotDefault = graphicElement.transform.localEulerAngles;
            }

            if (HasGraphicElement2) 
            {
                grElement2DefaultColor = graphicElement2.color;
                GrElementRotDefault = graphicElement.transform.localEulerAngles;
            }



            Hover = new DefaultButtonHover();
            Hover.Init(gameObject);

            Press = new DefaultButtonPress();
            Press.Init(gameObject);

            Block = new DefaultButtonLock();
            Block.Init(gameObject);

        }

        void Awake()
        {
            Init();
        }

    }



    public class DefaultButtonHover : TweenAnimation
    {

        protected ButtonDefaultAnims animData;
        public override void Init(GameObject _thisObj)
        {
            base.Init(_thisObj);
            animData = thisObj.GetComponent<ButtonDefaultAnims>();
        }

        public override TweenAnimation Play()
        {

            if (!animData.HasHoverAnimation)
            {
                animCache.OnCompleteCallback();
                return this;
            }

            animCache.StartCallback = () =>
            {

                NewTween(animData.bg.DOColor(animData.bgHoverColor, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlay).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

                NewTween(Transform.DOScale(animData.scaleHover, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlay));

                NewTween(Transform.DOLocalMoveZ(animData.StartPosLocal.z + animData.zMoveHover, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlay));

                if (animData.HasText)
                {
                    NewTween(animData.text.DOColor(animData.textHoverColor, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlay)); ;

                    NewTween(animData.text.transform.DOScale(animData.textScaleHover, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlay)); ;
                }

                if (animData.HasGraphicElement)
                {
                    NewTween(animData.graphicElement.DOColor(animData.grElementHoverColor, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlay)); ;
                    
                    NewTween(animData.graphicElement.transform.DOScale(animData.scaleGraphicElementHover, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlay));

                    NewTween(animData.graphicElement.transform.DOLocalMoveZ(animData.GrElementPosDefault.z + animData.zMoveGrElmntHover, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay));

                    NewTween(animData.graphicElement.transform.DOLocalRotate(animData.GrElementRotHover, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay));
                }

                if (animData.HasGraphicElement2)
                {
                    NewTween(animData.graphicElement2.DOColor(animData.grElement2HoverColor, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlay)); ;

                    NewTween(animData.graphicElement2.transform.DOScale(animData.scaleGraphicElement2Hover, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlay));

                    NewTween(animData.graphicElement2.transform.DOLocalMoveZ(animData.GrElement2PosDefault.z + animData.zMoveGrElmntHover, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay));

                    NewTween(animData.graphicElement2.transform.DOLocalRotate(animData.GrElement2RotHover, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay));
                }


                if (animData.HasIcon)
                {
                    NewTween(animData.icon.transform.DOScale(animData.iconScaleHover, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay));

                    NewTween(animData.icon.transform.DOLocalMoveZ(animData.IconStartPosLocal.z + animData.zMoveIconHover, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay));


                    NewTween(animData.icon.DOColor(animData.iconHoverColor, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlay)); ;
                }

                if (animData.HasShape)
                {
                    Quaternion targetQuaternion = Quaternion.Euler(animData.ShapeRotHover);
                    NewTween(animData.shape.DOLocalRotateQuaternion(targetQuaternion, animData.HoverDuration)
                    .SetEase(animData.HoverEasePlay));
                }


            };

            RunAnimation();

            return this;
        }



        public override TweenAnimation PlayBackwards()
        {

            if (!animData.HasHoverAnimation)
            {
                animCache.OnCompleteCallback();
                return this;
            }

            animCache.StartCallback = () =>
            {

                NewTween(animData.bg.DOColor(animData.bgDefaultColor, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlayBackwards).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

                NewTween(Transform.DOScale(1, animData.HoverDuration).SetDelay(CurrentCache.Delay)
                                .SetEase(animData.HoverEasePlayBackwards));

                NewTween(Transform.DOLocalMoveZ(animData.StartPosLocal.z, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlayBackwards));

                if (animData.HasText)
                {
                    NewTween(animData.text.DOColor(animData.textDefaultColor, animData.HoverDuration)
                               .SetEase(animData.HoverEasePlayBackwards)); ;

                    NewTween(animData.text.transform.DOScale(animData.textScaleDefault, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlay)); ;
                }


                if (animData.HasGraphicElement)
                {
                    NewTween(animData.graphicElement.DOColor(animData.grElementDefaultColor, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlayBackwards)); ;

                    NewTween(animData.graphicElement.transform.DOScale(1, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.graphicElement.transform.DOLocalMoveZ(animData.GrElement2PosDefault.z, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.graphicElement.transform.DOLocalRotate(animData.GrElementRotDefault, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));
                }

                if (animData.HasGraphicElement2)
                {
                    NewTween(animData.graphicElement2.DOColor(animData.grElement2DefaultColor, animData.HoverDuration)
                           .SetEase(animData.HoverEasePlayBackwards)); ;

                    NewTween(animData.graphicElement2.transform.DOScale(1, animData.HoverDuration)
                                .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.graphicElement2.transform.DOLocalMoveZ(animData.GrElement2PosDefault.z, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.graphicElement2.transform.DOLocalRotate(animData.GrElement2RotDefault, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));
                }

                if (animData.HasIcon)
                {
                    
                    NewTween(animData.icon.transform.DOScale(1, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.icon.transform.DOLocalMoveZ(animData.IconStartPosLocal.z, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.icon.DOColor(animData.iconDefaultColor, animData.HoverDuration)
                                    .SetEase(animData.HoverEasePlayBackwards)); ;

                }

            };

            RunAnimation();

            return this;

        }
    }

    public class DefaultButtonPress : TweenAnimation
    {

        protected ButtonDefaultAnims animData;

        public override void Init(GameObject _thisObj)
        {
            base.Init(_thisObj);
            animData = thisObj.GetComponent<ButtonDefaultAnims>();
        }

        public override TweenAnimation Play()
        {

            if (!animData.HasPressAnimation)
            {
                animCache.OnCompleteCallback();
                return this;
            }



            animCache.StartCallback = () =>
            {

                NewTween(animData.bg.DOColor(animData.bgPressColor, animData.PressDuration)
                                .SetEase(animData.PressEasePlay).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

                NewTween(Transform.DOScale(animData.scalePress, animData.PressDuration)
                                .SetEase(animData.PressEasePlay));

                NewTween(Transform.DOLocalMoveZ(animData.StartPosLocal.z + animData.zMovePress, animData.PressDuration)
                                .SetEase(animData.PressEasePlay));

                if (animData.HasText)
                {
                    NewTween(animData.text.DOColor(animData.textPressColor, animData.PressDuration)
                           .SetEase(animData.PressEasePlay)); ;
                }

                if (animData.HasGraphicElement)
                {
                    NewTween(animData.graphicElement.DOColor(animData.grElementPressColor, animData.PressDuration)
                           .SetEase(animData.PressEasePlay)); ;

                    NewTween(animData.graphicElement.transform.DOScale(animData.scaleGraphicElementPress, animData.PressDuration)
                                .SetEase(animData.PressEasePlay));

                    NewTween(animData.graphicElement.transform.DOLocalMoveZ(animData.GrElementPosDefault.z + animData.zMoveGrElmntPress, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay));

                    NewTween(animData.graphicElement.transform.DOLocalRotate(animData.GrElementRotPress, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay));
                }

                if (animData.HasGraphicElement2)
                {
                    NewTween(animData.graphicElement2.DOColor(animData.grElement2PressColor, animData.PressDuration)
                           .SetEase(animData.PressEasePlay)); ;

                    NewTween(animData.graphicElement2.transform.DOScale(animData.scaleGraphicElement2Press, animData.PressDuration)
                                .SetEase(animData.PressEasePlay));

                    NewTween(animData.graphicElement2.transform.DOLocalMoveZ(animData.GrElement2PosDefault.z + animData.zMoveGrElmntPress, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay));

                    NewTween(animData.graphicElement2.transform.DOLocalRotate(animData.GrElement2RotPress, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay));
                }


                if (animData.HasIcon)
                {
                    NewTween(animData.icon.transform.DOScale(animData.iconScalePress, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay));

                    NewTween(animData.icon.transform.DOLocalMoveZ(animData.IconStartPosLocal.z + animData.zMoveIconPress, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay));

                    NewTween(animData.icon.DOColor(animData.iconPressColor, animData.PressDuration)
                                    .SetEase(animData.PressEasePlay)); ;
                }


            };

            RunAnimation();

            return this;
        }



        public override TweenAnimation PlayBackwards()
        {

            animCache.StartCallback = () =>
            {

                NewTween(animData.bg.DOColor(animData.bgHoverColor, animData.PressDuration)
                                .SetEase(animData.PressEasePlayBackwards).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

                NewTween(Transform.DOScale(animData.scaleHover, animData.PressDuration)
                                .SetEase(animData.PressEasePlayBackwards));

                NewTween(Transform.DOLocalMoveZ(animData.StartPosLocal.z + animData.zMoveHover, animData.PressDuration)
                                .SetEase(animData.HoverEasePlayBackwards));

                if (animData.HasText)
                    NewTween(animData.text.DOColor(animData.textHoverColor, animData.PressDuration)
                               .SetEase(animData.HoverEasePlayBackwards)); ;

                if (animData.HasGraphicElement)
                {
                    NewTween(animData.graphicElement.DOColor(animData.grElementHoverColor, animData.PressDuration)
                           .SetEase(animData.HoverEasePlayBackwards)); ;

                    NewTween(animData.graphicElement.transform.DOScale(animData.scaleGraphicElementHover, animData.PressDuration)
                                .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.graphicElement.transform.DOLocalMoveZ(animData.GrElementPosDefault.z + animData.zMoveGrElmntHover, animData.PressDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.graphicElement.transform.DOLocalRotate(animData.GrElementRotHover, animData.PressDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));
                }

                if (animData.HasIcon)
                {

                    NewTween(animData.icon.transform.DOScale(animData.iconScaleHover, animData.PressDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.icon.transform.DOLocalMoveZ(animData.IconStartPosLocal.z + animData.zMoveIconHover, animData.PressDuration)
                                    .SetEase(animData.HoverEasePlayBackwards));

                    NewTween(animData.icon.DOColor(animData.iconHoverColor, animData.PressDuration)
                                    .SetEase(animData.HoverEasePlayBackwards)); ;

                }

            };

            RunAnimation();

            return this;

        }
    }

    public class DefaultButtonLock : TweenAnimation
    {

        protected ButtonDefaultAnims animData;
        public override void Init(GameObject _thisObj)
        {
            base.Init(_thisObj);
            animData = thisObj.GetComponent<ButtonDefaultAnims>();
        }

        public override TweenAnimation Play()
        {

            animCache.StartCallback = () =>
            {

                NewTween(animData.bg.DOColor(animData.bgLockColor, animData.LockDuration)
                                .SetEase(animData.LockEasePlay).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

                if(animData.HasIcon)
                NewTween(animData.icon.DOColor(animData.iconLockColor, animData.LockDuration)
                                .SetEase(animData.LockEasePlay)); ;

                if (animData.HasText)
                    NewTween(animData.text.DOColor(animData.textLockColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlay)); ;

                if (animData.HasGraphicElement)
                    NewTween(animData.graphicElement.DOColor(animData.grElementLockColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlay)); ;

                if (animData.HasGraphicElement2)
                    NewTween(animData.graphicElement2.DOColor(animData.grElement2LockColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlay)); ;

                if (animData.HasGraphicElement2)
                    NewTween(animData.text.DOColor(animData.grElement2LockColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlay)); ;


            };

            RunAnimation();

            return this;
        }



        public override TweenAnimation PlayBackwards()
        {

            animCache.StartCallback = () =>
            {

                NewTween(animData.bg.DOColor(animData.bgDefaultColor, animData.LockDuration)
                                .SetEase(animData.LockEasePlayBackwards).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

                if (animData.HasIcon)
                    NewTween(animData.icon.DOColor(animData.iconDefaultColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlayBackwards)); ;

                if (animData.HasText)
                    NewTween(animData.text.DOColor(animData.textDefaultColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlayBackwards)); ;

                if (animData.HasGraphicElement)
                    NewTween(animData.graphicElement.DOColor(animData.grElementDefaultColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlayBackwards)); ;

                if (animData.HasGraphicElement2)
                    NewTween(animData.graphicElement2.DOColor(animData.grElement2DefaultColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlayBackwards)); ;

                if (animData.HasGraphicElement2)
                    NewTween(animData.text.DOColor(animData.grElement2DefaultColor, animData.LockDuration)
                                    .SetEase(animData.LockEasePlayBackwards)); ;
            };

            RunAnimation();

            return this;

        }
    }

}


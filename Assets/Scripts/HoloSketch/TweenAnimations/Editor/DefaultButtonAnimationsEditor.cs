using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace HoloSketch
{

    [CustomEditor(typeof(ButtonDefaultAnims)), CanEditMultipleObjects]
    public class DefaultButtonAnimationsEditor : Editor
    {

        private SerializedProperty hasIconProp;
        private SerializedProperty iconProp;
        private SerializedProperty zMoveIconHoverProp;
        private SerializedProperty zMoveIconPressProp;
        private SerializedProperty iconScaleHoverProp;
        private SerializedProperty iconHoverColorProp;
        private SerializedProperty iconPressColorProp;
        private SerializedProperty iconScalePressProp;
        private SerializedProperty iconLockColorProp;
        


        private SerializedProperty hasTextProp;
        private SerializedProperty textProp;
        private SerializedProperty textHoverColorProp;
        private SerializedProperty textPressColorProp;
        private SerializedProperty textLockColorProp; 
        private SerializedProperty textScaleHoverProp;

        private SerializedProperty hasGraphicElementProp;
        private SerializedProperty graphicElementProp;
        private SerializedProperty grElementHoverColorProp;
        private SerializedProperty grElementPressColorProp;
        private SerializedProperty grElementLockColorProp;
        private SerializedProperty scaleGrElementHoverProp;
        private SerializedProperty scaleGrElementPressProp;
        private SerializedProperty zMoveGrElmntHoverProp;
        private SerializedProperty zMoveGrElmntPressProp;
        private SerializedProperty GrElementRotHoverProp;
        private SerializedProperty GrElementRotPressProp;

        private SerializedProperty hasGraphicElement2Prop;
        private SerializedProperty graphicElement2Prop;
        private SerializedProperty grElement2HoverColorProp;
        private SerializedProperty grElement2PressColorProp;
        private SerializedProperty grElement2LockColorProp;
        private SerializedProperty scaleGrElement2HoverProp;
        private SerializedProperty scaleGrElement2PressProp;
        private SerializedProperty zMoveGrElmnt2HoverProp;
        private SerializedProperty zMoveGrElmnt2PressProp;
        private SerializedProperty GrElement2RotHoverProp;
        private SerializedProperty GrElement2RotPressProp;


        private SerializedProperty HasShapeProp;
        private SerializedProperty shapeProp;
        private SerializedProperty ShapeRotHoverProp;

        //hover
        private SerializedProperty HasHoverAnimationProp;
        private SerializedProperty scaleHoverProp;
        private SerializedProperty bgHoverColorProp;

        private SerializedProperty zMoveHoverProp;
        private SerializedProperty hoverDurationProp;
        private SerializedProperty HoverEasePlayProp;
        private SerializedProperty HoverEasePlayBackwardsProp;

        //press
        private SerializedProperty HasPressAnimationProp;
        private SerializedProperty scalePressProp;
        private SerializedProperty bgPressColorProp;

        private SerializedProperty zMovePressProp;
        private SerializedProperty pressDurationProp;
        private SerializedProperty PressEasePlayProp;
        private SerializedProperty PressEasePlayBackwardsProp;

        //lock
        private SerializedProperty HasLockAnimationProp;
        private SerializedProperty bgLockColorProp;
        private SerializedProperty lockDurationProp;
        private SerializedProperty LockEasePlayProp;
        private SerializedProperty LockEasePlayBackwardsProp;

        private void OnEnable()
        {
            hasTextProp = serializedObject.FindProperty("HasText");
            textProp = serializedObject.FindProperty("text");
            textHoverColorProp = serializedObject.FindProperty("textHoverColor");
            textPressColorProp = serializedObject.FindProperty("textPressColor");
            textLockColorProp = serializedObject.FindProperty("textLockColor");
            textScaleHoverProp = serializedObject.FindProperty("textScaleHover");

            hasIconProp = serializedObject.FindProperty("HasIcon");
            iconProp = serializedObject.FindProperty("icon");
            iconScaleHoverProp = serializedObject.FindProperty("iconScaleHover");
            iconScalePressProp = serializedObject.FindProperty("iconScalePress");
            zMoveIconHoverProp = serializedObject.FindProperty("zMoveIconHover");
            zMoveIconPressProp = serializedObject.FindProperty("zMoveIconPress");


            iconHoverColorProp = serializedObject.FindProperty("iconHoverColor");
            iconPressColorProp = serializedObject.FindProperty("iconPressColor");
            iconLockColorProp = serializedObject.FindProperty("iconLockColor");


            hasGraphicElementProp = serializedObject.FindProperty("HasGraphicElement");//++
            graphicElementProp = serializedObject.FindProperty("graphicElement");//++
            scaleGrElementHoverProp = serializedObject.FindProperty("scaleGraphicElementHover");
            grElementHoverColorProp = serializedObject.FindProperty("grElementHoverColor");
            scaleGrElementPressProp = serializedObject.FindProperty("scaleGraphicElementPress");
            grElementPressColorProp = serializedObject.FindProperty("grElementPressColor");
            grElementLockColorProp = serializedObject.FindProperty("grElementLockColor");
            GrElementRotHoverProp = serializedObject.FindProperty("GrElementRotHover");
            GrElementRotPressProp = serializedObject.FindProperty("GrElementRotPress");
            zMoveGrElmntHoverProp = serializedObject.FindProperty("zMoveGrElmntHover");
            zMoveGrElmntPressProp = serializedObject.FindProperty("zMoveGrElmntPress");


            hasGraphicElement2Prop = serializedObject.FindProperty("HasGraphicElement2");//++
            graphicElement2Prop = serializedObject.FindProperty("graphicElement2");//++
            scaleGrElement2HoverProp = serializedObject.FindProperty("scaleGraphicElement2Hover");
            grElement2HoverColorProp = serializedObject.FindProperty("grElement2HoverColor");
            scaleGrElement2PressProp = serializedObject.FindProperty("scaleGraphicElement2Press");
            grElement2PressColorProp = serializedObject.FindProperty("grElement2PressColor");
            grElement2LockColorProp = serializedObject.FindProperty("grElement2LockColor");
            GrElement2RotHoverProp = serializedObject.FindProperty("GrElement2RotHover");
            GrElement2RotPressProp = serializedObject.FindProperty("GrElement2RotPress");
            zMoveGrElmnt2HoverProp = serializedObject.FindProperty("zMoveGrElmnt2Hover");
            zMoveGrElmnt2PressProp = serializedObject.FindProperty("zMoveGrElmnt2Press");


            HasShapeProp = serializedObject.FindProperty("HasShape");
            shapeProp = serializedObject.FindProperty("shape");
            ShapeRotHoverProp = serializedObject.FindProperty("ShapeRotHover");



            HasHoverAnimationProp = serializedObject.FindProperty("HasHoverAnimation");//++
            scaleHoverProp = serializedObject.FindProperty("scaleHover");//++
            bgHoverColorProp = serializedObject.FindProperty("bgHoverColor");//++
            zMoveHoverProp = serializedObject.FindProperty("zMoveHover");//++
            hoverDurationProp = serializedObject.FindProperty("HoverDuration");//++
            HoverEasePlayProp = serializedObject.FindProperty("HoverEasePlay");//++
            HoverEasePlayBackwardsProp = serializedObject.FindProperty("HoverEasePlayBackwards");//++


            HasPressAnimationProp =  serializedObject.FindProperty("HasPressAnimation");
            scalePressProp = serializedObject.FindProperty("scalePress");//++
            bgPressColorProp = serializedObject.FindProperty("bgPressColor");//++
            zMovePressProp = serializedObject.FindProperty("zMovePress");//++
            pressDurationProp = serializedObject.FindProperty("PressDuration");//++
            PressEasePlayProp = serializedObject.FindProperty("PressEasePlay");//++
            PressEasePlayBackwardsProp = serializedObject.FindProperty("PressEasePlayBackwards");//++

            HasLockAnimationProp = serializedObject.FindProperty("HasLockAnimation");//++
            bgLockColorProp = serializedObject.FindProperty("bgLockColor");//++
            LockEasePlayProp = serializedObject.FindProperty("LockEasePlay");//++
            lockDurationProp = serializedObject.FindProperty("LockDuration");
            LockEasePlayBackwardsProp = serializedObject.FindProperty("LockEasePlayBackwards");

        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();



            //--- hover

            EditorGUILayout.PropertyField(HasHoverAnimationProp);
            if (HasHoverAnimationProp.boolValue)
            {

                EditorGUILayout.PropertyField(bgHoverColorProp);
                EditorGUILayout.PropertyField(scaleHoverProp);
                EditorGUILayout.PropertyField(zMoveHoverProp);
                EditorGUILayout.PropertyField(hoverDurationProp);

                EditorGUILayout.PropertyField(HoverEasePlayProp);
                EditorGUILayout.PropertyField(HoverEasePlayBackwardsProp);




             }


            //--- press

            EditorGUILayout.PropertyField(HasPressAnimationProp);
            if (HasPressAnimationProp.boolValue)
            {

                EditorGUILayout.PropertyField(bgPressColorProp);
                EditorGUILayout.PropertyField(scalePressProp);
                EditorGUILayout.PropertyField(zMovePressProp);
                EditorGUILayout.PropertyField(pressDurationProp);

                EditorGUILayout.PropertyField(PressEasePlayProp);
                EditorGUILayout.PropertyField(PressEasePlayBackwardsProp);






            }


            //lock


            EditorGUILayout.PropertyField(HasLockAnimationProp);
            if (HasLockAnimationProp.boolValue)
            {

                EditorGUILayout.PropertyField(bgLockColorProp);
                EditorGUILayout.PropertyField(lockDurationProp);

                EditorGUILayout.PropertyField(LockEasePlayProp);
                EditorGUILayout.PropertyField(LockEasePlayBackwardsProp);






            }

            EditorGUILayout.PropertyField(hasIconProp);
            if (hasIconProp.boolValue)
            {
                EditorGUILayout.PropertyField(iconProp);
                if (HasHoverAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(iconHoverColorProp);
                    EditorGUILayout.PropertyField(iconScaleHoverProp);
                    EditorGUILayout.PropertyField(zMoveIconHoverProp);

                }

                if (HasPressAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(iconPressColorProp);
                    EditorGUILayout.PropertyField(iconScalePressProp);
                    EditorGUILayout.PropertyField(zMoveIconPressProp);
                }

                if (HasLockAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(iconLockColorProp);
                }

            }

            EditorGUILayout.PropertyField(hasTextProp);
            if (hasTextProp.boolValue)
            {
                EditorGUILayout.PropertyField(textProp);
                if (HasHoverAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(textHoverColorProp);
                    EditorGUILayout.PropertyField(textScaleHoverProp);

                }

                if (HasPressAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(textPressColorProp);

                }

                if (HasLockAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(textLockColorProp);

                }

            }

            EditorGUILayout.PropertyField(HasShapeProp);
            if (HasShapeProp.boolValue)
            {
                EditorGUILayout.PropertyField(shapeProp);
                if(HasHoverAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(ShapeRotHoverProp);
                }
            }


            EditorGUILayout.PropertyField(hasGraphicElementProp);
            if (hasGraphicElementProp.boolValue)
            {
                EditorGUILayout.PropertyField(graphicElementProp);
                if (HasHoverAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(grElementHoverColorProp);
                    EditorGUILayout.PropertyField(scaleGrElementHoverProp);
                    EditorGUILayout.PropertyField(zMoveGrElmntHoverProp);
                    EditorGUILayout.PropertyField(GrElementRotHoverProp);
                }

                if (HasPressAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(grElementPressColorProp);
                    EditorGUILayout.PropertyField(scaleGrElementPressProp);
                    EditorGUILayout.PropertyField(zMoveGrElmntPressProp);
                    EditorGUILayout.PropertyField(GrElementRotPressProp);
                }

                if (HasLockAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(grElementLockColorProp);
                }

            }

            EditorGUILayout.PropertyField(hasGraphicElement2Prop);
            if (hasGraphicElement2Prop.boolValue)
            {
                EditorGUILayout.PropertyField(graphicElement2Prop);
                if (HasHoverAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(grElement2HoverColorProp);
                    EditorGUILayout.PropertyField(scaleGrElement2HoverProp);
                    EditorGUILayout.PropertyField(zMoveGrElmnt2HoverProp);
                    EditorGUILayout.PropertyField(GrElement2RotHoverProp);
                }

                if (HasPressAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(grElement2PressColorProp);
                    EditorGUILayout.PropertyField(scaleGrElement2PressProp);
                    EditorGUILayout.PropertyField(zMoveGrElmnt2PressProp);
                    EditorGUILayout.PropertyField(GrElement2RotPressProp);
                }

                if (HasLockAnimationProp.boolValue)
                {
                    EditorGUILayout.PropertyField(grElement2LockColorProp);
                }

            }


            serializedObject.ApplyModifiedProperties();
            


        }
    }
}


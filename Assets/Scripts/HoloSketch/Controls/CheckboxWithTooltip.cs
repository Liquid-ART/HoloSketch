

namespace HoloSketch
{

    public class CheckboxWithTooltip : Checkbox, ICheckbox
    {
        private Button tooltipButton;

        private bool buttonIsHiddenOnStart = false;

        public override void Init()
        {
            base.Init();
            tooltipButton = GetComponentInChildren<Button>();
        }

        private void Update()
        {
            if(!buttonIsHiddenOnStart)
            {
                tooltipButton.Hide(0);
                buttonIsHiddenOnStart = true;
            }

        }

        public override void OnPointerEnter()
        {
            base.OnPointerEnter();
            tooltipButton.Show(0);
        }

        public override void OnPointerExit()
        {
            base.OnPointerExit();
            tooltipButton.Hide(0);
        }


    }
}



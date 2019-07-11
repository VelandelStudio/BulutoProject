using UnityEngine;

namespace SelectorService
{
    public abstract class SelectableImpl : MonoBehaviour, ISelectable
    {
        public bool IsSelectable { get; set; }
        public bool IsOvered { get; set; }

        private void Clicked()
        {
            IsSelectable = false;
            SelectionController.INSTANCE.SelectElement(this);
            OnClick();
        }

        protected virtual void Awake()
        {
            IsSelectable = true;
            IsOvered = false;
        }

        protected virtual void Update()
        {
            if (IsOvered)
            {
                if (IsSelectable && Input.GetMouseButtonDown(0))
                {
                    Clicked();
                }
            }
        }

        private void OnMouseEnter()
        {
            IsOvered = true;
            //Debug.Log("Overing object : " + gameObject);
            MouseOver();
        }

        private void OnMouseExit()
        {
            IsOvered = false;
        }

        public abstract void MouseOver();
        public abstract void OnClick();
    }
}

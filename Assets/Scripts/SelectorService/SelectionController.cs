using UnityEngine;

namespace SelectorService
{
    public class SelectionController
    {
        public ISelectable SelectedElement
        {
            get;
            private set;
        }

        private static SelectionController instance;
        public static SelectionController INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new SelectionController();
                }
                return instance;
            }
        }

        public void SelectElement(ISelectable newSelected)
        {
            if (SelectedElement != null)
            {
                SelectedElement.IsSelectable = true;
            }
            SelectedElement = newSelected;
            Debug.Log(newSelected + " is selected.");
        }
    }
}

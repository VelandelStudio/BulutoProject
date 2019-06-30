using UnityEngine;

namespace SelectorService
{
    public class LivingEntitySelectable : SelectableImpl
    {
        public override void MouseOver()
        {
            if (IsSelectable)
            {
                Debug.Log("I am a living Entity ! If you click on me, i will display some info !");
            }
            else
            {
                Debug.Log("I am a living Entity ! But i am not selectable yet ! If you click on my, nothing will happen !");
            }
        }

        public override void OnClick()
        {
            Debug.Log("You clicked on me ! Now you can choos to attack or heal me !");
        }
    }
}

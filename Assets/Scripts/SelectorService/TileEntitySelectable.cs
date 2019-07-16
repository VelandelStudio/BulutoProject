using System.Collections.Generic;
using UnityEngine;

namespace SelectorService
{
    public class TileEntitySelectable : SelectableImpl
    {
        private TileStats tile;

        void Start()
        {
            tile = GetComponent<TileStats>();
        }

        public override void MouseOver()
        {
            if (IsSelectable)
            {
                // Debug.Log("I am a tile Entity ! I should display at this point if you can move to me or not !");
            }
            else
            {
                // Debug.Log("I am a tile Entity ! But i am not selectable yet ! If you click on my, nothing will happen !");
            }
        }

        public override void OnClick()
        {
            // Debug.Log("You clicked on me ! If you have enough move points and if a path is available, i shoudl tell you how to come to me. If, you don't i should display and error message on your screen.");

            GameObject heroToMove = ManageGame.instance.SelectedHero;

            int startX = heroToMove.GetComponent<HeroMovement>().xPos;
            int startZ = heroToMove.GetComponent<HeroMovement>().zPos;
            int endX = tile.x;
            int endZ = tile.z;

            ManageActions.instance.pathConstructor.SetDistance(startX, startZ);
            ManageActions.instance.pathConstructor.SetPath(endX, endZ);

            List<GameObject> path = ManageActions.instance.pathConstructor.path;
            path.Reverse();

            heroToMove.GetComponent<HeroMovement>().path = path;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    //hero placement on grid
    public int xPos;
    public int zPos;

    public bool isActivated = true;

    void Start()
    {
        int delta = ManageActions.instance.pathConstructor.delta;
        int xPosGrid = (int)transform.position.x / delta;
        int zPosGrid = (int)transform.position.z / delta;

        OnChangeTile(xPosGrid, zPosGrid);
    }

    void Update()
    {
        if (isActivated)
        {
            ManageGame.instance.SetSelectedHero(gameObject);
        }
    }

    public void OnChangeTile(int x, int z)
    {
        int[] positions = ManageActions.instance.pathConstructor.FindObjInGrid(x, z);

        xPos = positions[0];
        zPos = positions[1];
    }
}

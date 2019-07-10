using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    //hero placement on grid
    public int xPos;
    public int zPos;

    public bool isActivated = false;

    private void Start()
    {
        int delta = ManageActions.instance.pathConstructor.delta;
        int xPosGrid = (int)transform.position.x / delta;
        int zPosGrid = (int)transform.position.z / delta;

        int[] positions = ManageActions.instance.pathConstructor.FindObjInGrid(xPosGrid, zPosGrid);

        xPos = positions[0];
        zPos = positions[1];
    }

    private void Update()
    {
        
    }
}

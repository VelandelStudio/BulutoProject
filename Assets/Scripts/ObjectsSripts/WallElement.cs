

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallElement : BlockableElement
{
    void Start()
    {
        int delta = ManageActions.instance.pathConstructor.delta;
        int xPosGrid = (int)transform.position.x / delta;
        int zPosGrid = (int)transform.position.z / delta;

        OnChangeTile(xPosGrid, zPosGrid);
    }

    public override void OnEntrave(GameObject obj, int x, int z)
    {
        /* Do something */
    }
}

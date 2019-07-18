using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockableElement : MonoBehaviour, IBlockable
{
    public int PosX { get; set; }
    public int PosZ { get; set; }

    public GameObject Tile { get; set; }

    public void OnChangeTile(int x, int z)
    {

        Tile = ManageActions.instance.pathConstructor.FindTile(x, z);

        if (Tile)
        {
            PosX = Tile.GetComponent<TileStats>().x;
            PosZ = Tile.GetComponent<TileStats>().z;

            Tile.GetComponent<TileStats>().isOccuped = true;
        }
    }

    public abstract void OnEntrave(GameObject obj, int x, int z);
}

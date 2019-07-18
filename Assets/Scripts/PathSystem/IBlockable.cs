using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockable
{
    int PosX { get; set; }
    int PosZ { get; set; }

    GameObject Tile { get; set; }

    void OnChangeTile(int x, int z);
    void OnEntrave(GameObject obj, int x, int z);
}

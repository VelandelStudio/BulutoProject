﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    private int lines = 21;
    private int cols = 15;
    public int delta = 10;

    private GameObject[,] gridArray;
    private Transform boardHolder;

    public GameObject playTile;
    public GameObject borderTiles;

    void BoardSetup()
    {
        gridArray = new GameObject[cols, lines];

        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < cols + 1; x++)
        {
            for (int z = -1; z < lines + 1; z++)
            {
                GameObject toInstantiate = playTile;

                if (x == -1 || x == cols || z == -1 || z == lines)
                    toInstantiate = borderTiles;

                GameObject obj =
                    Instantiate(toInstantiate, new Vector3(x * delta, 0f, z * delta), Quaternion.identity) as GameObject;

                obj.transform.SetParent(boardHolder);

                if (obj.GetComponent<TileStats>())
                {
                    obj.GetComponent<TileStats>().x = x;
                    obj.GetComponent<TileStats>().z = z;

                    gridArray[x, z] = obj;
                }
            }
        }

        ManageActions.instance.pathConstructor.gridArray = gridArray;
        ManageActions.instance.pathConstructor.rows = lines;
        ManageActions.instance.pathConstructor.cols = cols;
        ManageActions.instance.pathConstructor.delta = delta;
    }

    public void InitializeMap()
    {
        BoardSetup();
    }
}
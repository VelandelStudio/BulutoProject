using System.Collections;
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
    public GameObject[] wallTiles;

    public int nbWalls = 15;
    public List<GameObject> wallsToInstantiate = new List<GameObject>();

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

    void WallSetup()
    {
        for (int i = 0; i < nbWalls; i++)
        {
            int x = (Random.Range(0, cols - 1));
            int z = (Random.Range(5, 15));

            int randomWallTile = Random.Range(0, wallTiles.Length);

            GameObject wallToInstantiate = wallTiles[randomWallTile];

            wallToInstantiate.GetComponent<WallElement>().PosX = x;
            wallToInstantiate.GetComponent<WallElement>().PosZ = z;
            
            if (!CheckWallAlreadyInList(wallsToInstantiate, x, z))
            {
                float xPos = wallToInstantiate.GetComponent<WallElement>().PosX * delta;
                float zPos = wallToInstantiate.GetComponent<WallElement>().PosZ * delta;
                float yPos = wallToInstantiate.transform.position.y;

                Vector3 location = new Vector3(xPos, yPos, zPos);

                GameObject wall = Instantiate(wallToInstantiate, location, Quaternion.identity) as GameObject;
                wall.transform.SetParent(boardHolder);

                wall.GetComponent<WallElement>().PosX = x;
                wall.GetComponent<WallElement>().PosZ = z;

                wallsToInstantiate.Add(wall);
            }
            else
            {
                i--;
            }
        }
    }

    bool CheckWallAlreadyInList(List<GameObject> walls, int x, int z)
    {

        if (walls.Count == 0)
        {
            return false;
        }

        foreach (GameObject obj in walls)
        {
            if (obj.GetComponent<WallElement>().PosX == x && obj.GetComponent<WallElement>().PosZ == z)
            {
                Debug.Log(true);
                return true;
            }
        }
        
        return false;
    }

    public void InitializeMap()
    {
        BoardSetup();
        WallSetup();
    }
}

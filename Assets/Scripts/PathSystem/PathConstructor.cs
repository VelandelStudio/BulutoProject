using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathConstructor : MonoBehaviour
{
    public GameObject[,] gridArray; //this array has obj that carry TileStats
    public List<GameObject> path = new List<GameObject>();

    public int rows;
    public int cols;
    public int delta;

    void InitialSetUp(int startXIndex, int startZIndex)
    {
        foreach (GameObject obj in gridArray)
        {
            if (obj.GetComponent<TileStats>())
            {
                obj.GetComponent<TileStats>().visited = -1;
            }
        }

        gridArray[startXIndex, startZIndex].GetComponent<TileStats>().visited = 0;
    }

    public void SetDistance(int startXIndex, int startZIndex)
    {
        InitialSetUp(startXIndex, startZIndex);
        int x = startXIndex;
        int z = startZIndex;

        for (int step = 1; step < rows * cols; step++)
        {
            foreach(GameObject obj in gridArray)
            {
                if (obj.GetComponent<TileStats>().visited == step - 1)
                    TestFourDirections(obj.GetComponent<TileStats>().x, obj.GetComponent<TileStats>().z, step);
            }
        }
    }

    public void SetPath(int endXIndex, int endZIndex)
    {
        int step;
        int x = endXIndex;
        int z = endZIndex;

        List<GameObject> tempList = new List<GameObject>();
        path.Clear();

        if (gridArray[endXIndex, endZIndex] && gridArray[endXIndex, endZIndex].GetComponent<TileStats>().visited > 0)
        {
            path.Add(gridArray[x, z]);
            step = gridArray[x, z].GetComponent<TileStats>().visited - 1;
        }
        else
        {
            Debug.Log("Can't reach the destination");
            return;
        }

        for(int i = step; i > 0; i--)
        {

            if (TestDirection(x, z, i, 1))
                tempList.Add(gridArray[x, z + 1]);

            if (TestDirection(x, z, i, 2))
                tempList.Add(gridArray[x + 1, z]);

            if (TestDirection(x, z, i, 3))
                tempList.Add(gridArray[x, z - 1]);

            if (TestDirection(x, z, i, 4))
                tempList.Add(gridArray[x - 1, z]);

            GameObject tempObj = FindClosest(gridArray[endXIndex, endZIndex].transform, tempList);
            path.Add(tempObj);

            x = tempObj.GetComponent<TileStats>().x;
            z = tempObj.GetComponent<TileStats>().z;

            tempList.Clear();
        }
    }

    bool TestDirection(int x, int z, int step, int direction)
    {
        // Direction 1 is up, 2 is right, 3 is down, 4 is left
        switch (direction)
        {
            case 4:
                if (x - 1 > -1 && gridArray[x - 1, z] && gridArray[x - 1, z].GetComponent<TileStats>().visited == step)
                    return true;
                else
                    return false;

            case 3:
                if (z - 1 > -1 && gridArray[x, z - 1] && gridArray[x, z - 1].GetComponent<TileStats>().visited == step)
                    return true;
                else
                    return false;

            case 2:
                if (x + 1 < cols && gridArray[x + 1, z] && gridArray[x + 1, z].GetComponent<TileStats>().visited == step)
                    return true;
                else
                    return false;

            case 1:
                if (z + 1 < rows && gridArray[x, z + 1] && gridArray[x, z + 1].GetComponent<TileStats>().visited == step)
                    return true;
                else
                    return false;
        }

        return false;
    }

    void TestFourDirections(int x, int z, int step)
    {
        if (TestDirection(x, z, -1, 1))
            SetVisited(x, z + 1, step);

        if (TestDirection(x, z, -1, 2))
            SetVisited(x + 1, z, step);

        if (TestDirection(x, z, -1, 3))
            SetVisited(x, z - 1, step);

        if (TestDirection(x, z, -1, 4))
            SetVisited(x - 1, z, step);
    }

    public void SetVisited (int x, int z, int step)
    {
        if (gridArray[x, z])
        {
            gridArray[x, z].GetComponent<TileStats>().visited = step;
        }
    }

    GameObject FindClosest(Transform targetLocation, List<GameObject> list)
    {
        float currentDistance = delta * rows * cols;
        int indexNumber = 0;

        for (int i = 0; i < list.Count; i++)
        {

            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = i;
            }
        }

        return list[indexNumber];
    }

    // To know where is an obj in the grid
    public int[] FindObjInGrid(int x, int z)
    {
        int[] positions = new int[2];

        foreach(GameObject obj in gridArray)
        {
            if (x == obj.GetComponent<TileStats>().x && z == obj.GetComponent<TileStats>().z)
            {
                positions[0] = obj.GetComponent<TileStats>().x;
                positions[1] = obj.GetComponent<TileStats>().z;
            }
        }

        return positions;
    } 
}

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

    public int startXIndex = 3;
    public int startZIndex = 5;
    public int endXIndex = 0;
    public int endZIndex = 0;

    void InitialSetUp()
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

    void SetDistance()
    {
        InitialSetUp();
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

    void SetPath()
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

        for(int i = step; step > -1; i--)
        {
            if (TestDirection(x, z, step, 1))
                tempList.Add(gridArray[x, z + 1]);

            if (TestDirection(x, z, step, 2))
                tempList.Add(gridArray[x + 1, z]);

            if (TestDirection(x, z, step, 3))
                tempList.Add(gridArray[x, z - 1]);

            if (TestDirection(x, z, step, 4))
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

    void SetVisited (int x, int z, int step)
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

        for(int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = i;
            }
        }

        return list[indexNumber];
    }
}

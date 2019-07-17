using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    //hero placement on grid
    public int xPos;
    public int zPos;

    public float speed = 0.5f;
    public int currentTile = 0;
    public bool isActivated = true;
    public List<GameObject> path = new List<GameObject>();

    private Rigidbody rigidB;

    void Start()
    {
        int delta = ManageActions.instance.pathConstructor.delta;
        int xPosGrid = (int)transform.position.x / delta;
        int zPosGrid = (int)transform.position.z / delta;

        OnChangeTile(xPosGrid, zPosGrid);

        rigidB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isActivated)
        {
            ManageGame.instance.SetSelectedHero(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (currentTile == path.Count)
        {
            path.Clear();
            currentTile = 0;
        }

        if (path.Count > 0 && currentTile < path.Count)
        {
            Move();
        }
    }

    public void Move()
    {
        if(currentTile < path.Count && Vector3.Distance(transform.position, path[currentTile].transform.position) < 1.20f )
        {
            currentTile++;
        }

        if (currentTile < path.Count)
        {
            Vector3 dir = new Vector3(path[currentTile].transform.position.x, transform.position.y, path[currentTile].transform.position.z);

            transform.LookAt(dir);
            StartCoroutine(DeltaMove(rigidB, dir));

            OnChangeTile(path[currentTile].GetComponent<TileStats>().x, path[currentTile].GetComponent<TileStats>().z);
        }
    }

    public void OnChangeTile(int x, int z)
    {
        int[] positions = ManageActions.instance.pathConstructor.FindObjInGrid(x, z);

        xPos = positions[0];
        zPos = positions[1];
    }

    IEnumerator<WaitForSeconds> DeltaMove(Rigidbody rig, Vector3 dir)
    {
        yield return new WaitForSeconds(0.2f);
        rig.position = dir;
    }
}

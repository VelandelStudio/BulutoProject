using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    public static ManageGame instance = null;

    public List<GameObject> redTeam = new List<GameObject>();

    private MapLoader boardScript;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<MapLoader>();

        InitGame();
    }

    void InitGame()
    {
        int delta = boardScript.delta;

        boardScript.InitializeMap();

        Instantiate(redTeam[0], new Vector3(5*delta, 1, 3*delta), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    public static ManageGame instance = null;

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
        boardScript.InitializeMap();
    }
}

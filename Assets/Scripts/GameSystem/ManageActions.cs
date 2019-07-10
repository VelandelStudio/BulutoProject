using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageActions : MonoBehaviour
{
    public static ManageActions instance = null;

    public PathConstructor pathConstructor;

    private MapLoader boardScript;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}

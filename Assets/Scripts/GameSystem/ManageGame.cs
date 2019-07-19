using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    public static ManageGame instance = null;
    public GameObject SelectedHero;

    private MapLoader boardScript;
    public HeroManager heroManager;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<MapLoader>();
        heroManager = GetComponent<HeroManager>();

        InitGame();
    }

    void InitGame()
    {
        int delta = boardScript.delta;

        boardScript.InitializeMap();
        heroManager.InitializeHeroPos(delta);
    }

    public void SetSelectedHero(GameObject hero)
    {
        if (hero.GetComponent<HeroMovement>())
        {
            SelectedHero = hero;
        }
    }
}

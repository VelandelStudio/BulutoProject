using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public List<GameObject> redTeam = new List<GameObject>();
    public List<GameObject> blueTeam = new List<GameObject>();

    public GameObject[,] gridArray;

    private List<GameObject> orderList = new List<GameObject>();

    public void InitializeHeroPos(int delta)
    {
        if (redTeam.Count > 0 && blueTeam.Count > 0)
        {
            Debug.Log("lol");
            StoreTeamOrder();
        }

        Debug.Log(orderList.Count);

        if (orderList.Count == 6)
        {
            GameObject heroR1 = Instantiate(redTeam[0],
                new Vector3(gridArray[7, 2].GetComponent<TileStats>().x * delta,
                            redTeam[0].transform.position.y,
                            gridArray[7, 2].GetComponent<TileStats>().z * delta), Quaternion.identity) as GameObject;

            GameObject heroR2 = Instantiate(redTeam[1],
                new Vector3(gridArray[2, 2].GetComponent<TileStats>().x * delta,
                            redTeam[1].transform.position.y,
                            gridArray[2, 2].GetComponent<TileStats>().z * delta), Quaternion.identity) as GameObject;

            GameObject heroR3 = Instantiate(redTeam[2],
                new Vector3(gridArray[12, 2].GetComponent<TileStats>().x * delta,
                            redTeam[2].transform.position.y,
                            gridArray[12, 2].GetComponent<TileStats>().z * delta), Quaternion.identity) as GameObject;

            GameObject heroB1 = Instantiate(blueTeam[0],
                new Vector3(gridArray[7, 18].GetComponent<TileStats>().x * delta,
                            blueTeam[0].transform.position.y,
                            gridArray[7, 18].GetComponent<TileStats>().z * delta), Quaternion.identity) as GameObject;

            GameObject heroB2 = Instantiate(blueTeam[1],
                new Vector3(gridArray[12, 18].GetComponent<TileStats>().x * delta,
                            blueTeam[1].transform.position.y,
                            gridArray[12, 18].GetComponent<TileStats>().z * delta), Quaternion.identity) as GameObject;

            GameObject heroB3 = Instantiate(blueTeam[2],
                new Vector3(gridArray[2, 18].GetComponent<TileStats>().x * delta,
                            blueTeam[2].transform.position.y,
                            gridArray[2, 18].GetComponent<TileStats>().z * delta), Quaternion.identity) as GameObject;

            orderList[0].GetComponent<HeroMovement>().isActivated = true;
        }
    }

    private void StoreTeamOrder()
    {
        foreach (GameObject hero in redTeam)
        {
            if (hero.GetComponent<HeroBehavior>())
            {
                orderList.Add(hero);
            }
        }

        foreach (GameObject hero in blueTeam)
        {
            if (hero.GetComponent<HeroBehavior>())
            {
                orderList.Add(hero);
            }
        }

        SortByInitiative();
    }

    public void SortByInitiative()
    {
        orderList = orderList.OrderBy(x => x.GetComponent<HeroBehavior>().Initiative).ToList();
    }
}

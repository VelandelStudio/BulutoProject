using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroBehavior : MonoBehaviour
{
    private int initiative;
    public int Initiative
    {
        get
        {
            return initiative;
        }
        set
        {
            initiative = value;
        }
    }

    public abstract void Attack();
}

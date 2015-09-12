using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
    [SerializeField]
    bool canLong;

    [SerializeField]
    bool horizontal;

    public bool GetCanLong
    {
        get
        {
            return canLong;
        }
    }

    public bool GetHorizontal
    {
        get
        {
            return horizontal;
        }
    }
}
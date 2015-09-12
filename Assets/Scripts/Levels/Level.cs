using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    Dictionary<string, string> obstacles = new Dictionary<string,string>();

    public Dictionary<string, string> GetObstacles
    {
        get
        {
            return obstacles;
        }
    }

    protected void AddObstacle(string obstacle, int time, int spawn)
    {
        this.obstacles.Add(obstacle, time+","+spawn);
    }
}

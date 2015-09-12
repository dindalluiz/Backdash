using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameManager gm;

    [SerializeField]
    GameObject longPrefab;

    int level;

    Level levelActual;

    GameObject[] spawners;

    GameObject obstacles;

    void Start()
    {

    }

	public void StartSpawn ()
    {
        this.level = PlayerPrefs.GetInt("level");
        StartCoroutine(spawn());
        this.obstacles = new GameObject("Obstacles");
        this.spawners = GameObject.FindGameObjectsWithTag(Tags.Spawner);
        this.levelActual = new Level1();
	}

    IEnumerator spawn()
    {
        float timer=0;
        while (8==8)
        {
            yield return new WaitForSeconds(3+Time.deltaTime-timer);
            if (this.level == 0)
            {
                if(timer<2.3f)
                timer += 0.1f;
                if (gm.GetScene == Scenes.All.Game && !Player.lose && !this.gm.goMenu)
                {
                    int randomSpawn = Mathf.RoundToInt(Random.Range(0, spawners.Length));
                    int randomPos = Random.Range(-1, 2);

                    if (spawners[randomSpawn].GetComponent<Spawner>().GetCanLong)
                    {
                        GameObject go = (GameObject)GameObject.Instantiate(longPrefab, new Vector3(spawners[randomSpawn].transform.position.x, spawners[randomSpawn].transform.position.y, 0), longPrefab.transform.localRotation);
                        go.transform.parent = this.obstacles.transform;

                        if (spawners[randomSpawn].GetComponent<Spawner>().GetHorizontal)
                        {
                            go.transform.localEulerAngles = new Vector3(0, 0, 90);
                        }
                    }
                }
            }
            else
            {
                timer ++;
                foreach (KeyValuePair<string, string> a in this.levelActual.GetObstacles)
                {
                    string[] aux = a.Value.Split(",".ToCharArray());
                    if(aux[0] == timer.ToString())
                    {
                        print("sim");
                    }
                }
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public bool goGame, goMenu, goChooseMode, goHighscore = false;

    int zActual;

    int[] zCamera = new int[] {-100, 1, -15, -10};

    Scenes.All currentScene;

    [SerializeField]
    GameObject objectMenu, objectChoose, objectGame, objectHigh;

    [SerializeField]
    SpawnManager sm;

    [SerializeField]
    Player player;

    [SerializeField]
    Text nameField;

	void Start () 
    {
        this.currentScene = Scenes.All.Menu;
	}

    void FixedUpdate()
    {
        switch(currentScene)
        {
            case Scenes.All.Menu:
                if (goGame)
                {
                    if (Mathf.RoundToInt(Camera.main.transform.position.z) != this.zCamera[this.zActual])
                    {
                        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.zCamera[this.zActual]), 0.05f);
                    }
                    else if (this.zActual < this.zCamera.Length-1)
                    {
                        this.zActual++;
                        return;
                    }
                    else
                    {
                        this.currentScene = Scenes.All.Game;
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.zCamera[this.zActual]);
                        this.goGame = false;
                        this.sm.StartSpawn();
                        StartCoroutine(Counter());
                    }
                }

                if (goChooseMode)
                {
                    if (Mathf.RoundToInt(Camera.main.transform.localEulerAngles.y) != 180)
                    {
                        Camera.main.transform.localEulerAngles = Vector3.Lerp(Camera.main.transform.localEulerAngles, new Vector3(0, 180, 0), 0.02f + (Camera.main.transform.localEulerAngles.y / 5000));
                    }
                    else if (Mathf.RoundToInt(Camera.main.transform.position.z) != -150)
                    {
                        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -150), 0.05f);
                    }
                    else
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -150);
                        Camera.main.transform.localEulerAngles = new Vector3(Camera.main.transform.localEulerAngles.x, 180, Camera.main.transform.localEulerAngles.z);
                        this.currentScene = Scenes.All.LevelChoose;
                        this.goChooseMode = false;
                    }
                }

                if (goHighscore)
                {
                    if (Mathf.RoundToInt(Camera.main.transform.localEulerAngles.x) != 270)
                    {
                        Camera.main.transform.localEulerAngles = Vector3.Lerp(Camera.main.transform.localEulerAngles, new Vector3(-90, 0, 0), 0.01f);
                    }
                    else
                    {
                        Camera.main.transform.localEulerAngles = new Vector3(270, Camera.main.transform.localEulerAngles.y, Camera.main.transform.localEulerAngles.z);
                        this.currentScene = Scenes.All.Highscore;
                        this.goHighscore = false;
                    }
                }

                break;
            case Scenes.All.Game:
                if (goMenu)
                {
                    if (Mathf.RoundToInt(Camera.main.transform.position.z) != this.zCamera[this.zActual])
                    {
                        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.zCamera[this.zActual]), 0.05f);
                    }
                    else if (this.zActual > 0)
                    {
                        this.zActual--;
                        return;
                    }
                    else
                    {
                        this.currentScene = Scenes.All.Menu;
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.zCamera[this.zActual]);
                        this.goMenu = false;
                        this.player.Reset();
                    }
                }
                break;

            case Scenes.All.LevelChoose:
                if (goGame)
                {
                    if (Mathf.RoundToInt(Camera.main.transform.localEulerAngles.y) != 0)
                    {
                        Camera.main.transform.localEulerAngles = Vector3.Lerp(Camera.main.transform.localEulerAngles, new Vector3(0, 0, 0), 0.02f + (Camera.main.transform.localEulerAngles.y / 5000));
                    }
                    else if (Mathf.RoundToInt(Camera.main.transform.position.z) != this.zCamera[this.zActual])
                    {
                        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.zCamera[this.zActual]), 0.05f);
                    }
                    else if (this.zActual < this.zCamera.Length - 1)
                    {
                        this.zActual++;
                        return;
                    }
                    else
                    {
                        this.currentScene = Scenes.All.Game;
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.zCamera[this.zActual]);
                        this.goGame = false;
                        this.sm.StartSpawn();
                    }
                }

                if (goMenu)
                {
                    if (Mathf.RoundToInt(Camera.main.transform.localEulerAngles.y) != 1)
                    {
                        Camera.main.transform.localEulerAngles = Vector3.Lerp(Camera.main.transform.localEulerAngles, new Vector3(0, 0, 0), 0.02f + (Camera.main.transform.localEulerAngles.y / 5000));
                    }
                    else if (Mathf.RoundToInt(Camera.main.transform.position.z) != -100)
                    {
                        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 0, -100), 0.1f);
                    }
                    else
                    {
                        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -100);
                        Camera.main.transform.localEulerAngles = new Vector3(Camera.main.transform.localEulerAngles.x, 0, Camera.main.transform.localEulerAngles.z);
                        this.currentScene = Scenes.All.Menu;
                        this.goMenu = false;
                    }
                }
                break;

            case Scenes.All.Highscore:
                if (goMenu)
                {
                    Camera.main.transform.localEulerAngles = new Vector3(360, Camera.main.transform.localEulerAngles.y, Camera.main.transform.localEulerAngles.z);
                    this.currentScene = Scenes.All.Menu;
                    this.goMenu = false;
                }

                break;
        }
    }

    void Update()
    {
        if (this.currentScene == Scenes.All.Menu && !this.goGame && !this.goChooseMode && !this.goHighscore)
        {
            this.objectMenu.SetActive(true);
        }
        else if (this.currentScene == Scenes.All.LevelChoose && !this.goGame && !this.goMenu)
        {
            this.objectChoose.SetActive(true);
        }
        else if (this.currentScene == Scenes.All.Game && !this.goMenu)
        {
            this.objectGame.SetActive(true);
        }
        else if (this.currentScene == Scenes.All.Highscore && !this.goMenu)
        {
            this.objectHigh.SetActive(true);
        }
        else
        {
            this.objectChoose.SetActive(false);
            this.objectMenu.SetActive(false);
            this.objectGame.SetActive(false);
            this.objectHigh.SetActive(false);
        }


    }

    public Scenes.All GetScene
    {
        get
        {
            return currentScene;
        }
    }

    public void GoGame(int level)
    {
        if (nameField.text != "")
            this.player.name = nameField.text;
        else
            this.player.name = "a player";

        PlayerPrefs.SetInt("level", level);
        this.zActual = 0;
        this.goGame = true;
    }

    public void GoMenu()
    {
        this.zActual = zCamera.Length - 1;
        this.goMenu = true;
    }

    public void GoChooseMode()
    {
        this.goChooseMode = true;
        print(1);
    }

    public void GoHighscore()
    {
        this.goHighscore = true;
    }

    IEnumerator Counter()
    {
        while (8 == 8)
        {
            yield return new WaitForSeconds(0.2f);
            if (this.currentScene == Scenes.All.Game && !Player.lose)
            {
                this.player.AddPoints(1);
            }
        }
    }
}
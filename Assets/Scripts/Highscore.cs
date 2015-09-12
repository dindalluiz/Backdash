using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Highscore : MonoBehaviour 
{
    [SerializeField]
    Text[] highTexts;

    [SerializeField]
    Text[] highTextsStr;

	void Start () 
    {
        if (PlayerPrefs.GetInt("top1") == 0 && PlayerPrefs.GetString("top1str") == "")
        {
            PlayerPrefs.SetInt("top1", 100);
            PlayerPrefs.SetString("top1str", "robot ganko");
            PlayerPrefs.SetInt("top2", 80);
            PlayerPrefs.SetString("top2str", "robot davson");
            PlayerPrefs.SetInt("top3", 60);
            PlayerPrefs.SetString("top3str", "robot jamv");
            PlayerPrefs.SetInt("top4", 40);
            PlayerPrefs.SetString("top4str", "robot litte d*ck");
            PlayerPrefs.SetInt("top5", 100);
            PlayerPrefs.SetString("top5str", "robot jao");
        }
	}
	
	void Update () 
    {
        for (int i = 0; i < 5; i++)
        {
            this.highTexts[i].text = PlayerPrefs.GetInt("top" + (i + 1)).ToString();
            this.highTextsStr[i].text = PlayerPrefs.GetString("top" + (i + 1) + "str");
        }
	}

    public void AddScore(int points, string name)
    {
        if (points > PlayerPrefs.GetInt("top5"))
        {
            PlayerPrefs.SetInt("top5", points);
            PlayerPrefs.SetString("top5str", name);
        }
        BubbleSort();
    }

    void BubbleSort()
    {
        int temp = 0;
        string tempStr = "";

        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5 - 1; j++)
            {
                if (PlayerPrefs.GetInt("top"+j) < PlayerPrefs.GetInt("top"+(j+1)))
                {
                    tempStr = PlayerPrefs.GetString("top" + (j + 1)+"str");
                    temp = PlayerPrefs.GetInt("top" + (j + 1));
                    PlayerPrefs.SetInt("top" + (j + 1), PlayerPrefs.GetInt("top" + j));
                    PlayerPrefs.SetString("top" + (j + 1) + "str", PlayerPrefs.GetString("top" + j + "str"));
                    PlayerPrefs.SetInt("top" + j, temp);
                    PlayerPrefs.SetString("top" + j + "str", tempStr);
                }
            }
            print(PlayerPrefs.GetInt("top" + i));
        }
    }
}

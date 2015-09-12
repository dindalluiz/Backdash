using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected GameManager gm;

    [SerializeField]
    protected Highscore hs;

    [SerializeField]
    protected GameObject goCooldown;

    [SerializeField]
    protected Text pointsText;

    [SerializeField]
    protected Slider sensibilityInf;

    [SerializeField]
    protected Slider sensibilityHist;

    protected float speed = 1.2f;

    public string name;

    protected int points;

    public static bool lose;

    protected Vector3 startPos;

    protected float cooldown=10;

    void Awake()
    {
        this.startPos = this.transform.position;
        if (PlayerPrefs.GetInt("level") > 0)
            this.speed = sensibilityHist.value;
        else
            this.speed = sensibilityInf.value;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == Tags.Obstacle && !Player.lose && !this.gm.goMenu)
        {
            StartCoroutine(GoLose());
            lose = true;
        }
    }

    IEnumerator GoLose()
    {
        yield return new WaitForSeconds(2);
        hs.AddScore(points, this.name);
        gm.GoMenu();
        lose = false;
    }

    public void Reset()
    {
        this.transform.position = this.startPos;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.points = -1;
    }

    public void AddPoints(int p)
    {
        this.points += p;
    }

    public int GetPoints
    {
        get
        {
            return points;
        }
    }
}
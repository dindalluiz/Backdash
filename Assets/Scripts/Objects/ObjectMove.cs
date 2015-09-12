using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour 
{
    Vector3 startPos;

    [SerializeField]
    float speedX = 20;

    [SerializeField]
    float speedY = 20;

    GameManager gm;

    void Awake()
    {
        this.gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.startPos = this.transform.position;
    }

	void Start () 
    {
        if (this.startPos.x > 0)
        {
            this.speedX *= -1;
        }

        if (this.startPos.y > 0)
        {
            this.speedY *= -1;
        }

	}
	
	void Update ()
    {
        if (Mathf.RoundToInt(this.transform.localEulerAngles.z) == 90)
            this.speedX = 0;
        else
            this.speedY = 0;

        if (this.gm.GetScene != Scenes.All.Game || this.gm.goMenu /*|| Mathf.Abs(this.transform.position.y) > 13 || Mathf.Abs(this.transform.position.x) > 13*/) Destroy(this.gameObject);

        if (this.gm.GetScene == Scenes.All.Game && !Player.lose && !this.gm.goMenu)
            this.transform.position = new Vector3(this.transform.position.x + speedX / 100, this.transform.position.y + speedY / 100, 0);
	}
}

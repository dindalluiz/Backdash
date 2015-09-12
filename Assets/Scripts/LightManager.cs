using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour 
{
    [SerializeField]
    Light up, down, front;

    List<Color> firstColors = new List<Color>();

	void Start ()
    {
        this.firstColors.Add(new Color(0.412f, 0.824f, 0.906f));
        this.firstColors.Add(new Color(0.878f, 0.894f, 0.80f));
        this.firstColors.Add(new Color(0.655f, 0.859f, 0.847f));
        this.firstColors.Add(new Color(0.98f, 0.412f, 0));

        this.up.color = this.firstColors[0];
        this.down.color = this.firstColors[1];
        this.front.color = this.firstColors[3];
        Camera.main.backgroundColor = this.firstColors[2];
	}
	
	void Update () 
    {
	
	}
}

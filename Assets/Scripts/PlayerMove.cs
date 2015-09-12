using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMove : Player
{
    bool isJumping;

    int jump;

	void Update () 
    {
        this.pointsText.text = this.points.ToString();

        if (this.gm.GetScene == Scenes.All.Game && !Player.lose)
        {
            this.GetComponent<Rigidbody>().AddForce(Input.acceleration.x * speed, Input.acceleration.y * speed, 0, ForceMode.Impulse);

            if (Input.GetMouseButtonDown(0) && !isJumping && this.cooldown == 100)
            {
                isJumping = true;
                this.cooldown = 0;
            }

            if (jump < 30 && isJumping)
            {
                jump++;
                this.transform.Translate(0, 0, 1);
            }
            else if (this.transform.position.z != startPos.z)
            {
                this.transform.Translate(0, 0, -1);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.startPos.z);
                isJumping = false;
                jump = 0;
            }

            if (cooldown < 100)
            {
                cooldown += 0.5f;
            }

            this.goCooldown.transform.localScale = new Vector3((0.12f * cooldown) / 100, this.goCooldown.transform.localScale.y, this.goCooldown.transform.localScale.z);
        }
	}
}
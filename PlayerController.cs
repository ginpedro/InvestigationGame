using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxspeedX = 8f;
	public float maxspeedY = 4f;
	public Animator ani;

	float dirX;
	float dirY;
	
	// Use this for initialization
	void Start () {
		
		ani = this.GetComponent<Animator> ();
		dirX = ani.GetFloat("dirX");
		dirY = ani.GetFloat("dirY");
		ani.SetBool("running", false);
	}
	
	// Update is called once per frame
	void Update () {
		
		//movimentacao nas oito direcoes
		float velx = 0f;
		float vely = 0f;
		bool hor = false;
		bool ver = false;
		if (Input.GetKey(KeyCode.RightArrow)) {
			velx = 1f;
			dirX = 1f;
			hor = true;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			velx = -1f;
			dirX = -1f;
			hor = true;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			vely = 1f;
			dirY = 1f;
			ver = true;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			vely = -1f;
			dirY = -1f;
			ver = true;
		}

		ani.SetBool("running", (hor || ver));
		ani.SetFloat("speedX", velx);
		ani.SetFloat("speedY", vely);
		if (hor && !ver) {
			ani.SetFloat("dirX", dirX);
			ani.SetFloat("dirY", 0f);
		}
		else if (!hor && ver) {
			ani.SetFloat("dirX", 0f);
			ani.SetFloat("dirY", dirY);
		}
		else if (hor && ver) {
			ani.SetFloat("dirX", dirX);
			ani.SetFloat("dirY", dirY);
		}
		rigidbody2D.velocity = new Vector2 ( velx*maxspeedX, vely*maxspeedY );
	}
}

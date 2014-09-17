using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxspeedX = 8f;
	public float maxspeedY = 4f;
	public Animator ani;
	public float jump_height = 50f;
	
	Vector3 sc;
	bool face_to_right = true;
	
	// Use this for initialization
	void Start () {
		
		ani = this.GetComponent<Animator> ();
		//ani.SetBool("jumping", false);
	}
	
	// Update is called once per frame
	void Update () {
		
		//movimentacao esquerda-direita
		float velx = 0f;
		float vely = 0f;
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			velx = maxspeedX;
			if (!face_to_right) {
				sc = transform.localScale;
				sc.x *= -1.0f;
				face_to_right = true;
				transform.localScale = sc;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			velx = -maxspeedX;
			if (face_to_right) {
				sc = transform.localScale;
				sc.x *= -1.0f;
				face_to_right = false;
				transform.localScale = sc;
			}
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			vely = maxspeedY;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			vely = -maxspeedY;
		}

		float spd = Mathf.Abs(velx) + Mathf.Abs(vely);
		ani.SetFloat("speed", Mathf.Abs(spd));
		rigidbody2D.velocity = new Vector2 ( velx, vely );
	}
	
}

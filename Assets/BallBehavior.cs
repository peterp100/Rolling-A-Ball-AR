using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BallBehavior : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	//public GameObject myTarget;

	public GameObject plane;
	public GameObject cube;

	private Rigidbody rb;
	private int count;


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		//winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < plane.transform.position.y - 0.001) {
			transform.position = cube.transform.position;
			rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}

	void FixedUpdate ()
	{
		
		float moveHorizontal;
		float moveVertical;
		
		if (Application.platform == RuntimePlatform.OSXEditor) {

			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		} else {	
			//Vector3 dir = Vector3.zero;
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y + 0.75f;
		}

			Vector3 Movement = new Vector3 (moveHorizontal, 0.0f,  moveVertical);

			//Debug.Log ("Movement: " + moveHorizontal.ToString () + ", 0.0, " + moveVertical.ToString ());

			rb.AddForce (Movement * speed);

			//Debug.Log ("Velocity: " + rb.velocity.ToString ());
	}

	void OnTriggerEnter(Collider other) 
	{
	Debug.Log ("OnTriggerEnter");
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			Debug.Log (count.ToString ());
			//SetCountText ();
		}

	}

	void SetCountText ()
	{
		//countText.text = "Count: " + count.ToString (); 
		//if (count >= 12) {
		//	winText.text = "You Win !";
		//}
	}

	}


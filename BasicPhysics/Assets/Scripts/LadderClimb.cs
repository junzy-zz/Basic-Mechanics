using UnityEngine;
using System.Collections;

public class LadderClimb : MonoBehaviour
{
		Animator anim;
		public bool isClimbing = false;
		public GameObject hero;
		public float Ladderjumpforce=5.0f;
		public float ClimbSpeed;
		private PlatformerCharacter2D platf;
		// Use this for initialization
		void Start ()
		{
			hero = GameObject.Find ("Player");
		}

		void Awake ()
		{
			platf = hero.GetComponent<PlatformerCharacter2D> ();
			anim = hero.GetComponent<Animator> ();
		}
		
		
		// Update is called once per frame
		void Update ()
		{
			if (isClimbing) 
			{
				anim.SetInteger ("IsClimb", 1);
				if (platf.grounded)
						platf.CanJump = 0;
				float v = Input.GetAxis ("Vertical");
				//anim.SetFloat("vSpeed",Mathf.Abs(v));
				if (Input.GetAxis ("Vertical") > 0) 
				{

					//Debug.Log(Input.GetAxis("Vertical"));		
					//platf.transform.Translate (0, ClimbSpeed*v * Time.deltaTime, 0);
					platf.rigidbody2D.velocity = new Vector2 (0.0f, v * ClimbSpeed);
					anim.SetFloat ("vSpeed", Mathf.Abs (platf.rigidbody2D.velocity.y));
					//SendMessage ("going up", SendMessageOptions.DontRequireReceiver);
				} 
				else if (Input.GetAxis ("Vertical") < 0) 
				{

					if (!platf.grounded)
						platf.rigidbody2D.velocity = new Vector2 (0.0f, v * ClimbSpeed);
					anim.SetFloat ("vSpeed", Mathf.Abs (platf.rigidbody2D.velocity.y));
					//SendMessage ("going down", SendMessageOptions.DontRequireReceiver);			
				}
				

				if(Input.GetAxis("Horizontal")!=0) 
				{	
					if(Input.GetButtonDown("Jump"))
					{
						
						hero.rigidbody2D.gravityScale = 3;
						hero.rigidbody2D.AddForce(new Vector2(0f, platf.jumpForce));
						//hero.rigidbody2D.AddForce(new Vector2(0f, Ladderjumpforce*1.0f));
					Debug.Log (Ladderjumpforce);
						
					}
				}
			} 
			else if (platf.grounded && anim.GetInteger ("IsClimb") == 0) 
			{
				platf.CanJump = 1;
				//Debug.Log(anim.GetInteger("IsClimb"));
			}
			//else
			//	anim.SetInteger("IsClimb",0);
			//side jump code
			
			

		}

		public void OnTriggerEnter2D (Collider2D other)
		{

			//Debug.Log (other.tag);
			//SendMessage ("encountered ladder", SendMessageOptions.DontRequireReceiver);
			if(other.gameObject.tag=="Player" && Input.GetKey("e"))
			{	
				isClimbing = true;
				hero.rigidbody2D.gravityScale = 0;
				anim = hero.GetComponent<Animator> ();
				hero.rigidbody2D.velocity = new Vector2 (0, 0);
			}
		}

		public void OnTriggerExit2D (Collider2D other)
		{
				
				//SendMessage("Exit ladder",SendMessageOptions.DontRequireReceiver);
				isClimbing = false;
				hero.rigidbody2D.gravityScale = 3;
				anim.SetInteger ("IsClimb", 0);
						
				
		}

}

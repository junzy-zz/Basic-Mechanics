using UnityEngine;
using System.Collections;

public class PullPush : MonoBehaviour {

	
	public LayerMask CollisionMask;
	public Transform thingToPull;
//	public Transform thingToPick
	private bool facing;
	private PlatformerCharacter2D platf;
	Animator anim;
	// Use this for initialization
	void Start () {
		//thingToPull=GameObject.FindGameObjectWithTag("Crate").transform;

	}
	void Awake()
	{
		platf = GetComponent<PlatformerCharacter2D>();
		anim = GetComponent<Animator>();

	}
	// Update is called once per frame
	void Update () {
		facing = platf.facingRight;
		//Debug.Log(facing);
		Vector2 temp= new Vector2(transform.position.x,transform.position.y);

		RaycastHit2D hit ;
		if(facing)
			hit= Physics2D.Raycast(new Vector2(temp.x+1,temp.y), transform.right, 0.5f, CollisionMask);
		else
			hit= Physics2D.Raycast(new Vector2(temp.x-1,temp.y), transform.right*(-1), 0.5f, CollisionMask);
		if (hit) 
		{
			if(Input.GetKey("p") && hit.transform.tag=="Crate")
			{
				thingToPull=hit.transform;
				anim.SetInteger("Grabbed", 1);
				thingToPull.transform.rigidbody2D.mass=1;
			}

		
			else
			{
				if(thingToPull!=null)
					thingToPull.transform.rigidbody2D.mass=1000;
				thingToPull=null;
				anim.SetInteger("Grabbed",0);
			}
		
			//Debug.Log(hit.collider);
		}
		else
		{
			anim.SetInteger("Grabbed",0);
		}
	if(facing)	
		Debug.DrawRay(new Vector2(temp.x+1,temp.y), transform.right, Color.red);
		else
			Debug.DrawRay(new Vector2(temp.x-1,temp.y), transform.right*(-1), Color.red);

	}

	
	}


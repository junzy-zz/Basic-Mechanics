using UnityEngine;
using System.Collections;

public class CollapsablePlatform : MonoBehaviour {

	public float Seconds =2.0f;
	void OnCollisionEnter2D()
	{
		StartCoroutine(CollapseDelay());
		rigidbody2D.isKinematic=false;
		rigidbody2D.mass=10;
	}
	IEnumerator CollapseDelay()
	{
		yield return new WaitForSeconds(Seconds);

	}
}	


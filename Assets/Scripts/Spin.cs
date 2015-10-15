/*==============================================================================
Spins the object being displayed.
==============================================================================*/
using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 75f;
	
	void Update ()
	{
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}
}
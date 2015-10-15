/*==============================================================================
Plays audio when called that is attached to object.
==============================================================================*/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ExampleClass : MonoBehaviour
{
	public AudioClip impact;

	void OnCollisionEnter ()
	{
		audio.PlayOneShot (impact, 0.7F);
	}
}
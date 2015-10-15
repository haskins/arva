/*==============================================================================
Plays audio of object when called.
==============================================================================*/
using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public AudioClip audioClip;

	public void Play(){
		AudioSource.PlayClipAtPoint(audioClip, transform.position);
	}
}
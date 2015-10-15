/*==============================================================================
Plays audio when a target is found
==============================================================================*/
using UnityEngine;
using System.Collections;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour,
ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	
	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}

	// When state of object is changed to being displayed, play clip
	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			// Play audio when target is found
			audio.Play ();
		} else {
			// Stop audio when target is lost
			audio.Stop ();
		}
	}   
}

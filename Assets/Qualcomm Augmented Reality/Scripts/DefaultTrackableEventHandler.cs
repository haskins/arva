/*==============================================================================
This provides functionality for Vuforia's AR tools when an action occurs.

Original file:
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.

Modifications:
Devon Harker
Josh Haskins
Vincent Tennant
==============================================================================*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
	{
		public static bool dismissButtonStatus = false;


        #region PRIVATE_MEMBER_VARIABLES
 
		private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
		void Start ()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
			if (mTrackableBehaviour) {
				mTrackableBehaviour.RegisterTrackableEventHandler (this);
			}
		}

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged (
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
				OnTrackingFound ();
			} else {
				OnTrackingLost ();
			}
		}

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS

		// Determine which target has been found and display appropriate augmented data.
		private void OnTrackingFound ()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);

			// Clear status as object has been found.
			TextStatusUpdate.setText ("");

			// Enable rendering of specific object that belongs to our target.
			foreach (Renderer component in rendererComponents) {
				if (component.name == "TargetSymbol5177") {
					component.enabled = true;
					CustomParse.updateRoomText ("5-177");
				} else if (component.name == "TargetSymbol5176") {
					component.enabled = true;
					CustomParse.updateRoomText ("5-176");
				} else if (component.name == "TargetSymbol5159") {
					component.enabled = true;
					CustomParse.updateRoomText ("5-159");
				} else if (component.name == "TargetSymbol5157") {
					component.enabled = true;
					CustomParse.updateRoomText ("5-157");
				} else if (component.name == "TargetSymbol102054") {
					component.enabled = true;
					CustomParse.updateRoomText ("10-2054");
				} else if (component.name == "HT1") {
					component.enabled = true;
					HuntCount.foundHuntItems [0] = true;
					CustomParse.updateHuntText (1, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT2") {
					component.enabled = true;
					HuntCount.foundHuntItems [1] = true;
					CustomParse.updateHuntText (2, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT3") {
					component.enabled = true;
					HuntCount.foundHuntItems [2] = true;
					CustomParse.updateHuntText (3, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT4") {
					component.enabled = true;
					HuntCount.foundHuntItems [3] = true;
					CustomParse.updateHuntText (4, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT5") {
					component.enabled = true;
					HuntCount.foundHuntItems [4] = true;
					CustomParse.updateHuntText (5, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT6") {
					component.enabled = true;
					HuntCount.foundHuntItems [5] = true;
					CustomParse.updateHuntText (6, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT7") {
					component.enabled = true;
					HuntCount.foundHuntItems [6] = true;
					CustomParse.updateHuntText (7, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT8") {
					component.enabled = true;
					HuntCount.foundHuntItems [7] = true;
					CustomParse.updateHuntText (8, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT9") {
					component.enabled = true;
					HuntCount.foundHuntItems [8] = true;
					CustomParse.updateHuntText (9, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT10") {
					component.enabled = true;
					HuntCount.foundHuntItems [9] = true;
					CustomParse.updateHuntText (10, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT11") {
					component.enabled = true;
					HuntCount.foundHuntItems [10] = true;
					CustomParse.updateHuntText (11, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT12") {
					component.enabled = true;
					HuntCount.foundHuntItems [11] = true;
					CustomParse.updateHuntText (12, HuntCount.countFound (), HuntCount.totalHuntItems);
				} 

				// These objects added just for demonstation during presentation.
				else if (component.name == "HT1p") {
					component.enabled = true;
					HuntCount.foundHuntItems [1] = true;
					CustomParse.updateHuntText (1, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT2p") {
					component.enabled = true;
					HuntCount.foundHuntItems [2] = true;
					CustomParse.updateHuntText (2, HuntCount.countFound (), HuntCount.totalHuntItems);
				} else if (component.name == "HT4p") {
					component.enabled = true;
					HuntCount.foundHuntItems [4] = true;
					CustomParse.updateHuntText (4, HuntCount.countFound (), HuntCount.totalHuntItems);
				}
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents) {
				component.enabled = true;
			}

			Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}

		// Disables any enabled AR objects.
		private void OnTrackingLost ()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents) {
				component.enabled = false;				
			}

			// Clears the various text objects for room information.
			TextRoomNumberUpdate.setText ("");
			TextProfNameUpdate.setText ("");
			TextRoomTypeUpdate.setText ("");
			TextHoursDayUpdate.setText ("");
			TextHoursEndUpdate.setText ("");
			TextHoursStartUpdate.setText ("");
			TextHoursTitleUpdate.setText ("");
			TextCourseTitleUpdate.setText ("");

			// Clears the various text objects for scavenger hunt.
			TextTitleUpdate.setText ("");
			TextDescriptionUpdate.setText ("");
			TextClueUpdate.setText ("");
			TextProgressUpdate.setText ("");

			// Sets status to waiting for target.
			TextStatusUpdate.setText ("Waiting for target");
			
			// Disable colliders:
			foreach (Collider component in colliderComponents) {
				component.enabled = false;
			}

			Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}

        #endregion // PRIVATE_METHODS
	}
}

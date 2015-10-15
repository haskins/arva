/*==============================================================================
Provides functionality for using buttons to go back to the previous screen.
This includes the ESC key on a computer and the BACK button on Android.
==============================================================================*/
using UnityEngine;
using System.Collections;

public class PhysicalButtonScript : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
	{
		if ((Application.loadedLevelName == "Load")) { 
			Application.LoadLevel ("Menu");
		}

		if (Input.GetKeyDown (KeyCode.Escape) && (Application.loadedLevelName == "ARVA")) { 
			//this clears the Status Update text on screen so that it is not displayed on the Menu scene
			//TextStatusUpdate.clear();
			Application.LoadLevel ("Menu");
		}

		if (Input.GetKeyDown (KeyCode.Escape) && (Application.loadedLevelName == "Help")) { 
			Application.LoadLevel ("Menu");
		}

		if (Input.GetKeyDown (KeyCode.Escape) && (Application.loadedLevelName == "Menu")) { 
			Application.Quit (); 
		}
	}
}

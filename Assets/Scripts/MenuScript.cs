/*==============================================================================
Provides Menu navigation functionality.
==============================================================================*/
using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	
	private void delay ()
	{
		int count = 0;
		for (int i = 0; i < 900000; i++) {
			count = count * 3 / 2;
		}
	}

	public void OnClickARVA ()
	{
		delay ();
		Application.LoadLevel ("ARVA");
	}

	public void OnClickHelp ()
	{
		delay ();
		Application.LoadLevel ("Help");
	}

	public void OnClickMenu ()
	{
		Application.LoadLevel ("Menu");
	}
}

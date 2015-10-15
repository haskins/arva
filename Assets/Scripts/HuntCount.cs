/*==============================================================================
Tracks Scavenger Hunt items and updates the count when target is found.
==============================================================================*/
using UnityEngine;
using System.Collections;

public class HuntCount : MonoBehaviour {
	
	public static int countedHuntItems = 0;
	public static int  totalHuntItems = 12;
	public static bool [] foundHuntItems = new bool[totalHuntItems];

	public static int countFound(){
		int count = 0;
		foreach (bool x in foundHuntItems) {
			if (x == true){
				count = count + 1;
			}
		}
		return count;
	}
}

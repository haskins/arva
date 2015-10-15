/*==============================================================================
Provides functionality for accessing the remote Parse Core database.
==============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using Parse;
using System;

public class CustomParse : MonoBehaviour
{

	// Updates text for Scavenger Hunt.
	public static void  updateHuntText (int num, int found, int total)
	{

		ParseQuery<ParseObject> query = ParseObject.GetQuery ("ScavengerHunter").WhereEqualTo ("Entry_Number", num);
		query.FirstAsync ().ContinueWith (t =>
		{
			ParseObject res = t.Result;
			TextDescriptionUpdate.setText (res.Get<string> ("Description"));
			TextTitleUpdate.setText (res.Get<string> ("Title"));
			TextClueUpdate.setText ("Hint: " + res.Get<string> ("ClueToNext"));
			TextProgressUpdate.setText ("Found " + found + " of " + total);

		});

	}

	// Updates text for room information.
	public static void  updateRoomText (string roomNumber)
	{
		TextRoomNumberUpdate.setText (roomNumber);

		// Gets the room type.
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Room").WhereEqualTo ("Room_Number", roomNumber);
		query.FirstAsync ().ContinueWith (t =>
		{
			ParseObject res = t.Result;
			string roomType = res.Get<string> ("Room_Type");
			TextRoomTypeUpdate.setText (roomType);
			
		});

		//Gets day, start and end times.
		ParseQuery<ParseObject> query3 = ParseObject.GetQuery ("TimeSlot").WhereEqualTo ("Room_Number", roomNumber);
		query3.FirstAsync ().ContinueWith (t =>
		{
			ParseObject res = t.Result;
			string day = res.Get<string> ("Day");
			int start = res.Get<int> ("Start_Time");
			int end = res.Get<int> ("End_Time");
			TextHoursTitleUpdate.setText ("Hours");
			TextHoursDayUpdate.setText (day);
			TextHoursStartUpdate.setText ("" + start);
			TextHoursEndUpdate.setText ("" + end);
		});

		//Gets course title and teacher name.
		ParseQuery<ParseObject> query4 = ParseObject.GetQuery ("Course").WhereEqualTo ("Room_Number", roomNumber);
		query4.FirstAsync ().ContinueWith (t =>
		{
			ParseObject res = t.Result;
			string courseTitle = res.Get<string> ("Title");
			string profName = res.Get<string> ("Teachers");
			TextCourseTitleUpdate.setText (courseTitle);
			TextProfNameUpdate.setText (profName);
		});
	}
}

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameView : UIView {

	public Text timer;

	// Use this for initialization
	void Start () {
	
	}

	public void SetTime( float time )
	{
		string timeString = formatTimeString( time );
		timer.text = timeString;
	}

	private string formatTimeString( float time )
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds( time );
		string timeText = string.Format( "{0:D2}:{1:D2}:{2:D2}.{3:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds );

		return timeText;
	}

}

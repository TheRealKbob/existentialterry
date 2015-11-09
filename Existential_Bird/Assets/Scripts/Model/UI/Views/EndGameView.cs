using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameView : UIView {

	public delegate void EndGameEvent();
	public EndGameEvent OnEndGameEvent{ get; set; }
	
	[SerializeField]
	private Button replayButton;

	// Use this for initialization
	void Start () {
		replayButton.onClick.AddListener( () => { handleReplayButtonClick(); } );
	}
	
	private void handleReplayButtonClick ()
	{
		if( OnEndGameEvent != null )
			OnEndGameEvent();
	}
}

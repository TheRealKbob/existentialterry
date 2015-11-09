using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : UIView {

	public delegate void MainMenuEvent( string eventID );
	public MainMenuEvent OnPlayEvent{ get; set; }

	#region Screens

	public GameObject InitialScreen;
	public GameObject PlaySelectScreen;

	#endregion

	[SerializeField]
	private Button playButton;

	[SerializeField]
	private Button playNormalButton;

	[SerializeField]
	private Button playEndlessButton;

	// Use this for initialization
	void Start () {

		playButton.onClick.AddListener( () => { handlePlayButtonClick(); } );

		playNormalButton.onClick.AddListener( () => { handlePlayNormalButtonClick(); } );

		playEndlessButton.onClick.AddListener( () => { handlePlayEndlessButtonClick(); } );

	}

	public void Initialize()
	{
		InitialScreen.gameObject.SetActive(true);
		PlaySelectScreen.gameObject.SetActive(false);
	}

	private void handlePlayButtonClick ()
	{
		InitialScreen.gameObject.SetActive(false);
		PlaySelectScreen.gameObject.SetActive(true);
	}

	private void handlePlayNormalButtonClick ()
	{
		if( OnPlayEvent != null )
			OnPlayEvent( MainMenuEvents.PLAY_NORMAL );
	}

	private void handlePlayEndlessButtonClick ()
	{
		if( OnPlayEvent != null )
			OnPlayEvent( MainMenuEvents.PLAY_ENDLESS );
	}

}

public class MainMenuEvents
{
	public static string PLAY_NORMAL = "PLAY_NORMAL";
	public static string PLAY_ENDLESS = "PLAY_ENDLESS";
}


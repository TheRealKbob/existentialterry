using UnityEngine;
using System;
using System.Collections;

public class MainMenuGameState : GameState {

	private MainMenu view;
	private PlayerController playerController;
	private Vector3 initialPlayerPosition;
	private Quaternion initialPlayerRotation;

	private PlayerStateMachine playerStateMachine;
	private EnvironmentStateMachine environmentStateMachine;

	public MainMenuGameState( GameStateMachine stateMachine ) : base( stateMachine )
	{

		foreach( UIView v in UIManager.Instance.Views )
		{
			if( v is MainMenu )
			{
				view = v as MainMenu;
			}
		}

		playerController = GameObject.FindObjectOfType<PlayerController>() as PlayerController;

		playerStateMachine = GameObject.FindObjectOfType<PlayerStateMachine>() as PlayerStateMachine;
		environmentStateMachine = GameObject.FindObjectOfType<EnvironmentStateMachine>() as EnvironmentStateMachine;

		initialPlayerPosition = playerController.transform.position;
		initialPlayerRotation = playerController.transform.rotation;
	}
	
	public override void DoEnterState ()
	{
		view.Show();
		view.OnPlayEvent += playClicked;

		view.Initialize();
		resetPlayer();

		environmentStateMachine.CurrentState = EnvironmentStateMachine.EnvironmentStateTypes.MOVING;
	}

	public override void DoExitState ()
	{
		view.OnPlayEvent -= playClicked;
		view.Hide();
	}

	private void resetPlayer()
	{
		playerController.transform.position = initialPlayerPosition;
		playerController.transform.rotation = initialPlayerRotation;
		playerStateMachine.CurrentState = PlayerStateMachine.PlayerStateTypes.IDLE;
	}

	private void playClicked ( string eventID )
	{
		if( eventID == MainMenuEvents.PLAY_ENDLESS )
			stateMachine.CurrentState = GameStateMachine.GameStateTypes.PLAY;
	}
}

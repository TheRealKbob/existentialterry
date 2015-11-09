using UnityEngine;
using System;
using System.Collections;

public class PlayGameState : GameState {

	private PlayerStateMachine playerStateMachine;
	private EnvironmentStateMachine environmentStateMachine;

	private GameView view;

	private float gameStartTime;
	private float currentTime;

	public PlayGameState( GameStateMachine stateMachine ) : base( stateMachine )
	{
		foreach( UIView v in UIManager.Instance.Views )
		{
			if( v is GameView )
			{
				view = v as GameView;
			}
		}

		playerStateMachine = GameObject.FindObjectOfType<PlayerStateMachine>() as PlayerStateMachine;
		environmentStateMachine = GameObject.FindObjectOfType<EnvironmentStateMachine>() as EnvironmentStateMachine;
	}

	public override void DoEnterState ()
	{
		playerStateMachine.CurrentState = PlayerStateMachine.PlayerStateTypes.INGAME;
		environmentStateMachine.CurrentState = EnvironmentStateMachine.EnvironmentStateTypes.MOVING;
		gameStartTime = Time.time;
		view.Show();
	}
	
	public override void DoUpdate ()
	{
		currentTime = Time.time - gameStartTime;
		view.SetTime( currentTime );
	}
	
	public override void DoExitState ()
	{
		view.Hide();
	}

}

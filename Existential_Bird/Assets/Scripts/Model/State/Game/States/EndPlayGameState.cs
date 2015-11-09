using UnityEngine;
using System;
using System.Collections;

public class EndPlayGameState : GameState {

	private EndGameView view;

	public EndPlayGameState( GameStateMachine stateMachine ) : base( stateMachine )
	{
		foreach( UIView v in UIManager.Instance.Views )
		{
			if( v is EndGameView )
			{
				view = v as EndGameView;
			}
		}
	}

	public override void DoEnterState ()
	{
		view.Show();
		view.OnEndGameEvent += replayClicked;
	}
	
	public override void DoUpdate ()
	{
		
	}
	
	public override void DoExitState ()
	{
		view.OnEndGameEvent -= replayClicked;
		view.Hide();
	}

	private void replayClicked ()
	{
		stateMachine.CurrentState = GameStateMachine.GameStateTypes.MAINMENU;
	}

}

using UnityEngine;
using System.Collections;

public class PlayerDeadState : PlayerState {

	private EnvironmentStateMachine environmentStateMachine;
	private GameStateMachine gameStateMachine;

	public PlayerDeadState( PlayerStateMachine stateMachine ) : base( stateMachine )
	{
		environmentStateMachine = GameObject.FindObjectOfType<EnvironmentStateMachine>() as EnvironmentStateMachine;
		gameStateMachine = GameObject.FindObjectOfType<GameStateMachine>() as GameStateMachine;
	}

	public override void DoEnterState ()
	{
		stateMachine.controller.ApplyGravity = false;
		environmentStateMachine.CurrentState = EnvironmentStateMachine.EnvironmentStateTypes.IDLE;
		gameStateMachine.CurrentState = GameStateMachine.GameStateTypes.ENDPLAY;
	}	
}
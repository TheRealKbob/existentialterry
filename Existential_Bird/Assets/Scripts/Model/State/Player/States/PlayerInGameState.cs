using UnityEngine;
using System.Collections;

public class PlayerInGameState : PlayerState {
	
	public PlayerInGameState( PlayerStateMachine stateMachine ) : base( stateMachine ){}

	public override void DoEnterState ()
	{
		stateMachine.controller.ApplyGravity = true;
	}

	public override void DoUpdate()
	{
		if( Input.GetMouseButtonUp(0) )
		{
			stateMachine.controller.Jump();
		}
		if( stateMachine.controller.IsGrounded() )
		{
			stateMachine.CurrentState = PlayerStateMachine.PlayerStateTypes.DEAD;
		}

	}

}

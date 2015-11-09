using UnityEngine;
using System.Collections;

public class EnvironmentMovingState : EnvironmentState {

	public EnvironmentMovingState( EnvironmentStateMachine stateMachine ) : base( stateMachine ){}

	public override void DoUpdate()
	{
		stateMachine.controller.Move();
	}

}

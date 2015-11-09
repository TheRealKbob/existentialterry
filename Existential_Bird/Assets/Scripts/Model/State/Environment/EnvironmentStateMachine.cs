using UnityEngine;
using System.Collections;

public class EnvironmentStateMachine : StateMachine {

	public Environment controller{ get; private set; }

	public enum EnvironmentStateTypes
	{
		IDLE,
		MOVING
	}

	// Use this for initialization
	void Awake () {
		controller = GetComponent<Environment>();

		addState( EnvironmentStateTypes.IDLE, new EnvironmentIdleState( this ) );
		addState( EnvironmentStateTypes.MOVING, new EnvironmentMovingState( this ) );

		CurrentState = EnvironmentStateTypes.IDLE;

	}

}

public class EnvironmentState : State
{

	protected EnvironmentStateMachine stateMachine;

	public EnvironmentState( EnvironmentStateMachine stateMachine )
	{
		this.stateMachine = stateMachine;
	}
}

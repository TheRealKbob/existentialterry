using UnityEngine;
using System.Collections;

public class PlayerStateMachine : StateMachine {

	public PlayerController controller{ get; private set; }

	public enum PlayerStateTypes
	{
		IDLE,
		INGAME,
		DEAD
	}


	void Awake()
	{

		controller = gameObject.GetComponent<PlayerController>();

		addState( PlayerStateTypes.IDLE, new PlayerIdleState( this ) );
		addState( PlayerStateTypes.INGAME, new PlayerInGameState( this ) );
		addState( PlayerStateTypes.DEAD, new PlayerDeadState( this ) );

		CurrentState = PlayerStateTypes.IDLE;
	
		controller.OnPlayerControllerEvent += HandleControllerEvent;

	}

	private void HandleControllerEvent( string eventID )
	{
		(state as PlayerState).HandleControllerEvent( eventID );
	}

}

public class PlayerState : State
{

	protected PlayerStateMachine stateMachine;

	public PlayerState( PlayerStateMachine stateMachine ) : base()
	{
		this.stateMachine = stateMachine;
	}

	public virtual void HandleControllerEvent( string eventID ){}

}


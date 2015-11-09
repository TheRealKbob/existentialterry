using UnityEngine;
using System;
using System.Collections;

public class GameStateMachine : StateMachine {
	
	public enum GameStateTypes
	{
		MAINMENU,
		PAUSEMENU,
		PLAY,
		ENDPLAY
	}
	
	// Use this for initialization
	void Start () {
	
		addState( GameStateTypes.MAINMENU, new MainMenuGameState( this ) );
		addState( GameStateTypes.PAUSEMENU, new PauseMenuGameState( this ) );
		addState( GameStateTypes.PLAY, new PlayGameState( this ) );
		addState( GameStateTypes.ENDPLAY, new EndPlayGameState( this ) );

		CurrentState = GameStateTypes.MAINMENU;

	}

}

public class GameState : State
{
	protected GameStateMachine stateMachine;
	public GameState( GameStateMachine stateMachine ) : base()
	{
		this.stateMachine = stateMachine;
	}
}

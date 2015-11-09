using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	public enum UpdateTiming
	{
		NORMAL,
		FIXED,
		LATE
	}

	public UpdateTiming UpdateOn = UpdateTiming.NORMAL;

	protected IState state = new State();

	private Dictionary<Enum, IState> stateMap = new Dictionary<Enum, IState>();

	public Enum CurrentState
	{
		get
		{
			return state.ID;
		}

		set
		{
			state.DoExitState();
			state = getState( value );
			state.DoEnterState();
		}

	}

	protected void addState( Enum id, IState istate )
	{
		stateMap.Add( id, istate );
		istate.ID = id;
	}

	protected IState getState( Enum id )
	{
		if( stateMap.ContainsKey( id ) )
		{
			return stateMap[ id ];
		}
		return null;
	}
	
	void Update () {
		if( UpdateOn == UpdateTiming.NORMAL )
			state.DoUpdate();
	}
	
	void FixedUpdate () {
		if( UpdateOn == UpdateTiming.FIXED )
			state.DoUpdate();
	}
	
	void LateUpdate () {
		if( UpdateOn == UpdateTiming.LATE )
			state.DoUpdate();
	}
}

public interface IState
{
	Enum ID{ get; set; }
	void DoEnterState();
	void DoUpdate();
	void DoExitState();
}

public class State : IState
{
	public Enum ID{ get; set; }

	public State(){}

	public virtual void DoEnterState(){}
	public virtual void DoUpdate(){}
	public virtual void DoExitState(){}

}
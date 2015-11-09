using UnityEngine;
using System.Collections;

public class PlayerIdleState : PlayerState {

	public PlayerIdleState( PlayerStateMachine stateMachine ) : base( stateMachine ){}

	private float speed = 250f;
	private float angle = 0;

	public override void DoEnterState ()
	{
		stateMachine.controller.ApplyGravity = false;
	}

	public override void DoUpdate()
	{
		angle += speed * Time.deltaTime;
		if( angle >= 360 ) angle = 0;

		Transform playerTrans = stateMachine.controller.transform;

		float waveOffset = Mathf.Sin( angle * Mathf.Deg2Rad ) * 0.03f;

		Vector2 newPos = new Vector2( playerTrans.position.x, playerTrans.position.y + waveOffset );

		playerTrans.position = newPos;

	}

}

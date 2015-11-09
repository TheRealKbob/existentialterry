using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public delegate void PlayerControllerEvent( string eventID );
	public PlayerControllerEvent OnPlayerControllerEvent{ get; set; }

	private Rigidbody2D rigidBody;
	private CircleCollider2D circleCollider;

	public Vector2 JumpForce = new Vector2( 0, 600 );

	public float RotationSpeed = 10;
	public float rotationDescent = -10;

	public float MinAngle = -70;
	public float MaxAngle = 0;

	public LayerMask GroundLayer;

	private float gravityScale;
	public bool ApplyGravity
	{
		set
		{
			if( value == true )
				rigidBody.gravityScale = gravityScale;
			else
			{
				rigidBody.gravityScale = 0;
				rigidBody.velocity = Vector2.zero;
			}
		}
	}

	void Awake () {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		circleCollider = gameObject.GetComponent<CircleCollider2D>();
		gravityScale = rigidBody.gravityScale;
	}

	void Update () {
		rotateTowardsVelocity();
	}

	public void Jump()
	{
		rigidBody.velocity = Vector2.zero;
		rigidBody.AddForce( JumpForce );
		transform.rotation = Quaternion.AngleAxis( MaxAngle, Vector3.forward );
	}


	private void rotateTowardsVelocity()
	{
		Vector2 v = rigidBody.velocity;
		if( v.y > rotationDescent ) return;
		float angle =  Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
		angle = Mathf.Clamp( angle, MinAngle, MaxAngle );
		transform.rotation =  Quaternion.Slerp( transform.rotation, Quaternion.AngleAxis( angle, Vector3.forward), Time.deltaTime * RotationSpeed );
	}
	
	public bool IsGrounded()
	{
		if( Physics2D.OverlapCircle( transform.position, circleCollider.radius, GroundLayer ) )
		{
			rigidBody.velocity = Vector2.zero;
			return true;
		}
		return false;
	}

}

public class PlayerControllerEvents
{
	public static string GROUNDHIT = "GROUNDHIT";
}
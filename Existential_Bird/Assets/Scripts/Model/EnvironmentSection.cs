using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class EnvironmentSection : MonoBehaviour {

	public SpriteRenderer renderer{ get; private set; }

	public bool Active
	{
		get
		{
			return gameObject.active;
		}
		set
		{
			gameObject.SetActive( value );
		}
	}

	public int OrderInLayer
	{ 
		get
		{
			return renderer.sortingOrder;
		}
		set
		{
			renderer.sortingOrder = value;
		}
	}

	// Use this for initialization
	void Awake() 
	{
		renderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	public void ChangeSprite( Sprite sprite )
	{
		renderer.sprite = sprite;
	}

	public Sprite GetSprite()
	{
		return renderer.sprite;
	}

	public void SetAsGround()
	{
		BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>();
		bc.size = renderer.bounds.size;
		gameObject.layer = LayerMask.NameToLayer( "Ground" );

	}

}

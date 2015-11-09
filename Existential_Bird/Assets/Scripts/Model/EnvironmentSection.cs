using UnityEngine;
using System.Collections;

public class EnvironmentSection : MonoBehaviour {

	public SpriteRenderer renderer{ get; private set; }

	// Use this for initialization
	void Awake () {
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
}

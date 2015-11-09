using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnvironmentController : MonoBehaviour, IEnvironmentController
{

	private Environment environment;

	[Serializable]
	public struct GroundMapObject
	{
		public EnvironmentType Type;
		public Sprite Image;
	}

	public EnvironmentType CurrentType;

	public float Y_Offset = 0;

	public List<Environment.MapObject> GroundSprites = new List<Environment.MapObject>();
	public Dictionary<EnvironmentType, Sprite> groundLookup = new Dictionary<EnvironmentType, Sprite>();

	private List<EnvironmentSection> sections = new List<EnvironmentSection>();

	public EnvironmentSection GroundSectionPrefab;

	public float Speed = 10;

	private float tolerance = 0.998f;

	void Start()
	{
		environment = GameObject.FindObjectOfType<Environment>();

		transform.position = environment.transform.position;

		sections = gameObject.GetComponentsInChildren<EnvironmentSection>().ToList();
		
		initializeGroundTypeLookup();
		
		normalizeGroundPositions();
		
		ChangeAllSprites( EnvironmentType.SPRING );
	}

	public void Move () {
		
		for( int i = 0; i < sections.Count; i++ )
		{
			Vector3 p = sections[i].transform.position;
			Vector3 newPos = new Vector3( -Speed, 0, 0 );
			sections[i].transform.position += newPos * Time.deltaTime;
		}

		Vector3 epos = environment.transform.position;
		float swidth = sections[0].renderer.sprite.bounds.size.x;

		if( sections[0].transform.position.x < (environment.transform.position.x - swidth) )
		{
			EnvironmentSection first = sections[0];
			if( first.GetSprite() != groundLookup[ CurrentType ] )
			{
				first.ChangeSprite( groundLookup[ CurrentType ] );
			}
			sections.RemoveAt(0);
			sections.Add( first );
			repositionSections();
		}
		
	}

	private void initializeGroundTypeLookup()
	{
		foreach( Environment.MapObject gmo in GroundSprites )
		{
			groundLookup.Add( gmo.Type, gmo.Image );
		}
	}

	public void ChangeAllSprites ( EnvironmentType type )
	{
		CurrentType = type;
		foreach( EnvironmentSection gs in sections )
		{
			gs.ChangeSprite( groundLookup[ type ] );
		}
	}

	private void normalizeGroundPositions()
	{
		float swidth = sections[0].renderer.sprite.bounds.size.x;
		for( int i = 0; i < sections.Count; i++ )
		{
			sections[i].transform.position = environment.transform.position + new Vector3( swidth * i , Y_Offset, 0 );
		}
	}
	
	private void repositionSections ()
	{
		EnvironmentSection last = sections[ sections.Count - 1 ];
		EnvironmentSection first = sections[0];
		
		Vector3 fpos = first.transform.position;
		Vector3 lpos = new Vector3( (fpos.x + ( (sections.Count - 1) * first.renderer.sprite.bounds.size.x)) * tolerance, fpos.y, fpos.z );
		
		last.transform.position = lpos;
		
	}

}

public interface IEnvironmentController {
	
	void Move();
	
}

/*using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GroundController : EnvironmentController {



	public EnvironmentType CurrentType;

	public List<GroundMapObject> GroundSprites = new List<GroundMapObject>();
	public Dictionary<EnvironmentType, Sprite> groundLookup = new Dictionary<EnvironmentType, Sprite>();

	public GroundSection GroundSectionPrefab;

	private List<GroundSection> sections = new List<GroundSection>();

	public float Speed = 10;

	private float tolerance = 0.999f;

	// Use this for initialization
	void Start () {
		sections = gameObject.GetComponentsInChildren<GroundSection>().ToList();

		initializeGroundTypeLookup();

		normalizeGroundPositions();

		ChangeAllSprites( EnvironmentType.SPRING );
	}

	public override void Move () {

		for( int i = 0; i < sections.Count; i++ )
		{
			Vector3 p = sections[i].transform.position;
			Vector3 newPos = new Vector3( Speed, 0, 0 );
			sections[i].transform.position += newPos * Time.deltaTime;
		}

		if( sections[0].transform.position.x < -18.0f )
		{
			GroundSection first = sections[0];
			if( first.GetSprite() != groundLookup[ CurrentType ] )
			{
				first.ChangeSprite( groundLookup[ CurrentType ] );
			}
			sections.RemoveAt(0);
			sections.Add( first );
			repositionSections();
		}

	}

	void OnGUI()
	{
		if( GUI.Button( new Rect( 0, 0, 70, 30 ), "GREEN" ) )
		{
			CurrentType = EnvironmentType.SPRING;
		}

		if( GUI.Button( new Rect( 0, 80, 70, 30 ), "PURPLE" ) )
		{
			CurrentType = EnvironmentType.SUMMER;
		}
	}

	public void ChangeAllSprites ( EnvironmentType type )
	{
		CurrentType = type;
		foreach( GroundSection gs in sections )
		{
			gs.ChangeSprite( groundLookup[ type ] );
		}
	}

	private void initializeGroundTypeLookup()
	{
		foreach( GroundMapObject gmo in GroundSprites )
		{
			groundLookup.Add( gmo.Type, gmo.Image );
		}
	}

	private void normalizeGroundPositions()
	{
		GroundSection first = sections[0];
		Vector3 fpos = first.transform.position;
		for( int i = 0; i < sections.Count; i++ )
		{
			Vector3 npos = new Vector3( (fpos.x + ( i * first.renderer.sprite.bounds.size.x )) * tolerance, fpos.y, fpos.z );
		}
	}

	private void repositionSections ()
	{
		GroundSection last = sections[ sections.Count - 1 ];
		GroundSection first = sections[0];

		Vector3 fpos = first.transform.position;
		Vector3 lpos = new Vector3( (fpos.x + ( (sections.Count - 1) * first.renderer.sprite.bounds.size.x)) * tolerance, fpos.y, fpos.z );

		last.transform.position = lpos;

	}
}

*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnvironmentController : MonoBehaviour, IEnvironmentController
{

	private Environment environment;

	public EnvironmentType CurrentType;

	private float tolerance = 0.998f;
	private List<EnvironmentSection> sections;

	private float sectionWidth;
	private float sectionHeight;
	private float cameraToWorldWidth;

	public List<Environment.MapObject> GroundSprites = new List<Environment.MapObject>();
	public Dictionary<EnvironmentType, Sprite> spriteMap = new Dictionary<EnvironmentType, Sprite>();

	public EnvironmentSection GroundSectionPrefab;
 
	public float Speed = 10;

	public int OrderInLayer = 0;

	public int PercentToHide = 0;
	public bool StartInactive = false;

	void Start()
	{
		environment = GameObject.FindObjectOfType<Environment>();
		CurrentType = EnvironmentType.SPRING;

		Camera cam = Camera.main;
		Vector3 cameraLeft = cam.ScreenToWorldPoint( new Vector3( 0, 0, cam.nearClipPlane ) );
		Vector3 cameraRight = cam.ScreenToWorldPoint( new Vector3( Screen.width, 0, cam.nearClipPlane ) );
		cameraToWorldWidth = Mathf.Abs( (cameraRight - cameraLeft).x );

		transform.position = new Vector3( cameraLeft.x, transform.position.y, transform.position.z );
		initializeSpriteMap();
		initializeSections();
	}

	public void Move ()
	{
		foreach( EnvironmentSection sec in sections )
		{
			Vector3 pos = new Vector3( Speed, 0, 0 );
			sec.transform.localPosition -= pos * Time.deltaTime;
		}
		firstSectionToLast();
	}

	private void firstSectionToLast()
	{
		EnvironmentSection fsec = sections[0];
		Vector3 fsecPos = sections[0].transform.localPosition;
		Vector3 lsec = sections[ sections.Count - 1 ].transform.localPosition;
		if( fsecPos.x < -sectionWidth )
		{
			sections.RemoveAt(0);
			sections.Add(fsec);
			fsec.transform.localPosition = new Vector3(lsec.x + sectionWidth, fsecPos.y, fsecPos.z );

			int hidePct = Random.Range( 0, 100 );
			if(PercentToHide > 0)
				fsec.Active = !(hidePct < PercentToHide );
			else
				fsec.Active = true;
		}
	}

	private void initializeSpriteMap()
	{
		foreach( Environment.MapObject map in GroundSprites )
		{
			spriteMap.Add(map.Type, map.Image);
		}
		sectionWidth = spriteMap[CurrentType].bounds.size.x;
		sectionHeight = spriteMap[CurrentType].bounds.size.y;
	}

	private void initializeSections()
	{
		sections = new List<EnvironmentSection>();
		int i = 0;
		while( (sections.Count * sectionWidth) < (cameraToWorldWidth + (sectionWidth * 2)) )
		{
			GameObject go = new GameObject();

			Vector3 pos = new Vector3( (i * sectionWidth), go.transform.position.y, go.transform.position.z );
			go.transform.parent = transform;
			go.transform.localPosition = pos;

			EnvironmentSection sec = go.AddComponent<EnvironmentSection>() as EnvironmentSection;
			sec.OrderInLayer = OrderInLayer;
			sec.ChangeSprite( spriteMap[CurrentType] );
			sections.Add( sec );
			if(StartInactive) sec.Active = false;
			i++;
		}
	}	

}

public interface IEnvironmentController {
	
	void Move();
	
}

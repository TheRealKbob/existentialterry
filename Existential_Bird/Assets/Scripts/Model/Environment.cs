using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum EnvironmentType
{
	SPRING,
	SUMMER,
	FALL,
	WINTER,
	FUTURE,
	WASTELAND
}

public class Environment : MonoBehaviour {

	[Serializable]
	public struct MapObject
	{
		public EnvironmentType Type;
		public Sprite Image;
	}	

	public List<EnvironmentController> controllers;

	void Start()
	{

	}

	public void Move()
	{
		foreach( IEnvironmentController c in controllers )
		{
			c.Move();
		}
	}

}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	private static UIManager instance;
	public static UIManager Instance
	{
		get{ return instance; }
		set{ instance = value; }
	}

	public UIView[] Views{ get; private set; }

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		Views = GameObject.FindObjectsOfType<UIView>() as UIView[];

		foreach( UIView v in Views )
		{
			v.Hide();
		}

	}

}

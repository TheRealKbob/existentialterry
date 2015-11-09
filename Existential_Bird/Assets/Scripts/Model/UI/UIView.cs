using UnityEngine;
using System.Collections;

public class UIView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void Show()
	{
		gameObject.SetActive( true );
	}

	public void Hide()
	{
		gameObject.SetActive( false );
	}

}

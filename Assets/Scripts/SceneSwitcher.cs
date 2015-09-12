using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour {
	
	public void SwitchToSceneNumber ( int pSceneIndex ) {
		Application.LoadLevel( pSceneIndex );
	}

}

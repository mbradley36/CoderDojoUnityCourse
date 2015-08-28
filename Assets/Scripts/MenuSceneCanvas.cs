using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSceneCanvas : MonoBehaviour {

	private Button menuButton;
	private Button replayButton;
	
	void OnEnable () {
		
		menuButton = transform.Find ( "Button Play" ).GetComponent<Button>();
		menuButton.onClick.AddListener( () => { SceneManager.ChangeScene( SceneIds.Game ); } );
	}
}

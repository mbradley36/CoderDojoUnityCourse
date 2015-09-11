using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverSceneCanvas : MonoBehaviour {

	private Button _menuButton;
	private Button _replayButton;
	private Text _scoreDisplay;

	void OnEnable () {

		_menuButton = transform.Find ( "Button Menu" ).GetComponent<Button>();
		_menuButton.onClick.AddListener( () => { SceneManager.ChangeScene( SceneIds.Menu ); } );

		_replayButton = transform.Find ( "Button Replay" ).GetComponent<Button>();
		_replayButton.onClick.AddListener( () => { SceneManager.ChangeScene( SceneIds.Game ); } );

		_scoreDisplay = transform.Find ( "Text Score Numeral" ).GetComponent<Text>();
		_scoreDisplay.text = Model.instance.GetScore().ToString();
	}
}

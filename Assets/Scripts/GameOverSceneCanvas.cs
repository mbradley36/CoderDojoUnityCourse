using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverSceneCanvas : MonoBehaviour {

	private Text _scoreDisplay;

	void OnEnable () {

		_scoreDisplay = transform.Find ( "Text Score Numeral" ).GetComponent<Text>();
		_scoreDisplay.text = Model.instance.GetScore().ToString();
	}
}

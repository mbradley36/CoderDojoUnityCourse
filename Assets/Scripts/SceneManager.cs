using UnityEngine;
using System.Collections;

public enum SceneIds{
	Menu,
	Game,
	GameOver
}

public class SceneManager : MonoBehaviour {

	public const string SCENE_MENU = "MenuScene";
	public const string SCENE_GAME = "GameScene";
	public const string SCENE_GAMEOVER = "GameOverScene";

	public static void ChangeScene( SceneIds pScene )
	{
		Debug.Log ( "ChangeScene: " + pScene );

		switch( pScene ) 
		{
		case SceneIds.Menu:
			Application.LoadLevel( SCENE_MENU );
			break;
		case SceneIds.Game:
			Application.LoadLevel( SCENE_GAME );
			break;
		case SceneIds.GameOver:
			Application.LoadLevel( SCENE_GAMEOVER );
			break;
		default: 
			break;
		}
	}
}
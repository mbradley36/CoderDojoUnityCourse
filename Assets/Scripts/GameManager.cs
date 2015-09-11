using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Notes:
 * It is a known problem that the UI is presented at a large size in comparison with game content:
 * http://forum.unity3d.com/threads/ui-canvas-related-questions.265171/
 * To easily move between UI and Game view while viewing the Scene, double click the Canvas or the Camera
 */

public class GameManager : MonoBehaviour {
	//There will only be one game manager in the game. Because of this,
	//	we can set it up as a singleton. A singleton is a lone reference
	//	of a class that all other classes are able to reference without
	//	any setup. This means that you can call its functions anywhere!
	public static GameManager instance {get; private set;}

	private float minX, maxX, minY, maxY;
	private float padding;

	public GameObject obstaclePrefab;
	private float timerSet, timerLength;

	public float obstacleSpawnMinTime, obstacleSpawnMaxTime;

	private Canvas _canvas;
	private Button _quitButton;
	private Text _scoreDisplay;

	void Awake() {
		instance = this;
		ResetTimer();
		padding = 0.5f;
		Model.instance.SetScore( 0 );

		_canvas = GameObject.Find("GameSceneCanvas").GetComponent<Canvas>();
		_scoreDisplay = _canvas.transform.Find( "Text Score Value" ).GetComponent<Text>(); 
		_quitButton = _canvas.transform.Find( "Button Quit" ).GetComponent<Button>(); 
		_quitButton.onClick.AddListener( () => { SceneManager.ChangeScene( SceneIds.GameOver ); } );
	}


	void Start() {
		//We're going to calculate the world bounds of the 2D screen, so that
		//	we can do things like delete objects that go outside the
		//	bounds. That way we won't have a bunch of objects that we
		//	can't see slowing down our game!

		//Screen.width and Screen.height give pixel values, but we want to get
		//	the position values in Unity's world space, which are different.
		//First, we can get the vertical dimension(height) of the screen
		float height = Camera.main.GetComponent<Camera>().orthographicSize;
		//We can calculate our horizontal dimension(width), by multiplying
		//	the height by our screen's aspect ratio(width divided by height).
		float width = height * Screen.width/Screen.height;

		minX = -width - padding;
		maxX = width + padding;
		minY = -height - padding;
		maxY = height + padding;

		_scoreDisplay.text = Model.instance.GetScore().ToString();
	}

	void Update() {
		if(Time.time - timerSet > timerLength) {
			GameObject.Instantiate(obstaclePrefab, GetRandomPosition(), transform.rotation);
			ResetTimer();
		}
	}

	//Get functions, or getters, are a safe way to get private variables
	//	that you don't want other scripts to be able to change.
	public float GetMinX() {
		return minX;
	}
	
	public float GetMinY() {
		return minY;
	}

	public float GetMaxX() {
		return maxX;
	}
	
	public float GetMaxY() {
		return maxY;
	}

	public void UpdateScoreDisplay()
	{
		_scoreDisplay.text = Model.instance.GetScore().ToString();

	}
	
	//Function objects can call to see if they're in the game bounds
	public bool InGameBounds(Vector2 currentPosition) {
		//if the object has left the game bounds, we will return false
		if(currentPosition.x > maxX || currentPosition.x < minX || currentPosition.y > maxY || currentPosition.y < minY) {
			return false;
		} else return true;
	}

	private void ResetTimer() {
		timerSet = Time.time;
		timerLength = Random.Range(0.1f, 0.5f);
	}

	private Vector2 GetRandomPosition() {
		float xEdge = Random.Range(0f,1f);
		float min = Random.Range(0f,1f);

		if (xEdge > 0.5f) {
			float yPos = Random.Range(obstacleSpawnMinTime, obstacleSpawnMaxTime);
			if(min > 0.5f) {
				return new Vector2(minX, yPos);
			} else {
				return new Vector2(maxX, yPos);
			}

		} else {
			float xPos = Random.Range(minX, maxX);
			if(min > 0.5f) {
				return new Vector2(xPos, minY);
			} else {
				return new Vector2(xPos, maxY);
			}
		}
	}
}

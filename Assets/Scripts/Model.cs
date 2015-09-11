using UnityEngine;
using System.Collections;

public class Model {

	private static Model _instance;
	private int _score;

	public static Model instance
	{	
		get 
		{
			if( _instance == null )
			{
				_instance = new Model();
				_instance.Initialize();
			}

			return _instance;
		}
	}

	// Use this for initialization
	private void Initialize () {
		_score = 0;
	}
	
	public void SetScore( int pScore )
	{
		_score = pScore;
	}

	public int GetScore()
	{
		return _score;
	}

	public void ChangeScore( int pDelta )
	{
		_score += pDelta;
	}

}

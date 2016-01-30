using UnityEngine;
using System.Collections;

public class MoverComponent : MonoBehaviour, InputListener
{
	public float MoveStep = 5.0f;
	public float Speed = 10.0f;
	

	private Vector2 endPosition = Vector2.zero;
	private bool haveToMove = false;

	private void registerInputListener()
	{
		GameObject _GameObject = GameObject.FindGameObjectWithTag ("Managers");
		InputManager _InputManager = (InputManager)_GameObject.GetComponent<InputManager> ();

		_InputManager.registerListener (this);

		Debug.Log ("MoveComponent : registerInputListener() - register to InputManager");
	}

	// Use this for initialization
	void Start () 
	{
		registerInputListener ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (haveToMove) 
		{
			transform.position = Vector2.Lerp (transform.position, endPosition, Time.deltaTime * Speed);
			haveToMove = false;
		}
	}

	#region InputListener
	public void onMoveLeft()
	{
		Debug.Log ("MoveComponent : onMoveLeft()");
		endPosition = new Vector2 (transform.position.x -MoveStep, transform.position.y);
		haveToMove = true;
	}

	public void onMoveRight()
	{
		Debug.Log ("MoveComponent : onMoveRight()");
		endPosition = new Vector2 (transform.position.x+MoveStep, transform.position.y);
		haveToMove = true;
	}

	public void onMoveDown()
	{
		Debug.Log ("MoveComponent : onMoveDown()");
		endPosition = new Vector2 (transform.position.x, transform.position.y-MoveStep);
		haveToMove = true;
	}

	public void onMoveUp()
	{
		Debug.Log ("MoveComponent : onMoveUp()");
		endPosition = new Vector2 (transform.position.x, transform.position.y+MoveStep);
		haveToMove = true;
	}
	#endregion
}

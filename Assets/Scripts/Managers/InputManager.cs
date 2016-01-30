using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface InputListener
{
	void onMoveLeft();
	void onMoveRight();
	void onMoveDown();
	void onMoveUp();
};

public class InputManager : MonoBehaviour
{
	#region Singleton
	protected static InputManager mSingleton;
	
	static public InputManager getSingleton
	{
		get { return mSingleton; }
	}
	#endregion

	private List<InputListener> mListeners = new List<InputListener>();
	public List<InputListener> Listeners
	{
		get { return mListeners; }
	}
	
	#region init methods
	
	public void registerListener(InputListener pListener)
	{
		if (mListeners.Find(x => x.Equals(pListener)) == null)
		{
			mListeners.Add(pListener);
		}
		else
		{
			Debug.Log("InputManager - registerListener() : listener already registered");
		}
	}
	
	public void unregisterListener(InputListener pListener)
	{
		if (mListeners.Find(x => x.Equals(pListener)) != null)
		{
			mListeners.Remove(pListener);
		}
		else
		{
			Debug.Log("InputManager - unregisterListener() : listener is not registered");
		}
	}
	
	#endregion

	public void onMoveLeft()
	{
		foreach (InputListener listener in mListeners)
		{
			listener.onMoveLeft();
		}
	}
	
	public void onMoveRight()
	{
		foreach (InputListener listener in mListeners)
		{
			listener.onMoveRight();
		}
	}

	public void onMoveDown()
	{
		foreach (InputListener listener in mListeners)
		{
			listener.onMoveDown();
		}
	}

	public void onMoveUp()
	{
		foreach (InputListener listener in mListeners)
		{
			listener.onMoveUp();
		}
	}
	
	void Awake()
	{
		mSingleton = this;
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_ANDROID || UNITY_IPHONE
		//TODO : Mobile touch handler
		#else

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				onMoveUp();
			}

			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				onMoveDown();
			}

			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				onMoveLeft();
			}

			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				onMoveRight();
			}

		#endif
	}
}

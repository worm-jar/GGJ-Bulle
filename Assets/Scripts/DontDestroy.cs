using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	private static DontDestroy sceneManagerInstance;
	void Awake()
	{
		DontDestroyOnLoad(this);

		if (sceneManagerInstance == null)
		{
			sceneManagerInstance = this;
		}
		else
		{
			Object.Destroy(gameObject);
		}
	}
}

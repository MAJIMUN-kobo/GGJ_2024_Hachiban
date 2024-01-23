using UnityEngine;
using UnityEngine.InputSystem;

public class SakaneSceneManager : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Keyboard.current.escapeKey.wasPressedThisFrame)
		{
#if UNITY_EDITOR

			UnityEditor.EditorApplication.isPlaying = false;

#endif
		}
	}
}

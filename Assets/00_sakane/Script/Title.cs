using UnityEngine;
using Cysharp.Threading.Tasks;

public class Title : MonoBehaviour
{
	/// <summary>
	/// ƒQ[ƒ€ŠJn
	/// </summary>
	public void GameStart()
	{
		SceneLoader.Instance.LoadScene("MainScene").Forget();
	}
}

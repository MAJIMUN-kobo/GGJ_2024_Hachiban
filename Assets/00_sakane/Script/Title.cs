using UnityEngine;
using Cysharp.Threading.Tasks;

public class Title : MonoBehaviour
{
	/// <summary>
	/// ƒQ[ƒ€ŠJn
	/// </summary>
	public void GameStart(string name)
	{
		SceneLoader.Instance.LoadScene(name).Forget();
	}
}

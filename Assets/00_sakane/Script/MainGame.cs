using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainGame : MonoBehaviour
{
	/// <summary>
	/// ƒQ[ƒ€I—¹
	/// </summary>
	public void GameFinish(string name)
	{
		SceneLoader.Instance.LoadScene(name).Forget();
	}
}
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Title : MonoBehaviour
{
	/// <summary>
	/// �Q�[���J�n
	/// </summary>
	public void GameStart()
	{
		SceneLoader.Instance.LoadScene("MainScene").Forget();
	}
}

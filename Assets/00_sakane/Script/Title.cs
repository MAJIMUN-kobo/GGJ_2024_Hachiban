using UnityEngine;
using Cysharp.Threading.Tasks;

public class Title : MonoBehaviour
{
	/// <summary>
	/// �Q�[���J�n
	/// </summary>
	public void GameStart(string name)
	{
		SceneLoader.Instance.LoadScene(name).Forget();
	}
}

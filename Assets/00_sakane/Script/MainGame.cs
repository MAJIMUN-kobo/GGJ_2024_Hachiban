using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainGame : MonoBehaviour
{
	/// <summary>
	/// �Q�[���I��
	/// </summary>
	public void GameFinish(string name)
	{
		SceneLoader.Instance.LoadScene(name).Forget();
	}
}
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainGame : MonoBehaviour
{
	/// <summary>
	/// �Q�[���I��
	/// </summary>
	public void GameFinish()
	{
		SceneLoader.Instance.LoadScene("TitleScene").Forget();
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RMC.UnityGamePhysics.Shared
{
	/// <summary>
	/// Press the Spacebar to restart the scene.
	/// </summary>
	public class RestartSceneController : MonoBehaviour
	{
		protected void Update()
		{
			// Restart Scene		------------------------------------
			if (Input.GetKey(KeyCode.Space))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
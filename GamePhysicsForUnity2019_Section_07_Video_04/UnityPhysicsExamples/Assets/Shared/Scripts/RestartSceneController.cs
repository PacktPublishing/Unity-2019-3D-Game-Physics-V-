using Unity.Collections;
using Unity.Entities;
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
			
			if (Input.GetKey(KeyCode.Space))
			{
                // Restart DOTS		------------------------------------
                if (World.Active != null)
                {
                    NativeArray<Entity> entities = World.Active.EntityManager.GetAllEntities();
                    foreach (Entity entity in entities)
                    {
                        World.Active.EntityManager.DestroyEntity(entity);
                    }
                }

                // Restart Scene		------------------------------------
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
using UnityEngine;
namespace RMC.UnityGamePhysics.Shared
{
	public class MonoBehaviourTemplate : MonoBehaviour
	{
		protected void Awake()
		{
			Debug.Log("Awake");
		}
		protected void Start()
		{
		}
		protected void FixedUpdate()
		{
		}
		protected void OnTriggerEnter(Collider collider)
		{
		}
		protected void OnCollisionEnter(Collision collision)
		{
			Debug.Log("OnCollisionEnter: " + gameObject.name + " hit by " + collision.gameObject.name);
		}
		protected void Update()
		{
		}
		protected void OnDestroy()
		{
			Debug.Log("OnDestroy");
		}
	}
}
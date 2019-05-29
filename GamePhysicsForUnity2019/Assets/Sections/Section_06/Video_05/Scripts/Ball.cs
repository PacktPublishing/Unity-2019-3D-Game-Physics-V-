using RMC.UnityGamePhysics.Shared;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section06.Video05
{
	public class Ball : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 50;

		[SerializeField]
		private Rigidbody _rigidbody;

		//TODO: Why do this in Fixed?
		public void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			_rigidbody.AddForce(movement * _speed);
		}

		protected void OnTriggerEnter (Collider collider)
		{
			if (collider.gameObject.tag == CrazyBallConstants.CoinTag)
			{
				Coin coin = collider.gameObject.GetComponent<Coin>();
				if (coin != null && coin.IsAlive)
				{
					coin.DestroyMe();
					CrazyBallGame.Instance.Score++;
					SoundManager.Instance.PlayAudioClip(CrazyBallConstants.CoinSound);
				}
			}

			if (collider.gameObject.tag == CrazyBallConstants.FinishTag)
			{
				Coin coin = collider.gameObject.GetComponent<Coin>();
				if (coin != null && coin.IsAlive)
				{
					coin.DestroyMe();
					CrazyBallGame.Instance.Score++;
					SoundManager.Instance.PlayAudioClip(CrazyBallConstants.CoinSound);
				}
			}
		}
	}
}
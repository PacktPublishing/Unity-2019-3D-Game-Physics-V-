using RMC.UnityGamePhysics.Shared;
using System.Collections;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class Crate : MonoBehaviour
	{
		[SerializeField]
		private WorldItem _worldItem = null;

		[SerializeField]
		private SpriteRenderer _spriteRenderer = null;

		[SerializeField]
		private Sprite _idleSprite = null;

		[SerializeField]
		private Sprite _hitSprite = null;

		protected void Start()
		{
			_worldItem.OnHealthChange.AddListener(WorldItem_OnHealthChange);
		}

		private void WorldItem_OnHealthChange(float delta)
		{
			if (_worldItem.Health <= 0)
			{
				SoundManager.Instance.PlayAudioClip(UpsetDucksConstants.WinSound);

				UpsetDucksGame.Instance.DestroyCrate(this);
			}	
			else
			{
				if (delta > 10)
				{
					StartCoroutine(SetSpriteTemporarilyCoroutine(_hitSprite));
					SoundManager.Instance.PlayAudioClip(UpsetDucksConstants.CollisionSound);
				}
			}
		}

		private IEnumerator SetSpriteTemporarilyCoroutine(Sprite sprite)
		{
			_spriteRenderer.sprite = sprite;
			yield return new WaitForSeconds(0.5f);
			_spriteRenderer.sprite = _idleSprite;
		}
	}
}
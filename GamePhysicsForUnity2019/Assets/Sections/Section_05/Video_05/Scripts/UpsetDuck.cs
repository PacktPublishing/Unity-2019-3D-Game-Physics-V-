using RMC.UnityGamePhysics.Shared;
using System.Collections;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class UpsetDuck : MonoBehaviour
	{
		[SerializeField]
		private WorldItem _worldItem = null;

		[SerializeField]
		private SpriteRenderer _spriteRenderer = null;

		[SerializeField]
		private Sprite _idleSprite = null;

		[SerializeField]
		private Sprite _hitSprite = null;

		[SerializeField]
		private Sprite _deadSprite = null;

		protected void Start()
		{
			_worldItem.OnHealthChange.AddListener(WorldItem_OnHealthChange);
		}

		private void WorldItem_OnHealthChange(float delta)
		{
			if (_worldItem.Health <= 0)
			{
				_spriteRenderer.sprite = _deadSprite;
				SoundManager.Instance.PlayAudioClip(UpsetDucksConstants.WinSound);
				
			}
			else
			{
				if (delta > UpsetDucksConstants.MinUpsetDuckHealthChangeForReaction)
				{
					StartCoroutine(SetSpriteTemporarilyCoroutine(_hitSprite));
					SoundManager.Instance.PlayAudioClip(UpsetDucksConstants.CollisionSound);
				}
			}
		}

		private IEnumerator SetSpriteTemporarilyCoroutine(Sprite sprite)
		{
			_spriteRenderer.sprite = sprite;
			yield return new WaitForSeconds(UpsetDucksConstants.UpsetDuckSpriteFlickerDelay);
			_spriteRenderer.sprite = _idleSprite;
		}
	}
}
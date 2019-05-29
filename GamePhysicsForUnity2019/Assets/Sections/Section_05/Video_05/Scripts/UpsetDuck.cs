using RMC.UnityGamePhysics.Shared;
using System.Collections;
using UnityEngine;

namespace RMC.UnityGamePhysics.Sections.Section05.Video05
{
	public class UpsetDuck : MonoBehaviour
	{
		[SerializeField]
		private WorldItem _worldItem;

		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private Sprite _idleSprite;

		[SerializeField]
		private Sprite _hitSprite;

		[SerializeField]
		private Sprite _deadSprite;

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
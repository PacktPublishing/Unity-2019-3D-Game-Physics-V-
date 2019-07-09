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
			if (!_worldItem.IsAlive)
			{
				return;
			}

			if (_worldItem.Health <= 0)
			{
				_spriteRenderer.sprite = _deadSprite;

			}
			else
			{
				if (delta > UpsetDucksConstants.MinUpsetDuckHealthChangeForReaction)
				{
					StartCoroutine(SetSpriteTemporarilyCoroutine(_hitSprite));
				}
			}
		}

		private IEnumerator SetSpriteTemporarilyCoroutine(Sprite sprite)
		{
			_spriteRenderer.sprite = sprite;
			yield return new WaitForSeconds(UpsetDucksConstants.UpsetDuckSpriteFlickerDelay);

			if (_worldItem.IsAlive)
			{
				_spriteRenderer.sprite = _idleSprite;
			}
		}
	}
}
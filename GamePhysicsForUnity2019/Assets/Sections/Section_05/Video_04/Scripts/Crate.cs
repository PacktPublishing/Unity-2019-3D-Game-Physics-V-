﻿using UnityEngine;

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
				UpsetDucksGame.Instance.DestroyCrate(this);
			}	
			else
			{
				if (delta > UpsetDucksConstants.MinCrateHealthChangeForReaction)
				{
					_spriteRenderer.sprite = _hitSprite;
				}
			}
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

	public SpriteRenderer plantRenderer;
	public List<Sprite> plantSprites;

	public int currentSprite;

	private void Awake()
	{
        current = this;
	}

	public event Action ONThresholdReached;
	public void ThresholdReached()
	{
		if (currentSprite >= 5) return;
		currentSprite++;
		plantRenderer.sprite = plantSprites[currentSprite];
		ONThresholdReached?.Invoke();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    private HealthBar _healthBar;

	private float lowCD;
	private float highCD;

	private void Start()
	{
        _healthBar = HealthBar.current;
		lowCD = 3f;
		highCD = 6f;

		GameManager.current.ONThresholdReached += IncreaseCooldown;
	}

	public void HealPlant(Button button)
	{
		_healthBar.AddHealth(1);
		StartCoroutine(ButtonCooldown(button));
	}

	private void IncreaseCooldown()
	{
		lowCD += 1f;
		highCD += 1f;
	}

	private IEnumerator ButtonCooldown(Button button)
	{
		button.interactable = false;

		yield return new WaitForSeconds(Random.Range(lowCD, highCD));

		button.interactable = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar current;

    public Image healthBarDisplay;

    public float depleteRate;
    public float initialHealth;

    private GameManager _gameManager;
    private float _currentHealth;
    private float _currentHealthThreshold;

	private void Awake()
	{
        current = this;

        _currentHealth = initialHealth;
        _currentHealthThreshold = initialHealth - (initialHealth / 6);
	}

	private void Start()
	{
        _gameManager = GameManager.current;
    }

	// Update is called once per frame
	void Update()
    {
        CheckThreshold();

        _currentHealth -= depleteRate * Time.deltaTime;
        healthBarDisplay.fillAmount = _currentHealth / initialHealth;
    }

    private void CheckThreshold()
    {
        if (_currentHealth > _currentHealthThreshold) return;

        depleteRate += 1f;
        _currentHealthThreshold = _currentHealth - (initialHealth / 6);
        _gameManager.ThresholdReached();
    }

    public void AddHealth(float amount)
    {
        _currentHealth += amount;
    }
}

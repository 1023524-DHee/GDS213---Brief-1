using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flicker : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _spriteColor;
    private float _alphaValue;

    private Vector3 _initialPosition;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteColor = _spriteRenderer.color;

        _initialPosition = transform.position;
        
        StartCoroutine(LerpAlpha_Coroutine());
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(0f, Mathf.Sin(Time.time) + _initialPosition.y, 0f);
    }

    private IEnumerator LerpAlpha_Coroutine()
    {
        float startTime = Time.time;
        float randomTime = Random.Range(0.5f, 2f);
        float randomAlpha = Random.Range(0f, 1f);
        float currentAlphaValue = _alphaValue;
        
        while (Time.time < startTime + randomTime)
        {
            _alphaValue = Mathf.Lerp(currentAlphaValue, randomAlpha, (Time.time - startTime) / randomTime);
            _spriteColor.a = _alphaValue;
            _spriteRenderer.color = _spriteColor;
            yield return null;
        }

        StartCoroutine(LerpAlpha_Coroutine());
    }
}

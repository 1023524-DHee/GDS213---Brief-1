using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar current;

    public Image image;
    public AnimationCurve progressCurve;
    public GameObject progressObject;
    
    public float incrementAmount;

    private float _currentProgress;

    private void Awake()
    {
        current = this;
    }

    public void IncreaseProgress()
    {
        _currentProgress += incrementAmount * progressCurve.Evaluate(_currentProgress / 100);
        image.fillAmount = _currentProgress / 100;
        progressObject.transform.localScale = new Vector2(_currentProgress / 100f, _currentProgress / 100f);

        if (image.fillAmount >= 0.97)
        {
            StartCoroutine(ShutDown());
        }
    }

    private IEnumerator ShutDown()
    {
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    private ProgressBar _progressBar;

    private Vector3 _screenPos;
    private float _angleOffset;

    private void Start()
    {
        _progressBar = ProgressBar.current;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotate();
    }

    private void CheckRotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 vec3 = Input.mousePosition - _screenPos;
            _angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 vec3 = Input.mousePosition - _screenPos;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + _angleOffset);
        }
    }
}

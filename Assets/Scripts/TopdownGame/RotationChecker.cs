using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChecker : MonoBehaviour
{
    public enum CheckPosition
    {
        Top,
        Bottom
    }

    public CheckPosition _CheckPosition;
    private WheelManager _wheelManager;

    private void Start()
    {
        _wheelManager = WheelManager.current;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Wheel")) return;
        
        if(_CheckPosition == CheckPosition.Bottom) _wheelManager.BottomCheckerDetected();
        if(_CheckPosition == CheckPosition.Top) _wheelManager.TopCheckerDetected();
    }
}

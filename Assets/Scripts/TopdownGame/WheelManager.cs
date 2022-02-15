using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public static WheelManager current;
    public ProgressBar progressBar;
    
    private bool _isValidTurn;
    
    private void Awake()
    {
        current = this;
    }

    public void BottomCheckerDetected()
    {
        _isValidTurn = true;
    }

    public void TopCheckerDetected()
    {
        if (!_isValidTurn) return;

        _isValidTurn = false;
        progressBar.IncreaseProgress();
    }
}

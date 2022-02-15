using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager current;
    public KeyboardButton currentPickedUpKey;

    private bool _isKeyPickedUp;

    void Awake()
    {
        current = this;
    }

    public void KeyPickedUp(KeyboardButton key)
    {
        _isKeyPickedUp = true;
        currentPickedUpKey = key;
    }

    public event Action ONKeyPlacedDown;
    public void KeyPlacedDown()
    {
        ONKeyPlacedDown?.Invoke();
    }

    public event Action<KeyCode> ONUpKeyChanged;
    public void UpKeyChanged()
    {
        ONUpKeyChanged?.Invoke(currentPickedUpKey.GetKeyCode());
    }

    public event Action<KeyCode> ONRightKeyChanged;
    public void RightKeyChanged()
    {
        ONRightKeyChanged?.Invoke(currentPickedUpKey.GetKeyCode());
    }

    public event Action<KeyCode> ONDownKeyChanged;
    public void DownKeyChanged()
    {
        ONDownKeyChanged?.Invoke(currentPickedUpKey.GetKeyCode());
    }

    public event Action<KeyCode> ONLeftKeyChanged;
    public void LeftKeyChanged()
    {
        ONLeftKeyChanged?.Invoke(currentPickedUpKey.GetKeyCode());
    }

    public event Action ONUpKeyExpired;
    public void UpKeyExpired()
    {
        ONUpKeyExpired?.Invoke();
    }
    
    public event Action ONRightKeyExpired;
    public void RightKeyExpired()
    {
        ONRightKeyExpired?.Invoke();
    }
    
    public event Action ONDownKeyExpired;
    public void DownKeyExpired()
    {
        ONDownKeyExpired?.Invoke();
    }
    
    public event Action ONLeftKeyExpired;
    public void LeftKeyExpired()
    {
        ONLeftKeyExpired?.Invoke();
    }

    public event Action<ArrowKeyButton.KeyDirection> ONKeyPressed;

    public void KeyPressed(ArrowKeyButton.KeyDirection keyDirection)
    {
        ONKeyPressed?.Invoke(keyDirection);
    }
    
    #region Public Functions
    public bool IsKeyPickedUp()
    {
        return _isKeyPickedUp;
    }

    public void SetKeyPickedUp(bool value)
    {
        _isKeyPickedUp = value;
    }

    public KeyCode GetPickedUpKeyCode()
    {
        return currentPickedUpKey.GetKeyCode();
    }
    #endregion
}

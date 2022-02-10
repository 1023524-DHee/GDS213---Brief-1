using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager current;

    private bool isKeyPickedUp;
    private KeyCode currentPickedUpKeyCode;

    void Awake()
    {
        current = this;
    }

	private void Update()
	{
		
	}

    public void KeyPickedUp(KeyCode key)
    {
        isKeyPickedUp = true;
        currentPickedUpKeyCode = key;
    }

    public event Action ONKeyPlacedDown;
    public void KeyPlacedDown()
    {
        ONKeyPlacedDown?.Invoke();
    }

    public event Action<KeyCode> ONUpKeyChanged;
    public void UpKeyChanged(KeyCode key)
    {
        ONUpKeyChanged?.Invoke(key);
    }

    public event Action<KeyCode> ONRightKeyChanged;
    public void RightKeyChanged(KeyCode key)
    {
        ONRightKeyChanged?.Invoke(key);
    }

    public event Action<KeyCode> ONDownKeyChanged;
    public void DownKeyChanged(KeyCode key)
    {
        ONDownKeyChanged?.Invoke(key);
    }

    public event Action<KeyCode> ONLeftKeyChanged;
    public void LeftKeyChanged(KeyCode key)
    {
        ONLeftKeyChanged?.Invoke(key);
    }

    public bool IsKeyPickedUp()
    {
        return isKeyPickedUp;
    }

    public KeyCode GetPickedUpKeyCode()
    {
        return currentPickedUpKeyCode;
    }
}

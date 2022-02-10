using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowKeyButton : MonoBehaviour, IPointerDownHandler
{
    public enum KeyDirection
    {
        U,
        R,
        D,
        L
    }

    public KeyDirection keyDirection;
    public static ArrowKeyButton current;

    private KeyManager _keyManager;

    private bool _isDetectingCursor;

	private void Awake()
	{
        current = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        _keyManager = KeyManager.current;
    }

	public void OnPointerDown(PointerEventData eventData)
	{
        if (!_keyManager.IsKeyPickedUp()) return;
        if (!_isDetectingCursor) return;

        switch (keyDirection)
        {
            case KeyDirection.U:
                _keyManager.UpKeyChanged(_keyManager.GetPickedUpKeyCode());
                break;
            case KeyDirection.R:
                _keyManager.RightKeyChanged(_keyManager.GetPickedUpKeyCode());
                break;
            case KeyDirection.D:
                _keyManager.DownKeyChanged(_keyManager.GetPickedUpKeyCode());
                break;
            case KeyDirection.L:
                _keyManager.LeftKeyChanged(_keyManager.GetPickedUpKeyCode());
                break;
        }
    }
}

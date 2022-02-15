using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowKeyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public enum KeyDirection
    {
        U,
        R,
        D,
        L
    }

    public KeyDirection keyDirection;

    private KeyManager _keyManager;
    private KeyboardButton _acceptedKey;
    
    private RectTransform _rectTransform;
    private bool _canAcceptKey;
    private int _currentHealth;
    
	private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canAcceptKey = true;
    }

	// Start is called before the first frame update
	void Start()
    {
        _keyManager = KeyManager.current;
        _keyManager.ONKeyPressed += DepleteHealth;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_keyManager.IsKeyPickedUp()) return;
        if (!_canAcceptKey) return;
        
        _keyManager.currentPickedUpKey.SetIsInPlace(true, _rectTransform.anchoredPosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_keyManager.IsKeyPickedUp()) return;
        if (!_canAcceptKey) return;
        
        _keyManager.currentPickedUpKey.SetIsInPlace(false, Vector2.zero);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!_keyManager.IsKeyPickedUp()) return;
        if (!_canAcceptKey) return;
        
        AcceptNewKey();
    }

    private void AcceptNewKey()
    {
        switch (keyDirection)
        {
            case KeyDirection.U:
                _keyManager.UpKeyChanged();
                break;
            case KeyDirection.R:
                _keyManager.RightKeyChanged();
                break;
            case KeyDirection.D:
                _keyManager.DownKeyChanged();
                break;
            case KeyDirection.L:
                _keyManager.LeftKeyChanged();
                break;
        }

        _acceptedKey = _keyManager.currentPickedUpKey;
        _canAcceptKey = false;
        _currentHealth = Random.Range(20, 30);
        
        _keyManager.KeyPlacedDown();
        _keyManager.SetKeyPickedUp(false);
        
        Debug.Log(_currentHealth, this);
    }

    private void DepleteHealth(KeyDirection checkKey)
    {
        if (keyDirection != checkKey) return;
        
        _currentHealth--;
        if (_currentHealth <= 0)
        {
            switch (keyDirection)
            {
                case KeyDirection.U:
                    _keyManager.UpKeyExpired();
                    break;
                case KeyDirection.R:
                    _keyManager.RightKeyExpired();
                    break;
                case KeyDirection.D:
                    _keyManager.DownKeyExpired();
                    break;
                case KeyDirection.L:
                    _keyManager.LeftKeyExpired();
                    break;
            }
            
            _acceptedKey.gameObject.SetActive(false);
            _canAcceptKey = true;
        }
        
        Debug.Log(_currentHealth, this);
    }
}

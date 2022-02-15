using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardButton : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private KeyManager _keymanager;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;

    private Vector2 _initialPosition;
    private Vector2 _targetPosition;

    private bool _isInPlace;

    // Start is called before the first frame update
    void Start()
    {
        _keymanager = KeyManager.current;
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _initialPosition = _rectTransform.anchoredPosition;
    }

    public KeyCode GetKeyCode()
    {
        KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), gameObject.name);
        return thisKeyCode;
    }

     public void OnBeginDrag(PointerEventData eventData)
     {
         if (_isInPlace) return;

         _canvasGroup.alpha = 0.6f;
         _canvasGroup.blocksRaycasts = false;
         _keymanager.KeyPickedUp(this);
     }

     public void OnDrag(PointerEventData eventData)
     {
         _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
     }
     
     public void OnEndDrag(PointerEventData eventData)
     {
         ConfirmPosition();
     }

     private void SetPosition(Vector2 newPosition)
     {
         _rectTransform.anchoredPosition = newPosition;
     }
     
     public void SetIsInPlace(bool value,Vector2 newPosition)
     {
         _isInPlace = value;
         _targetPosition = newPosition;
     }

     private void ConfirmPosition()
     {
         if (_isInPlace)
         {
             SetPosition(_targetPosition);
             _canvasGroup.blocksRaycasts = false;
         }
         else if (!_isInPlace)
         {
             SetPosition(_initialPosition);
             _canvasGroup.blocksRaycasts = true;
         }
         
         _canvasGroup.alpha = 1f;
     }
}

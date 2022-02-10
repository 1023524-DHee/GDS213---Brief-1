using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardButton : MonoBehaviour, IPointerClickHandler
{
    private KeyManager _keymanager;

    // Start is called before the first frame update
    void Start()
    {
        _keymanager = KeyManager.current;
        GetKeyCode();
    }


    private KeyCode GetKeyCode()
    {
        KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), gameObject.name);
        return thisKeyCode;
    }

	public void OnPointerClick(PointerEventData eventData)
	{
        Debug.Log(gameObject.name);
        _keymanager.KeyPickedUp(GetKeyCode());
    }
}

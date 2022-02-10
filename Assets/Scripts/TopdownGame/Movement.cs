using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float moveSpeed;

    private KeyCode _upKey;
    private KeyCode _rightKey;
    private KeyCode _downKey;
    private KeyCode _leftKey;

	private Rigidbody2D _playerRB;
	private KeyManager _keyManager;

	private int _horizontalMove;
	private int _verticalMove;

	private void Awake()
	{
		_playerRB = GetComponent<Rigidbody2D>();
		_keyManager = KeyManager.current;
	}

	private void OnEnable()
	{
		Debug.Log(_keyManager);
		_keyManager.ONUpKeyChanged += UpdateUpKey;
		_keyManager.ONRightKeyChanged += UpdateRightKey;
		_keyManager.ONLeftKeyChanged += UpdateDownKey;
		_keyManager.ONDownKeyChanged += UpdateLeftKey;
	}

	private void Update()
	{
		if (Input.GetKey(_upKey))
		{
			_verticalMove = 1;
		}
		else if (Input.GetKey(_rightKey))
		{
			_horizontalMove = 1;
		}
		else if (Input.GetKey(_downKey))
		{
			_verticalMove = -1;
		}
		else if (Input.GetKey(_leftKey))
		{
			_horizontalMove = -1;
		}

		_verticalMove = 0;
		_horizontalMove = 0;
	}

	private void FixedUpdate()
	{
		_playerRB.velocity = new Vector2(moveSpeed * _horizontalMove, moveSpeed * _verticalMove);
	}

	private void UpdateUpKey(KeyCode key)
	{
		Debug.Log(key);
		_upKey = key;
	}

	private void UpdateRightKey(KeyCode key)
	{
		Debug.Log(key);
		_rightKey = key;
	}

	private void UpdateDownKey(KeyCode key)
	{
		Debug.Log(key);
		_downKey = key;
	}

	private void UpdateLeftKey(KeyCode key)
	{
		Debug.Log(key);
		_leftKey = key;
	}
}

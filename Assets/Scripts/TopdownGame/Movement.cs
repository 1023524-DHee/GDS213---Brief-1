using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private List<string> _correctSequences;
	private string _currentSequence;

	public float moveSpeed;

    private KeyCode _upKey;
    private KeyCode _rightKey;
    private KeyCode _downKey;
    private KeyCode _leftKey;

	private Rigidbody2D _playerRB;
	private KeyManager _keyManager;
	private ProgressBar _progressBar;
	
	private int _horizontalMove;
	private int _verticalMove;

	private void Awake()
	{
		_playerRB = GetComponent<Rigidbody2D>();
		_keyManager = KeyManager.current;
		_progressBar = ProgressBar.current;

		InitialiseSequences();
	}

	private void OnEnable()
	{
		_keyManager.ONUpKeyChanged += UpdateUpKey;
		_keyManager.ONRightKeyChanged += UpdateRightKey;
		_keyManager.ONDownKeyChanged += UpdateDownKey;
		_keyManager.ONLeftKeyChanged += UpdateLeftKey;

		_keyManager.ONUpKeyExpired += DisableUpKey;
		_keyManager.ONRightKeyExpired += DisableRightKey;
		_keyManager.ONDownKeyExpired += DisableDownKey;
		_keyManager.ONLeftKeyExpired += DisableLeftKey;
	}

	private void InitialiseSequences()
	{
		_currentSequence = "";
		_correctSequences = new List<string>();
		_correctSequences.Add("URDL");
		_correctSequences.Add("RDLU");
		_correctSequences.Add("DLUR");
		_correctSequences.Add("LURD");
	}
	
	private void Update()
	{
		if (Input.GetKeyDown(_upKey))
		{
			_keyManager.KeyPressed(ArrowKeyButton.KeyDirection.U);
			_currentSequence += "U";
		}
		if (Input.GetKeyDown(_rightKey))
		{
			_keyManager.KeyPressed(ArrowKeyButton.KeyDirection.R);
			_currentSequence += "R";
		}
		if (Input.GetKeyDown(_downKey))
		{
			_keyManager.KeyPressed(ArrowKeyButton.KeyDirection.D);
			_currentSequence += "D";
		}
		if (Input.GetKeyDown(_leftKey))
		{
			_keyManager.KeyPressed(ArrowKeyButton.KeyDirection.L);
			_currentSequence += "L";
		}
		
		CheckInputSequence();
	}

	private void CheckInputSequence()
	{
		if (_currentSequence.Length != 4) return;
		
		foreach (string correct in _correctSequences)
		{
			if (correct.Equals(_currentSequence))
			{
				_progressBar.IncreaseProgress();
			}
		}

		_currentSequence = "";
	}
	
	private void UpdateUpKey(KeyCode key) => _upKey = key;
	private void UpdateRightKey(KeyCode key) => _rightKey = key;
	private void UpdateDownKey(KeyCode key) => _downKey = key;
	private void UpdateLeftKey(KeyCode key) => _leftKey = key;

	private void DisableUpKey()
	{
		_upKey = KeyCode.None;
		_verticalMove = 0;
	}

	private void DisableRightKey()
	{
		_rightKey = KeyCode.None;
		_horizontalMove = 0;
	}

	private void DisableDownKey()
	{
		_downKey = KeyCode.None;
		_verticalMove = 0;
	}

	private void DisableLeftKey()
	{
		_leftKey = KeyCode.None;
		_horizontalMove = 0;
	}
}

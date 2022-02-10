using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private float _randomStart;

	private void Start()
	{
		_randomStart = Random.Range(0, 1f);
	}

	// Update is called once per frame
	void Update()
    {
        transform.position += new Vector3(0.0f, Mathf.Sin(Time.time + _randomStart) * moveSpeed, 0.0f);
    }
}

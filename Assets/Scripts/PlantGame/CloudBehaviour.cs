using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    private Vector3 _initialPosition;

	private void Start()
	{
        _initialPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
    {
        if (transform.position.x > 5f)
        {
            transform.position = _initialPosition;
        }
        else
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;
        }
    }
}

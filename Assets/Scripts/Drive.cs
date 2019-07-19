using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
	

	private Vector2 m_vec2Direction;

	private void Start()
	{

	}

	private void Update()
    {

		float fVertical = Input.GetAxis("Vertical");
		float fHorizontal = Input.GetAxis("Horizontal");

		m_vec2Direction = new Vector2(fHorizontal, fVertical);
		Vector2 vec2Position = transform.position;
		vec2Position += m_vec2Direction ;
		transform.position = vec2Position;
    }
}
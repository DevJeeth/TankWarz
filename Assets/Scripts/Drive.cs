using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float m_fspeed = 0.1f;
    public float m_frotationSpeed = 100.0f;
	public bool m_bPlayerController = false;

	private Vector2 m_vec2Direction;
	private Transform m_tFuelPosition;
	private CollectibleManager m_refCollectibleManager;
	private Vector3 m_vec3FuelPosition, m_vec3DirVector;
	private bool m_bFuelFound = false;

	private void Start()
	{
		m_refCollectibleManager = FindObjectOfType<CollectibleManager>();
		if(m_refCollectibleManager == null)
		{
			Debug.LogError("[Drive] Could not find CollectibleManager");
			return;
		}

		m_refCollectibleManager.RegisterToFuelGeneration(GetFuelPosition);
	}

	private void Update()
    {
		if (m_bPlayerController)
			PlayerDriver();
		else
			AiController();
    }

	private void PlayerDriver()
	{
		float fVertical = Input.GetAxis("Vertical");
		float fHorizontal = Input.GetAxis("Horizontal");

		m_vec2Direction = new Vector2(fHorizontal, fVertical);
		Vector2 vec2Position = transform.position;
		vec2Position += m_vec2Direction;
		transform.position = vec2Position;
	}

	private void AiController()
	{
		if(m_bFuelFound)
		{
			//if(Vector2.Distance(m_vec2FuelPosition, (Vector2)transform.position) <= 0.45f)
			//{
			//	//transform.position = m_vec2DirVector;
			//	m_bFuelFound = false;
			//	return;
			//}
			//Debug.Log("<color=red>"+ Vector2.Distance(m_vec2FuelPosition, (Vector2)transform.position) + "</color>");
			transform.position += m_vec3DirVector * m_fspeed * Time.deltaTime;  
		}
	}

	private void GetFuelPosition(Vector3 a_vec3FuelPosition)
	{
		m_vec3FuelPosition = a_vec3FuelPosition;
		m_vec3DirVector = transform.position - transform.position;
		Debug.Log("<color=green>Vector Direction Generated: "+m_vec3DirVector+"</color>");


		m_bFuelFound = true;
		Debug.Log("<color=green>Fuel position found</color>");
	}

	private void OnDisable()
	{
		if (m_refCollectibleManager == null)
		{
			Debug.LogError("[Drive] Could not find CollectibleManager");
			return;
		}

		m_refCollectibleManager.DeregisterFromFuelGeneration(GetFuelPosition);
	}
}
using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float m_fspeed = 0.1f;
    public float m_frotationSpeed = 100.0f;
	public float m_fStoppingDistance = 0.1f;
	public bool m_bPlayerController = false;

	private Vector2 m_vec2Direction;
	private Transform m_tFuelPosition;
	private CollectibleManager m_refCollectibleManager;
	private Vector3 m_vec3FuelPosition, m_vec3DirVector;
	private bool m_bFuelFound = false;
	private float m_fMagnitude = 0;

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
			if (HolisticMath.GetDistance(new Coords(transform.position), new Coords(m_vec3FuelPosition)) <= m_fStoppingDistance)
			{
				m_bFuelFound = false;
				return;
			}
			//Debug.Log("<color=red>"+ Vector2.Distance(m_vec2FuelPosition, (Vector2)transform.position) + "</color>");
			transform.position += m_vec3DirVector * m_fspeed * Time.deltaTime;
		}
	}

	private void GetFuelPosition(Vector3 a_vec3FuelPosition)
	{
		m_vec3FuelPosition = a_vec3FuelPosition;

		m_fMagnitude =
			HolisticMath.GetDistance(new Coords(0,0,0), new Coords(m_vec3FuelPosition));
		Debug.Log("<color=green> The magnitude of the vector from origin: "+m_fMagnitude+"</color>");
		m_vec3DirVector = m_vec3FuelPosition - transform.position;

		Coords dirNormal = HolisticMath.GetNormal(new Coords(m_vec3DirVector));
		m_vec3DirVector = dirNormal.ToVector();

		float fAngle = (HolisticMath.Angle(new Coords(transform.up), new Coords(m_vec3DirVector)));
		Debug.Log("<color=green>The angle between Tank Vector and Fuel Vector: "+ fAngle + "</color>");

		bool bclockwise = false;
		if(HolisticMath.CrossProduct(new Coords(transform.up), new Coords(m_vec3DirVector)).z < 0)
		{
			bclockwise = false;
		}

		Coords cNewDirection = HolisticMath.Rotate(new Coords(0, 1, 0), fAngle, bclockwise);
		m_bFuelFound = true;
		transform.up = cNewDirection.ToVector();
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

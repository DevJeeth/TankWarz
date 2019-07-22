using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectibleManager : MonoBehaviour
{
	[SerializeField] GameObject m_gFuelPrefab;
	public Vector3 m_vec3FuelPosition;

	private Action<Vector3> VectorPosition;
	public void RegisterToFuelGeneration(Action<Vector3> a_del)
	{
		VectorPosition += a_del;
	}

	public void DeregisterFromFuelGeneration(Action<Vector3> a_del)
	{
		if(VectorPosition != null)
		{
			VectorPosition -= a_del;
		}
	}

	private void Start()
	{
		Invoke("GenerateFuel", 1);
	}

	private void GenerateFuel()
	{
		GameObject gFuelPrefab = Instantiate(m_gFuelPrefab, new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), -10), Quaternion.identity);
		m_vec3FuelPosition = gFuelPrefab.transform.position;

		Vector3 Vec2FuelPosition = gFuelPrefab.transform.position;
		VectorPosition?.DynamicInvoke(Vec2FuelPosition);
	}


	private void Update()
    {
        
    }
}

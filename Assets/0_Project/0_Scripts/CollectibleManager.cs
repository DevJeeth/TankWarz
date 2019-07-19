using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
	[SerializeField] GameObject m_gFuelPrefab;
	public Vector3 m_vec3FuelPosition;

	void Awake()
	{
		GameObject gFuelPrefab = Instantiate(m_gFuelPrefab, new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), -10), Quaternion.identity);
		m_vec3FuelPosition = gFuelPrefab.transform.position;
	}


    void Update()
    {
        
    }
}

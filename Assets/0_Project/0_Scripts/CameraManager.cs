using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

	[SerializeField] Transform m_tPlayer;
	private Vector3 m_vec3Position;
    // Start is called before the first frame update
    void Start()
    {
		m_tPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
		m_vec3Position = new Vector3(m_tPlayer.position.x, m_tPlayer.position.y, transform.position.z);
		transform.position = m_vec3Position;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
	public Text m_textFuelValue;

	private Vector3 m_vec3CurrentPosition;

	private void Start()
	{

	}

	void Update()
    {
		float fFuelValue = 0; ;
		if (!string.IsNullOrEmpty(m_textFuelValue.text))
		{
			fFuelValue = float.Parse(m_textFuelValue.text);
		}

		if (fFuelValue <= 0f)
		{
			Debug.Log("<color=orange>[Drive] Fuel is empty</color>");
			return;
		}
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);

		fFuelValue -= Vector3.Distance(transform.position,m_vec3CurrentPosition);
		m_textFuelValue.text = fFuelValue.ToString();

		m_vec3CurrentPosition = transform.position;
		Debug.Log("<color=orange>[Drive] The current position has been updated</color>");
	}
}
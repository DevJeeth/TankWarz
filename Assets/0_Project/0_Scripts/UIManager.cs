using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject m_gTank, m_gfuel;
	[SerializeField] Text m_textTankPosition, m_textFuelPosition;
	[SerializeField] CollectibleManager m_refCollectibleManager;
	[SerializeField] Text m_textFuelAmount;
	[SerializeField] InputField inputField;


	// Start is called before the first frame update
	void Start()
    {
		m_refCollectibleManager = m_gfuel.GetComponent<CollectibleManager>();

		m_textTankPosition.text = m_gTank.transform.position.ToString();
		m_textFuelPosition.text = m_refCollectibleManager.m_vec3FuelPosition.ToString();

	}

    // Update is called once per frame
    void Update()
    { 
        
    }

	public void AddEnergy()
	{
		Debug.Log("<color=green>[UIManager] The Add Energy </color>");
		int n;
		if (int.TryParse(inputField.text, out n))
		{
			Debug.Log("<color=green>[UIManager] The Value Entered: " + n + "</color>");
			m_textFuelAmount.text = inputField.text;
		}
		else
		{
			Debug.LogError("[UIManager] Input not in int format");
		}
	}

}

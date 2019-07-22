using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath 
{

	static public Coords GetNormal(Coords a_cVector)
	{
		float fMagnitude = GetDistance(new Coords(0, 0, 0), a_cVector);

		a_cVector.x /= fMagnitude;
		a_cVector.y /= fMagnitude;
		a_cVector.z /= fMagnitude;
		return a_cVector;
	}

	static public float GetDistance(Coords a_cPointA, Coords a_cPointB)
	{
		float fMagnitude = (Square(a_cPointB.x - a_cPointA.x) + Square(a_cPointB.y - a_cPointA.y) + Square(a_cPointB.z - a_cPointA.z));
		fMagnitude = Mathf.Sqrt(fMagnitude);
	
		return fMagnitude;
	}

	static public float Square(float a_fvalue)
	{
		return (a_fvalue * a_fvalue);
	}
}

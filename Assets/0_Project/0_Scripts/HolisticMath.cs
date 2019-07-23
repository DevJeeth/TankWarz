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

	public static float DotProduct(Coords a_cPointA, Coords a_cPointB)
	{
		return ((a_cPointA.x * a_cPointB.x) + (a_cPointA.y * a_cPointB.y) + (a_cPointA.z * a_cPointB.z));
	}

	public static float Angle(Coords a_cPointA, Coords a_cPointB)
	{
		float fDotProduct = DotProduct(a_cPointA, a_cPointB);
		float fmagnitudeOfA = GetDistance(new Coords(Vector3.zero), a_cPointA);
		float fmagnitudeOfB = GetDistance(new Coords(Vector3.zero), a_cPointB);

		return Mathf.Acos(fDotProduct / (fmagnitudeOfA * fmagnitudeOfB));  //radians -> for degree *180/mathf.PI;
	}
}

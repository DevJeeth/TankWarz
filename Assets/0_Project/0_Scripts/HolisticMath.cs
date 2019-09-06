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

	public static Coords Rotate(Coords a_cAxis, float a_fAngle, bool a_bClockwise)
	{

		if(a_bClockwise)
		{
			a_fAngle = (2 * Mathf.PI) - a_fAngle;
		}

		float fXvalue =( a_cAxis.x * Mathf.Cos(a_fAngle)) - (a_cAxis.y * Mathf.Sin(a_fAngle));
		float fYvalue = (a_cAxis.x * Mathf.Sin(a_fAngle)) + (a_cAxis.y * Mathf.Cos(a_fAngle));
		return new Coords(fXvalue, fYvalue, 0);

	}

	public static Coords CrossProduct(Coords a_cVectorA, Coords a_cVectorB)
	{
		float fXvalue = (a_cVectorA.y * a_cVectorB.z - a_cVectorA.z * a_cVectorB.y);
		float fYvalue = (a_cVectorA.z * a_cVectorB.x - a_cVectorA.x * a_cVectorB.z);
		float fZvalue = (a_cVectorA.x * a_cVectorB.y - a_cVectorA.y * a_cVectorB.x);
		return new Coords(fXvalue, fYvalue, fZvalue);
	}


	
	public static Coords LookAt2D(Coords a_cPointA, Coords a_cPointB, Coords a_cAxis)
	{
		Vector3 vec3PointA, vec3PointB, vec3DirVector;
		float fAngle;

		vec3PointA = a_cPointA.ToVector();
		vec3PointB = a_cPointB.ToVector();


		vec3DirVector = vec3PointB - vec3PointA;
		fAngle = Angle(a_cAxis, new Coords(vec3DirVector));

		bool bclockwise = false;
		if (CrossProduct(a_cAxis, new Coords(vec3DirVector)).z < 0)
		{
			bclockwise = false;
		}

		Debug.Log("AXIS: "+a_cAxis+" Angle: "+ fAngle+" Clockwize: "+bclockwise);
		Coords cRotationValue = Rotate(a_cAxis, fAngle, bclockwise);
		return cRotationValue;
	}
}

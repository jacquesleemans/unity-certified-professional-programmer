using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 GetScale(this Vector3 vector3)
    {
        return new Vector3(vector3.x, vector3.y, vector3.z);
    }

    public static Vector3 ComponentDivide(this Vector3 thisVector, Vector3 targetVector)
    {
        Vector3 res = thisVector;

        if (!targetVector.x.Equals(0))
        {
            res.x = thisVector.x / targetVector.x;
        }
        
        if (!targetVector.y.Equals(0))
        {
            res.y = thisVector.y / targetVector.y;
        }
        
        if (!targetVector.z.Equals(0))
        {
            res.z = thisVector.z / targetVector.z;
        }
        
        return res;
    }
}
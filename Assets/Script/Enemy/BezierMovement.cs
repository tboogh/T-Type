using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BezierMovement : MonoBehaviour, IMovement
{
    public Vector3[] Points;

    public void SetPosition()
    {
        
    }

    public void SetRotation()
    {
        
    }

    public void Init()
    {
        
    }
    float t = 0;
    public void FrameUpdate(float deltaTime)
    {
        t += deltaTime * 0.1f;
        if (t > 1f)
            t = 0;
        
        transform.position = GetBezierPoint(t, Points);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int x = 0; x < Points.Length; ++x)
        {
            Gizmos.DrawWireSphere(Points[x], 0.2f);
        }

        for (int x = 0; x < Points.Length-1; ++x)
        {
            
            Gizmos.DrawLine(Points[x], Points[x+1]);
        }

        IList<Vector3> points = GetBezierApproximation(Points, 100);
        Gizmos.color = Color.blue;
        for (int i = 1; i < points.Count; ++i){
            Gizmos.DrawLine(points[i -1], points[i]);
        }

        IList<Vector3> points2 = GetBezierApproximation2(Points, 100);
        Gizmos.color = Color.red;
        for (int i = 1; i < points2.Count; ++i)
        {
            Gizmos.DrawLine(points2[i - 1], points2[i]);
        }
    }

    IList<Vector3> GetBezierApproximation(Vector3[] controlPoints, int outputSegmentCount)
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i <= outputSegmentCount; i++)
        {
            float t = (float)i / outputSegmentCount;
            points.Add(GetBezierPoint(t, controlPoints, 0, controlPoints.Length));
        }
        return points;
    }

    IList<Vector3> GetBezierApproximation2(Vector3[] controlPoints, int outputSegmentCount)
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i <= outputSegmentCount; i++)
        {
            float t = (float)i / outputSegmentCount;
            points.Add(GetBezierPoint(t, controlPoints));
        }
        return points;
    }

    Vector3 GetBezierPoint(float t, Vector3[] controlPoints, int index, int count)
    {
        if (count == 1)
            return controlPoints[index];
        var P0 = GetBezierPoint(t, controlPoints, index, count - 1);
        var P1 = GetBezierPoint(t, controlPoints, index + 1, count - 1);

        return (1 - t) * P0 + t * P1;
    }

    Vector3 GetBezierPoint(float t, Vector3[] controlPoints){
        var n = controlPoints.Length - 1;
        var a = Mathf.Pow(1 - t, n) * controlPoints[0];
        for (int i = 1; i < controlPoints.Length - 1; ++i)
        {
            var b = GetBinCoeff(n, i);
            a += b * Mathf.Pow(1 - t, n - i) * Mathf.Pow(t, i) * controlPoints[i];
        }
        a += Mathf.Pow(t, n) * controlPoints[n];
        return a;
    }

    int Factorial(int i)
    {
        if (i <= 1)
            return 1;
        return i * Factorial(i - 1);
    }

    public static long GetBinCoeff(long N, long K)
    {
        // This function gets the total number of unique combinations based upon N and K.
        // N is the total number of items.
        // K is the size of the group.
        // Total number of unique combinations = N! / ( K! (N - K)! ).
        // This function is less efficient, but is more likely to not overflow when N and K are large.
        // Taken from:  http://blog.plover.com/math/choose.html
        //
        long r = 1;
        long d;
        if (K > N) return 0;
        for (d = 1; d <= K; d++)
        {
            r *= N--;
            r /= d;
        }
        return r;
    }
}

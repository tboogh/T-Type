using System;
using UnityEngine;

public static class BoundsExtensions
{
    public static Bounds GetCompoundBounds(this GameObject gameObject)
    {
        Bounds bounds = new Bounds(gameObject.transform.position, Vector3.zero);
        
        Collider collider;
        try
        {
            collider = gameObject.GetComponent<Collider>();
            bounds.Encapsulate(collider.bounds);
        }
        catch (Exception)
        {
            // ignore
        }
        
        for (int i = 0; i < gameObject.transform.childCount; ++i)
        {
            var child = gameObject.transform.GetChild(i);            
            bounds.Encapsulate(child.gameObject.GetCompoundBounds());
        }
        return bounds;
    }
}
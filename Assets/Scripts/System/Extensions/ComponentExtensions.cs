using UnityEngine;
using System.Collections.Generic;

public static class ComponentExtensions
{
    public static List<T> GetComponents<T>(this GameObject gameObject) where T : class
    {
        List<T> components = new List<T>();
        Component[] allComponents = gameObject.GetComponents<Component>();

        foreach (var component in allComponents)
        {
            if (component is T tComponent)
            {
                components.Add(tComponent);
            }
        }

        return components;
    }
}

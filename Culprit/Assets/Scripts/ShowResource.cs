using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowResource
{
    public static void Show(Text ResourceText, ResourceStat resource)
    {
        if (resource != null)
            ResourceText.text = resource.value.ToString();
    }
}

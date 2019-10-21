using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public List<ResourceStat> Resources;

    private void Awake()
    {
        LoadResource();
    }
    public void LoadResource()
    {
        // TO DO somethin....
        string[] s = PlayerPrefsX.GetStringArray(KeySave.ALL_RESOURCE);
        for (int i = 0; i < s.Length; i++)
        {
            string[] temp = s[i].Split(',');
            if (temp.Length > 0 && temp.Length < 2)
            {
                TypeOfResource type = new TypeOfResource
                {
                    type = (TypeOfResource.Type)int.Parse(temp[0])
                };
                float.TryParse(temp[1], out float value);
                ResourceStat resource = new ResourceStat(value, type);
                Resources.Add(resource);
            }
        }
    }
    public void SaveResouce()
    {
        // TO DO somethin....
        List<string> s = new List<string>();
        foreach (ResourceStat resource in Resources)
        {
            Debug.Log((int)resource.Type.type + ", " + resource.value);
            s.Add((int)resource.Type.type + "," + resource.value);
        }
        PlayerPrefsX.SetStringArray(KeySave.ALL_RESOURCE, s.ToArray());
    }
    public bool ReduceResourceNeed(TypeOfResource.Type type, float Value)
    {
        ResourceStat resourceNeed = getResourceNeed(type);
        if (resourceNeed != null && Value > 0)
        {
            resourceNeed.ReduceValue(Value);
            SaveResouce();
            return true;
        }
        return false;
    }
    public bool AddResourceNeed(TypeOfResource.Type type, float Value)
    {
        ResourceStat resourceNeed = getResourceNeed(type);
        if (resourceNeed != null && Value > 0)
        {
            resourceNeed.AddValue(Value);
            SaveResouce();
            return true;
        }
        return false;
    }
    public ResourceStat getResourceNeed(TypeOfResource.Type type)
    {
        if ((int)type < Resources.Count)
            return Resources[(int)type];
        return null;
    }

}

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
        if (instance == null) instance = this;
        if (!PlayerPrefs.HasKey("IsTheFirst"))
        {
            PlayerPrefs.SetInt("IsTheFirst", 0);
        }
        else
            LoadResource();
    }
    public void LoadResource()
    {
        // TO DO somethin....
        string[] s = PlayerPrefsX.GetStringArray(KeySave.ALL_RESOURCE);
        for (int i = 0; i < s.Length; i++)
        {
            string[] temp = s[i].Split(',');
            Debug.Log(s[i].ToString());
            if (temp.Length > 0 && temp.Length <= 2)
            {
                TypeOfResource type = new TypeOfResource
                {
                    type = (TypeOfResource.Type)int.Parse(temp[0])
                };
                float.TryParse(temp[1], out float value);
                ResourceStat resource = getResourceNeed(type.type);
                resource.value = value;
            }
        }
    }
    public void SaveResouce()
    {
        // TO DO somethin....
        List<string> s = new List<string>();
        foreach (ResourceStat resource in Resources)
        {
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

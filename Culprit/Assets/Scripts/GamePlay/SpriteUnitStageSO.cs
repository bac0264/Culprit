using UnityEngine;
using System.Collections;

[CreateAssetMenu]
[System.Serializable]
public class SpriteUnitStageSO : ScriptableObject
{
    public Sprite[] sprites;

    public Sprite GetSprite(int index)
    {
        if (index >= 0 && index < sprites.Length) return sprites[index];
        return null;
    }
}

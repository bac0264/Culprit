using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowResource : MonoBehaviour
{
    public static ShowResource instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        Show();
    }
    public Text Gold;

    public void Show()
    {
        if(ResourceManager.instance != null)
        {
            ResourceStat Gold = ResourceManager.instance.getResourceNeed(TypeOfResource.Type.Gold);
            if (Gold != null) this.Gold.text = Gold.value.ToString();
        }
    }
}

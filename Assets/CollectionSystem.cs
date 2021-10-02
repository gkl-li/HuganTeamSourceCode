using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSystem : MonoBehaviour
{
    /// <summary>
    /// Expand for all other types later
    /// </summary>
    public enum CollectableType { GENERIC }

    public static CollectionSystem instance;
    private static Dictionary<CollectableType, int> collectedItemsDictionary = new Dictionary<CollectableType, int>();

    public Text infoText;

    private void Start()
    {
        instance = this;
    }

    public static void CollectItem(CollectableType collectableType)
    {
        if (!collectedItemsDictionary.ContainsKey(collectableType))
            collectedItemsDictionary[collectableType] = 0;
        collectedItemsDictionary[collectableType]++;
        instance.UpdateInfoText();
    }

    private void UpdateInfoText()
    {
        string info = "���ռ���\n";
        foreach(var v in collectedItemsDictionary)
        {
            info += string.Format("��Ʒ��{0}��ӵ��������{1}\n", v.Key.ToString(), v.Value);
        }
        infoText.text = info;
    }
}

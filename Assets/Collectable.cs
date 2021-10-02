using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    /// <summary>
    /// Used to identify type of object being collected
    /// </summary>
    public CollectionSystem.CollectableType collectableType;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CollectionSystem.CollectItem(this.collectableType);
            Destroy(this.gameObject);
        }
    }
}

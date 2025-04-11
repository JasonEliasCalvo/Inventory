using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            inventory.AddItem(item.Id, 1);
            Destroy(item.transform.parent.gameObject);
            Destroy(item.gameObject);
        }
    }
}

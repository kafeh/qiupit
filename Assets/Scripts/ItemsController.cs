using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField]
    private float timeInMinutes;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int itemsAllowed;
    private static int itemsSpawned;
    private GameObject[] items;
    private static List<GameObject> itemsInstatied;
    void Start()
    {
        items = Resources.LoadAll<GameObject>("Prefabs/Items");
        itemsInstatied = new List<GameObject>();
        itemsSpawned = 0;
        InvokeRepeating("ManageItems", 0f, 60 * timeInMinutes);
    }
    void ManageItems()
    {
        if (itemsSpawned >= itemsAllowed)
        {
            DestroyFarthestItem();
        }
        CreateItems();
    }
    void DestroyFarthestItem()
    {
        float farthest = Vector3.Distance(itemsInstatied[0].transform.position, player.transform.position);
        GameObject itemfarthest = itemsInstatied[0];
        foreach (var item in itemsInstatied)
        {
            if (farthest < Vector3.Distance(item.transform.position, player.transform.position))
            {
                farthest = Vector3.Distance(item.transform.position, player.transform.position);
                itemfarthest = item;
            }
        }
            Destroy(itemfarthest);
            itemsInstatied.Remove(itemfarthest);
            itemsSpawned--;
    }
    void CreateItems()
    {
        int item = Random.Range(0, items.Length);
        GameObject itemCreated = Instantiate(items[item], new Vector3(Random.Range(-1000.0F, 1000.0F),
            Random.Range(-1000.0F, 1000.0F), 0), Quaternion.identity);
        itemsInstatied.Add(itemCreated);
        itemsSpawned ++;
    }
    public static void DestroyItem(GameObject item)
    {
        Destroy(item);
        itemsInstatied.Remove(item);
        itemsSpawned--;
    }
}

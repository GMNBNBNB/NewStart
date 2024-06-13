using UnityEngine;

public class Item : MonoBehaviour
{
    [ItemCodeDescription]
    [SerializeField]
    private int _itemCode;

    private SpriteRenderer spriteRenderer;

    public int ItemCode { get { return _itemCode; } set { _itemCode = value; } }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (ItemCode != 0)
        {
            Inite(ItemCode); 
        }
    }

    public void Inite(int ItemCodeParam)
    {
        if (ItemCodeParam != 0)
        {
            ItemCode = ItemCodeParam;
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(ItemCode);
            spriteRenderer.sprite = itemDetails.itemSprite;

            if (itemDetails.itemType == ItemType.Reapable_scenary)
            {
                gameObject.AddComponent<ItemNudge>();
            }
        }
    }
}

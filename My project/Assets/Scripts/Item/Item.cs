using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
        
    }
}

using UnityEngine;

public class bonjou : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Inventory.instance.AddCoins(1000 / Mathf.Pow(10, 3 * Inventory.instance.puissanceNumberGold));
        }

        if (Input.GetMouseButtonDown(1))
        {
            Inventory.instance.RemoveCoins(1000 / Mathf.Pow(10, 3 * Inventory.instance.puissanceNumberGold));
        }
    }
}

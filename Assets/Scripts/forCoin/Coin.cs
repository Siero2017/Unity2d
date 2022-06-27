using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityAction TakeCoin;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            TakeCoin.Invoke();
        }
    }
}

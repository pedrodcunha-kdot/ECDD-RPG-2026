using UnityEngine;

public class MoedaColetavel : MonoBehaviour
{
    public int valor;

    private void Start()
    {
        valor = Random.Range(1,100);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SistemaInventario inventario = FindFirstObjectByType<SistemaInventario>();
            if (inventario != null)
            {
                inventario.ModificadorMoedas(valor);
                Destroy(gameObject);

            }
        }
    }
    }

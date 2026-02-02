using UnityEngine;
using TMPro;
public class InterfaceInventario : MonoBehaviour
{
    public SistemaInventario sistemaInventario;
    public Transform containerGrid;
    public GameObject prefabSlot;

    [Header("Economia")]
    public TextMeshProUGUI textoMoedas;
    private void Start()
    {
        //Inscrição no sistema de Eventos
        sistemaInventario.onInventarioMudou += AtualizarInterface;

        AtualizarInterface();
    }
    public void AtualizarInterface()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "Ouro: " + sistemaInventario.moedas.ToString();
        }
        foreach (Transform item in containerGrid)
        {
            Destroy(item.gameObject);
        }
        foreach (SlotInventario slot in sistemaInventario.inventario)
        {
            GameObject novoSlot = Instantiate(prefabSlot, containerGrid);
            novoSlot.GetComponent<SlotUi>().ConfigurarSlot(slot);
        }
    }
}
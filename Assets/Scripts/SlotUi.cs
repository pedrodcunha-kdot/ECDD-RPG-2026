
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUi : MonoBehaviour
{
    public Image imagemIcone;
    public TextMeshProUGUI textoQuantidade;

    public void ConfigurarSlot(SlotInventario slot)
    {
        if (slot != null && slot.dadosDoItem != null)
        {
            imagemIcone.enabled = true;
            imagemIcone.sprite = slot.dadosDoItem.icone;

            if (slot.quantidade > 1)
                    {
                textoQuantidade.text = slot.quantidade.ToString();

            }
            else
            {
                textoQuantidade.text = "";
            }
        }
        else
        {
            imagemIcone.enabled = false;
            textoQuantidade.text = "";
        }
    }
}
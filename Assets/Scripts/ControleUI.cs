using UnityEngine;

public class ControleUI : MonoBehaviour
{
    [Header("Paineis")]
    public GameObject painelInventario;
    public GameObject painelCrafting;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            painelCrafting.SetActive(false);
            painelInventario.SetActive(!painelInventario.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            painelInventario.SetActive(false);
            painelCrafting.SetActive(!painelCrafting.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            painelInventario.SetActive(false);
            painelCrafting.SetActive(false);
        }
       
    }
}


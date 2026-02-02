using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class SistemaInventario : MonoBehaviour
{
    public List<SlotInventario> inventario = new List<SlotInventario>();
    [Header("Economia")]
    public int moedas = 0;

    public event Action onInventarioMudou;
    public void AdicionarItem(DadosItem itemParaAdicionar, int quantidade)
    {
        //1. Verificar se o item é empilhavel
        if (itemParaAdicionar.ehEmpilhavel)
        {
            //1.1 Verifica se a mochila possui um item desse tipo
            for (int i = 0; i < inventario.Count; i++)
            {
                if (inventario[i].dadosDoItem == itemParaAdicionar)
                {
                    inventario[i].AdicionarQuantidade(quantidade);
                    Debug.Log($"Adicionado + {quantidade} ao item {itemParaAdicionar.nomeDoItem}");
                   
                    if(onInventarioMudou != null)
                    {
                        onInventarioMudou.Invoke();
                    }
                    return;
                }
            }
        }

        //2. Item não empilhavel ou ainda não possui um igual
        //Criando um novo slot
        SlotInventario novoSlot = new SlotInventario(itemParaAdicionar, quantidade);

        //Adicionado o slot ao inventario
        inventario.Add(novoSlot);
    }

    public void RemoverItem(DadosItem item, int quantidade)
    {
        //1. Verifica se o item existe no inventário
        foreach (SlotInventario slot in inventario)
        {
            if (slot.dadosDoItem == item)
            {
                //1.1 Subtrai a quantidade desejada de itens
                slot.SubtrairQuantidade(quantidade);
                Debug.Log($"Subtraido - {quantidade} ao item {item.nomeDoItem}. Total: {slot.quantidade}");
                if (slot.quantidade <= 0)
                    if (onInventarioMudou != null)
                    {
                        onInventarioMudou.Invoke();
                    }
                {
                    //Remove o item do inventario
                    inventario.Remove(slot);
                    Debug.Log($"Slot removido: {item.nomeDoItem}");
                    if (onInventarioMudou != null)
                    {
                        onInventarioMudou.Invoke();
                    }
                    return;
                }
            }
        }
    }

    public void ModificadorMoedas(int valor)
    {
        moedas += valor;
        if (moedas < 0)
        {
            moedas = 0;
        }

        if (onInventarioMudou != null)
        {
            onInventarioMudou.Invoke();
        }
    }
}
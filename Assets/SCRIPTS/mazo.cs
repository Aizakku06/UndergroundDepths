using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CartaManager : MonoBehaviour
{
    public TextMeshProUGUI cardQuantity;
    public TextMeshProUGUI discardCardQuantity;

    // Lista para almacenar las cartas
    [SerializeField] List<GameObject> cartasList = new List<GameObject>();
    [SerializeField] static List<GameObject> currentCartasList = new List<GameObject>();

    public int cardsInHand = 5;
    [SerializeField] List<GameObject> manoList = new List<GameObject>();
    [SerializeField] Transform handContainer;

    [SerializeField] List<GameObject> descarteList = new List<GameObject>();
    [SerializeField] float offsetX = 1f;
    [SerializeField] float offsetY = 1f;


    public void Start()
    {
        if(currentCartasList.Count == 0)
        {
            currentCartasList = cartasList;
        }
        
        UpdateText();
        StartPlayerTurn();

    }

    public void UpdateText()
    {
        cardQuantity.text = "" + currentCartasList.Count;
        discardCardQuantity.text = "" + descarteList.Count;
    }

    public void StartPlayerTurn()
    {
        StartCoroutine(SacarCartas());
    }

    IEnumerator SacarCartas()
    {
        for (int i = 0; i < cardsInHand; i++)
        {
            int select = Random.Range(0, currentCartasList.Count);
            GameObject go =  currentCartasList[select];

            // Hacer anim
            GameObject cardGO = Instantiate(go);
            cardGO.transform.SetParent(handContainer);
            cardGO.transform.position += i * offsetX * Vector3.right;
            cardGO.transform.position += offsetY * Vector3.up;

            yield return new WaitForSeconds(1f);
            manoList.Add(go);
            currentCartasList.RemoveAt(select);
            UpdateText();

            if(currentCartasList.Count == 0)
            {
                for (int j = 0; j < cardsInHand; j++)
                {
                    currentCartasList.Add(descarteList[j]);
                }
                descarteList.Clear();
            }
        }

        yield return new WaitForSeconds(0.02f);
    }

    public void EndOFTurn()
    {
        for (int i = 0; i < cardsInHand; i++)
        {
            descarteList.Add(currentCartasList[i]);
        }
        currentCartasList.Clear();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public GameObject obstaculo;
    public float espera;
    public float tempoDestruicao;

    public static GameController instancia = null;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        StartCoroutine(GerarObstaculos());

    }


    IEnumerator GerarObstaculos()
    {
        while (true)
        {
            Vector3 pos = new Vector3(6.6f, Random.Range(0f, 5.0f), -8.05f);
            GameObject obj = Instantiate(obstaculo, pos, Quaternion.Euler(0f,-90f,0f)) as GameObject;
            Destroy(obj, tempoDestruicao);
            yield return new WaitForSeconds(espera);
        }
    }
}

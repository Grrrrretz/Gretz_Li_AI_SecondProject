using UnityEngine;

public class S_dor : MonoBehaviour
{
    public GameObject safepos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {


        // ÏÈ´«ËÍÎ»ÖÃ
        other.transform.position = safepos.transform.position;
    }
}
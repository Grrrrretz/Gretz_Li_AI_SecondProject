using UnityEngine;

public class S_dor : MonoBehaviour
{
    public GameObject safepos;

    public GameObject player;
    public GameObject door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {


        CharacterController cc = other.GetComponent<CharacterController>();

            cc.enabled = false;
            other.transform.position = safepos.transform.position;
            cc.enabled = true;

    }



}
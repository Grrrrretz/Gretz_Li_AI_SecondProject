using NodeCanvas.DialogueTrees;
using Unity.VisualScripting;
using UnityEngine;

public class S_paint : MonoBehaviour
{
    public GameObject scareObject;
    public AudioClip scareSound;

    public float moveDistance = 1.5f;
    public float speed = 5f;

    private bool hasTriggered = false;
    private bool isMoving = false;

    private Vector3 startPos;
    private Vector3 targetPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = scareObject.transform.position;
        targetPos = startPos + scareObject.transform.forward * moveDistance;

        scareObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            scareObject.transform.position = Vector3.MoveTowards(scareObject.transform.position,targetPos,speed * Time.deltaTime);
            Destroy(scareObject, 2f);
        }

       
    }

    void OnTriggerEnter(Collider other)
    {
            if(!hasTriggered && other.CompareTag("Player"))
            {
            scareObject.SetActive(true);
            hasTriggered = true;
            isMoving = true;

            if (scareSound != null)
            {
                AudioSource.PlayClipAtPoint(scareSound, transform.position);
            }
        }


      
    }
}

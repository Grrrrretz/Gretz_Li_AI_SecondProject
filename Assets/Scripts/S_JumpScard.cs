using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class S_JumpScard : MonoBehaviour
{
    public GameObject player;
    public Camera playercam;
    public Collider selfCollider;
    public NavMeshAgent agent;
    public S_Playermovement playerctrl;
    public float activedis = 1f;

    public float shakeAmount = 0.1f;
    public float shakeSpeed = 50f;

    public float distanceFromPlayer = 1.2f;

    public bool isActive = false;

    public AudioClip jumpsc;
    bool hasPlayedSound = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerctrl = player.GetComponent<S_Playermovement>();

        if (playerctrl == null)
        {
            Debug.LogError("No S_playercontroler found on player!");
        }
        else
        {
            Debug.Log("Got player controller");
        }
    }

    // Update is called once per frame
    void Update()
    {

        

        if(Vector3.Distance(player.transform.position,transform.position) <= activedis)
        {
          isActive = true;
        }

        if(isActive)
        {
            selfCollider.enabled = false;
            agent.enabled = false;

            Vector3 targetPos = playercam.transform.position + playercam.transform.forward * distanceFromPlayer;
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;

            transform.position = targetPos + randomOffset;
            transform.LookAt(playercam.transform);

            playerctrl.enabled = false;
            if (!hasPlayedSound)
            {
                AudioSource.PlayClipAtPoint(jumpsc, transform.position);
                hasPlayedSound = true;
            }
        }
        


    }
}

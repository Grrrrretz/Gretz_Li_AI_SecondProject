using UnityEngine;

public class S_Collectible : MonoBehaviour
{
       private bool Collected = false;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (Collected) return;

        if (other.CompareTag("Player"))
        {
            Collected = true;

            S_CollectManager manager = FindFirstObjectByType<S_CollectManager>();
            if (manager != null)
            {
                manager.AddCollect();
            }
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
        }
    }
}


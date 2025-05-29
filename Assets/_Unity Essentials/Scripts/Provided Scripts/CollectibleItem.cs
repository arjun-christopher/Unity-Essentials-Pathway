using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public AudioClip collectSound; // Sound to play when the collectible is collected
    public GameObject collectEffectPrefab; // Prefab for the collectible effect
    private AudioSource audioSource;
    private CollectibleManager collectibleManager;

    void Start()
    {
        // Find the CollectibleManager in the scene
        collectibleManager = FindObjectOfType<CollectibleManager>();

        // Add an AudioSource component if it doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the collectible
        if (other.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            // Play the collect sound
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Instantiate the collectible effect
            if (collectEffectPrefab != null)
            {
                Instantiate(collectEffectPrefab, transform.position, transform.rotation);
            }

            // Notify the manager that the collectible was collected
            collectibleManager.CollectItem();

            // Optionally destroy the collectible item after a delay to allow sound to play and effect to show
            Destroy(gameObject, collectSound.length);
        }
    }
}

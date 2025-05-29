using UnityEngine;

public class DestroyOnApproach : MonoBehaviour
{
    public AudioClip destroySound;  // The sound to play when the object is interacted with
    private AudioSource audioSource;
    private bool isInteracted = false;  // Flag to check if the object has already been interacted with

    void Start()
    {
        // Add or get an AudioSource component
        if (!TryGetComponent(out audioSource))
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // This method is called when another object enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player and if it hasn't already been interacted with
        if (other.CompareTag("Player") && !isInteracted)
        {
            isInteracted = true;  // Set flag to prevent the sound from playing multiple times

            // Ensure the AudioSource is ready and the AudioClip is assigned
            if (audioSource != null && destroySound != null)
            {
                // Play the destroy sound
                audioSource.PlayOneShot(destroySound);

                // Wait for the sound to finish before destroying the object
                Destroy(gameObject, destroySound.length);
            }
            else
            {
                Debug.LogError("AudioSource or AudioClip is missing!");
            }
        }
    }
}

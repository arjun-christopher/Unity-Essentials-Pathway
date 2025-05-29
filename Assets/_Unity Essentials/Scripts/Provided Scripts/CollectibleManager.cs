using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public int totalCollectibles; // Total number of collectibles in the game
    private int collectedCount; // Number of collectibles collected
    public AudioClip collectSound; // Sound to play when a collectible is collected
    public AudioClip winSound; // Sound to play when all collectibles are collected

    private AudioSource audioSource;

    void Start()
    {
        collectedCount = 0; // Initialize the collected count
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource if one doesn't exist
    }

    // Call this method when a collectible is collected
    public void CollectItem()
    {
        collectedCount++;

        // Play collection sound
        PlayCollectSound();

        // Check if all collectibles are collected
        if (collectedCount >= totalCollectibles)
        {
            PlayWinSound();
        }
    }

    private void PlayCollectSound()
    {
        // Play the collect sound
        if (audioSource != null && collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
        }
    }

    private void PlayWinSound()
    {
        // Play win sound effect
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }

        // Add additional win effects here (e.g., UI changes, animations)
        Debug.Log("You Win! All collectibles collected!");
    }
}

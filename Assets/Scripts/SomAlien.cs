using UnityEngine;

public class SomAlien : MonoBehaviour
{
    private AudioSource audioSource;
    private bool jaTocou = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (!jaTocou && (other.CompareTag("Player") || other.CompareTag("MainCamera")))
        {
           
            audioSource.Play();
            
            
            jaTocou = true;
            
            Debug.Log("Alien fez barulho!");
        }
    }
}
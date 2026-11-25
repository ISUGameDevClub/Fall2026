using UnityEditor;
using UnityEngine;

public class WaveOnTrigerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private WaveBehavior WaveScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !WaveScript.getMove()) 
            WaveScript.onSwitch();
    }
}

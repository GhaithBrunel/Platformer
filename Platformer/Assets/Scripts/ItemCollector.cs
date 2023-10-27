using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int kiwis = 0;
    [SerializeField] private TextMeshProUGUI kiwisText;
    [SerializeField]  private AudioSource kiwisAudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            kiwisAudioSource.Play();
            Destroy(collision.gameObject);
            kiwis++;

            kiwisText.text = "Kiwis: " + kiwis;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public AudioSource _audio;
    [SerializeField] TextMeshProUGUI _textmeshpro;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _textmeshpro.text = Score.totalscore.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Energy"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            Score.totalscore++;
            _textmeshpro.text = Score.totalscore.ToString();
        }
    }
}

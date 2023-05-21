using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] private AudioClip _background;

    private PlayerController _player;
    // Start is called before the first frame update

    
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();

        _musicSource.clip = _background;
        _musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null && _player._isGameOver)
        {
            _musicSource.Stop();

        }
    }
}

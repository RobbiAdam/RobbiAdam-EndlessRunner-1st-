using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRB;
    private BoxCollider _playerCollider;
    [SerializeField] Vector3 gravity = new Vector3(0, -60f, 0);
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private bool _isOnGround = true;
    [SerializeField] private bool _isSliding = false;
    public bool _isGameOver = false;
    private Vector3 _initialColliderSize;
    private Vector3 _newColliderSize;
    private Vector3 _initialColliderCenter;
    private Vector3 _newColliderCenter;
    private float _newCenterY = 0.4744583f;
    private float _newSizeY = 0.9551599f;
    private float _slideDuration = 0.5f;
    private float _multiplier = 100f;
    private Animator _playerAnim;
    private AudioSource _playerAudio;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _dirtParticle;



    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravity;
        _playerRB = GetComponent<Rigidbody>();
        _playerCollider = GetComponent<BoxCollider>();

        _initialColliderSize = _playerCollider.size = new Vector3(_playerCollider.size.x, _playerCollider.size.y, _playerCollider.size.z);
        _initialColliderCenter = _playerCollider.center = new Vector3(_playerCollider.center.x, _playerCollider.center.y, _playerCollider.center.z);
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        JumpUp();
        StartSliding();
    }

    void JumpUp()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_isGameOver)
        {

            _playerRB.AddForce(Vector3.up * _jumpForce * _multiplier, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");

            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_jumpSound, 1f);

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Hole"))
        {
            _isGameOver = true;
            _playerCollider.enabled = false;
            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_gameOverSound, 1f);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            _isGameOver = true;
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);

            _dirtParticle.Stop();
            _explosionParticle.Play();
            _playerAudio.PlayOneShot(_crashSound, 1f);
            _playerAudio.PlayOneShot(_gameOverSound, 1f);
        }
    }

    void StartSliding()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isSliding && _isOnGround && !_isGameOver)
        {
            _isSliding = true;

            _newColliderCenter = _playerCollider.size = new Vector3(_playerCollider.center.x, _newCenterY, _playerCollider.center.z);
            _newColliderSize = _playerCollider.size = new Vector3(_playerCollider.size.x, _newSizeY, _playerCollider.size.z);

            _playerCollider.center = _newColliderCenter;
            _playerCollider.size = _newColliderSize;

            _playerAnim.CrossFade("Idles.Idle_SittingOnGround", 0.4f);
            _playerAnim.SetFloat("Speed_f", 0);
            StartCoroutine(StopSliding());
        }
    }
    IEnumerator StopSliding()
    {
        yield return new WaitForSeconds(_slideDuration);
        _playerAnim.SetFloat("Speed_f", 1);
        _playerCollider.size = _initialColliderSize;
        _playerCollider.center = _initialColliderCenter;
        _isSliding = false;
    }
}

using UnityEngine;
using System.Collections;

public class HelicopterCollider : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES
    private AudioSource[] _audioSources;
    private AudioSource _birdSound;
    private AudioSource _missileSound;

    // PUBLIC INSTANCE VARIABLES
    public GameController gameController;

	// Use this for initialization
	void Start () {
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._missileSound = this._audioSources[1];
        this._birdSound = this._audioSources[2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bird"))
        {
            this._birdSound.Play();
            this.gameController.ScoreValue += 10;
        }
        if (other.gameObject.CompareTag("Missile"))
        {
            this._missileSound.Play();
            this.gameController.LivesValue -= 1;
        }

    }

}
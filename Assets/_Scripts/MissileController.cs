using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public float minVerticalSpeed = -2f;
    public float maxVerticalSpeed = 2f;
    public float minHorizontalSpeed = 10f;
    public float maxHorizontalSpeed = 15;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _horizontalSpeed;
    private float _verticalDrift;

    // Use this for initialization
    void Start()
    {
        // Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform>();

        // Reset the Cloud Sprite to the Top
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(this._horizontalSpeed, 0);
        //this._checkBounds();
        this._transform.position = this._currentPosition;

        if (this._currentPosition.x <= -412)
        {
            this.Reset();
        }
    }

    public void Reset()
    {
        this._verticalDrift = Random.Range(this.minVerticalSpeed, this.maxVerticalSpeed);
        //this._horizontalSpeed = Random.Range(this.minHorizontalSpeed, this.maxHorizontalSpeed);
        this._horizontalSpeed = Random.Range(10, 15);
        float yPosition = Random.Range(-218f, 218f);
        //this._checkBounds();
        this._transform.position = new Vector2(412f, yPosition);
        Debug.Log("MISSILE SPEED: " + this._horizontalSpeed);
    }

    private void _checkBounds()
    {
        // check if the plane is going out of bounds and keep it inside window boundary
        if (this._currentPosition.y < -218)
        {
            this._currentPosition.y = -218;
        }

        if (this._currentPosition.y > 218)
        {
            this._currentPosition.y = 218;
        }

        //if (this._currentPosition.x < -270)
        //{
        //    this._currentPosition.x = -270;
        //}

        //if (this._currentPosition.x > 270)
        //{
        //    this._currentPosition.x = 270;
        //}
    }
}

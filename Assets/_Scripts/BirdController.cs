using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public float minVerticalSpeed = -2f;
    public float maxVerticalSpeed = 2f;
    public float minHorizontalSpeed = 5f;
    public float maxHorizontalSpeed = 8f;

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
        this._currentPosition -= new Vector2(this._horizontalSpeed, this._verticalDrift);
        this._checkBounds();
        this._transform.position = this._currentPosition;

        if (this._currentPosition.x <= -345)
        {
            this.Reset();
        }
    }

    public void Reset()
    {
        this._verticalDrift = Random.Range(this.minVerticalSpeed, this.maxVerticalSpeed);
        //this._horizontalSpeed = Random.Range(this.minHorizontalSpeed, this.maxHorizontalSpeed);
        this._horizontalSpeed = Random.Range(5, 8);
        float xPosition = Random.Range(382f, 1600f);
        float yPosition = Random.Range(-225f, 220f);
        this._checkBounds();
        this._transform.position = new Vector2(xPosition, yPosition);
        //Debug.Log("BIRD SPEED: " + this._horizontalSpeed);
    }

    private void _checkBounds()
    {
        // check if the plane is going out of bounds and keep it inside window boundary
        if (this._currentPosition.y < -225)
        {
            this._currentPosition.y = -225;
        }

        if (this._currentPosition.y > 220)
        {
            this._currentPosition.y = 220;
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

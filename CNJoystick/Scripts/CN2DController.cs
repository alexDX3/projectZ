using UnityEngine;
using System.Collections;

public class CN2DController : MonoBehaviour
{
    public CNJoystick movementJoystick;
    public bool irotation = false;
    private Transform transformCache;
    private bool iShoot = false;
    public GameObject Gun;
    public GameObject Shot;
    public float speedgun = 0;
    public float speedshoot = 0;
    // Use this for initialization
    void Awake()
    {
        if (movementJoystick == null)
        {
            throw new UnassignedReferenceException("Please specify movement Joystick object");
        }
        movementJoystick.FingerTouchedEvent += StartMoving;
        movementJoystick.FingerLiftedEvent += StopMoving;
        movementJoystick.JoystickMovedEvent += Move;

        transformCache = transform;
    }

    // You can extend this class and override any of these virtual methods
    protected virtual void Move(Vector3 relativeVector)
    {
        // It's actually 2D vector
        if (!irotation)
        {
            transformCache.position = transformCache.position + relativeVector*Time.deltaTime;
           
        }else FaceMovementDirection(relativeVector);
        transform.up = relativeVector*Time.deltaTime;

    }

    private void FaceMovementDirection(Vector3 direction)
    {
       if(direction.magnitude > 0.9 && !iShoot)
        {
            GameObject testshot = Instantiate(Gun, Shot.transform.position, Shot.transform.rotation) as GameObject;
            testshot.GetComponent<Rigidbody2D>().AddForce(new Vector2(Shot.transform.position.x,Shot.transform.position.y) * speedgun);
            iShoot = true;
            StartCoroutine(wait());
            Debug.Log("isShoot");
        }
    }


    IEnumerator wait() {
        yield return new WaitForSeconds(speedshoot);
        iShoot = false;        
    }
    protected virtual void StopMoving()
    {
        
    }

    protected virtual void StartMoving()
    {

    }

}

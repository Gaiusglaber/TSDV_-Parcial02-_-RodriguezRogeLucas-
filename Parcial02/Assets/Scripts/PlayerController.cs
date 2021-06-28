using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gas=10000f;
    public GameObject explotionPrefab;
    [SerializeField][Range(0, 50)] float speedForce;
    [SerializeField] [Range(0, 50)] float speedRotation;
    public delegate void ZoomCamera(bool isInside);
    public ZoomCamera ZoomAction;
    [SerializeField] [Range(0, 3)] float lerpTime;
    private Camera camera;
    private float boundsZoomCamera=0;
    private float CantZoomCamera = 3;
    private float StartZoomCamera = 5;
    [Range(0,5)]public float Distancex,Distancey;
    private bool canZoom = false;
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        Movement();
        
        Zoom();
    }
    public void Movement()
    {
        if (!GameManager.GetInstance().pause)
        {
            if (Input.GetKey(KeyCode.UpArrow) && gas >= 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.rotation.z, speedForce * Time.deltaTime));
                GetComponentInChildren<Animator>().SetTrigger("Flying");
                gas--;
            }
            else
            {
                GetComponentInChildren<Animator>().ResetTrigger("Flying");
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, speedRotation * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -speedRotation * Time.deltaTime);
            }
        }
    }
    public void ZoomInOut(bool isInside)
    {
        if (isInside&&!canZoom)
        {

            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, CantZoomCamera, lerpTime); //hace zoom
            if (camera.orthographicSize >= CantZoomCamera + 0.5f)
            {
                canZoom = true;
            }
        }
        else if(!isInside && canZoom)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, StartZoomCamera, lerpTime);// hace de-zoom
            if (camera.orthographicSize >= StartZoomCamera - 0.5f)
            {
                canZoom = false;
            }
        }
    }
    public void Zoom()
    {
        if (transform.position.y <= boundsZoomCamera)
        {
            ZoomAction = ZoomInOut;
            ZoomAction(true);
        }
        else if (ZoomAction!=null)
        {
            ZoomAction(false);
        }
    }
    void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(explotionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gas=10000f;
    public LayerMask layerMask;
    public GameObject explotionPrefab;
    [SerializeField][Range(0, 50)] float speedForce;
    [SerializeField] [Range(0, 50)] float speedRotation;
    public delegate void ZoomCamera(bool isInside);
    public ZoomCamera ZoomAction;
    [SerializeField] [Range(0, 3)] float lerpTime;
    private Camera camera;
    private Vector3 CameraInitialPosition;
    [Range(0,5)]public float Distancex,Distancey;
    private bool canZoom = false;
    void Start()
    {
        camera = Camera.main;
        CameraInitialPosition = camera.transform.position;
    }
    void Update()
    {
        Movement();
        
        Zoom();
    }
    public void Movement()
    {
        Vector2 Movement = GetComponent<Rigidbody2D>().velocity;
        if (!GameManager.GetInstance().pause)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
    public void ZoomInOut(bool isInside)
    {
        if (isInside)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, new Vector3(transform.position.x, transform.position.y,camera.transform.position.z), 1);// zoom
            camera.orthographicSize = 5;
            canZoom = true;
        }
        else if(!isInside)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, CameraInitialPosition, 1); //de-zoom
            camera.orthographicSize = 7;
        }
    }
    public void Zoom()
    {
        if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1f,layerMask))
        {
            ZoomAction = ZoomInOut;
            ZoomAction(true);
        }
        else if (ZoomAction != null)
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

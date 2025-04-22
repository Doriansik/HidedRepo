using UnityEngine;

public class FruitNinjaBlade : MonoBehaviour
{
    [SerializeField] private Camera fruitNinjaCamera;

    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    private bool isSlicing;

    public Vector3 direction {  get; private set; }
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;


    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        } else if (Input.GetMouseButtonUp(0)) 
        {
            StopSlicing();
        } else if (isSlicing)
        {
            ContinueSlicing();
        }
    }


    private void StartSlicing()
    {
        Vector3 position = fruitNinjaCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 215f;

        transform.position = position;

        isSlicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }

    private void StopSlicing()
    {
        isSlicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = fruitNinjaCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 215f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }
}

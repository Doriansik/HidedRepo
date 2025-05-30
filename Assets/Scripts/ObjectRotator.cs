using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour
{
    public static ObjectRotator Instance { get; private set; }

    [SerializeField] private string cubeName;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float returnSpeed;

    private bool isBeingInspected = false;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isBeingInspected)
        {
            ObjectRotate();
        }
    }

    private void ObjectRotate()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.Rotate(Vector3.up, -mouseX, Space.World);
            transform.Rotate(Vector3.right, mouseY, Space.World);
        }
    }

    public void StartInspection()
    {
        isBeingInspected = true;
        StopAllCoroutines();
    }

    public void StopInspection()
    {
        isBeingInspected = false;
        StartCoroutine(GoToOriginalTransform());
    }

    private IEnumerator GoToOriginalTransform()
    {
        float countdownToReturn = 0;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        while (countdownToReturn < 1)
        {
            countdownToReturn += Time.deltaTime * returnSpeed;
            transform.position = Vector3.Lerp(startPos, originalPosition, countdownToReturn);
            transform.rotation = Quaternion.Lerp(startRot, originalRotation, countdownToReturn);
            yield return null;
        }
    }
}

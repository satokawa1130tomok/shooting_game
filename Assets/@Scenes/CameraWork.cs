using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{

    #region Private Fielde

    [Tooltip("The distance in the local x-z plane to the target")]
    [SerializeField]

    private float distance = 7.0f;

    [Tooltip("Allow the camera to be offseted vertically from the target, for example giving more view of the sceneray and less ground.")]
    [SerializeField]
    private Vector3 centerOffset = Vector3.zero;

    [Tooltip("The distance in the local x-z plane to the target")]
    [SerializeField]
    private float height = 3.0f;

    [Tooltip("The distance in the local x-z plane to the target")]
    [SerializeField]
    private bool followOnstart = false;

    [Tooltip("The distance in the local x-z plane to the target")]
    [SerializeField]
    private float smoothSeed = 0.125f;

    Transform cameraTransform;

    bool isFollwing;

    Vector3 cameraOffset = Vector3.zero;

    #endregion




    // Start is called before the first frame update
    void Start()
    {
        if (followOnstart)
        {
            OnStartFollowing();
        }
    }

    private void LateUpdate()
    {
        if (cameraTransform == null && isFollwing)
        {
            OnStartFollowing();
        }

        if (isFollwing)
        {
            Follow();
        }
    }

    // Update is called once per frame
    public void OnStartFollowing()
    {
        cameraTransform = Camera.main.transform;
        isFollwing = true;

        Cut();

    }
    
    void Follow()
    {
        cameraOffset.z = -distance;
        cameraOffset.y = height;


        cameraTransform.position = Vector3.Lerp(cameraTransform.position, this.transform.position + this.transform.TransformVector(cameraOffset), smoothSeed * Time.deltaTime);
        cameraTransform.LookAt(this.transform.position + centerOffset);
    }

    void Cut()
    {
        cameraOffset.z = -distance;
        cameraOffset.y = height;

        cameraTransform.position = this.transform.position + this.transform.TransformVector(cameraOffset);

        cameraTransform.LookAt(this.transform.position + centerOffset);
    }
}

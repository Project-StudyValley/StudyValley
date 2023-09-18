using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치

    public bool trigger = false;

    [SerializeField]
    private float moveHorizonMax;
    [SerializeField] 
    private float moveHorizonMin;
    [SerializeField] 
    private float moveVertiMax;
    [SerializeField] 
    private float moveVertiMin;


    private void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);

            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // 대상이 있는지 체크
        if (target.gameObject != null)
        {
            if (trigger)
            {
                // target은 플레이어를 의미 (z값은 카메라값을 그대로 유지)
                targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

                targetPosition = ClampCamera(targetPosition);

                // vectorA -> B까지 T의 속도로 이동
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    public Vector3 ClampCamera(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, moveHorizonMin, moveHorizonMax);   
        position.y = Mathf.Clamp(position.y, moveVertiMin, moveVertiMax); 
        return position;
    }
}


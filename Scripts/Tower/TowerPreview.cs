using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPreview : MonoBehaviour
{
    private MeshFilter mesh;


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel");

        if (zoomAmount > 0f)
            OnScrollUp();
        else if (zoomAmount < 0f)
            OnScrollDown();
    }

    private void OnScrollUp()
    {
        Vector3 currentRotation = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z - 90);
    }

    private void OnScrollDown()
    {
        Vector3 currentRotation = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + 90);
    }

    public void InitializeTowerPreview(TowerDetailsSO towerData) // 타워 초기화
    {
        mesh.mesh = towerData.towerMesh;
    }


}

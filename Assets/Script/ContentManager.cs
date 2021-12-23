using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    public Toggle BirdToggle;
    public GameObject MamaBirdPrefab;
    public GameObject BabyBirdPrefab;
    private GameObject SpawnBird;
    public Camera ARCamera;

    private List<RaycastResult> raycastResults = new List<RaycastResult>();
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Basýldi");

            Ray ray  = ARCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);

            if (IsPointerOverUI(Input.mousePosition))//EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Biþey yapmadý");
            }
            else
            {
                SpawnBird = Instantiate(WhichBird(), ray.origin, Quaternion.identity);
                SpawnBird.GetComponent<Rigidbody>().AddForce(ray.direction * 100);
            }
        }

      
    }
    public GameObject WhichBird()
    {
        if (BirdToggle.isOn)
        {
            return MamaBirdPrefab;
        }
        else
        {
            return BabyBirdPrefab;
        }
    }
    private bool IsPointerOverUI(Vector2 fingerPosition)
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;
        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        return raycastResults.Count > 0; // if greater then zero  we hit  a UI element
    }
}

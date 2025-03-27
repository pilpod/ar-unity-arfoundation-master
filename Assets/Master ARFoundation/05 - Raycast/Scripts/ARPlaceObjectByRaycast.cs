using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlaceObjectByRaycast : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;

    private ARRaycastManager _raycastManager;
    private ARPlaneManager _planeManager;
    private List<ARRaycastHit> _hits;

    private GameObject _objectPlaced;
    private Vector2 _middlePointScreen;
    private bool _isPlaced;

    private void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
        _planeManager = GetComponent<ARPlaneManager>();
    }

    private void Start()
    {
        _hits = new List<ARRaycastHit>();

        _middlePointScreen = new Vector2(Screen.width / 2, Screen.height / 2);

        _objectPlaced = Instantiate(_objectPrefab.gameObject);
        _objectPlaced.SetActive(false);
    }

    private void Update()
    {
        if ( Input.touchCount > 0)
        {
            // Get the first touch
            Touch touchOne = Input.GetTouch(0);

            // Touch phase should be Began and not over UI
            if (touchOne.phase == TouchPhase.Began && !IsTouchOverUI(touchOne.position))
            {
                ActionPlace(touchOne.position);
            }

        }
    }

    public void ActionPlane()
    {
        ActionPlace(_middlePointScreen);
    }

    private void ActionPlace(Vector2 placePosition)
    {
        if (_isPlaced) return;

        _raycastManager.Raycast(placePosition, _hits, TrackableType.Planes);

        if (_hits.Count > 0)
        {
            _objectPlaced.transform.position = _hits[0].pose.position;
            _objectPlaced.transform.rotation = GetWallRotation(_hits[0]);
            _objectPlaced.SetActive(true);

            _isPlaced = true;
        }
    }

    // La función GetWallRotation calcula la rotación necesaria para colocar un objeto en una pared detectada por un raycast en AR
    private Quaternion GetWallRotation(ARRaycastHit hit)
    {

        ARPlane planeHit = _planeManager.GetPlane(hit.trackableId);
        Vector3 forward = hit.pose.position - (hit.pose.position + Vector3.down);

        return Quaternion.LookRotation(forward, planeHit.normal);
    }

    public void ActionRemove()
    {
        if (!_isPlaced) return;

        _objectPlaced.SetActive(false);
        _isPlaced = false;
    }

    private bool IsTouchOverUI(Vector2 touchPosition)
    {
        /*
         este código verifica si un toque en la pantalla está sobre un elemento de la interfaz de usuario y devuelve true si es así, o false en caso contrario.
         */
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = touchPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}

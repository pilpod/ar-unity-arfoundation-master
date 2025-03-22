using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaceObjectBySize : MonoBehaviour
{
    // variable para medir el tamaño del objecto
    [SerializeField] private MeshRenderer _objectSize;
    // objecto que vamos a colocar
    [SerializeField] private GameObject _objectPrefab;

    private ARPlaneManager _planeManager;
    private List<ARPlane> _listPlanes;
    private GameObject _objectPlaced;

    private void Awake()
    {
        // inicialización de las propiedades
        _planeManager = GetComponent<ARPlaneManager>();
        _listPlanes = new List<ARPlane>();
    }

    private void OnEnable()
    {
        _planeManager.planesChanged += PlanesFound;
    }

    private void OnDisable()
    {
        _planeManager.planesChanged -= PlanesFound;
    }

    private void PlanesFound(ARPlanesChangedEventArgs eventData)
    {
        // Cuando se detecta un plano se agrega a la lista
        if (eventData.added != null && eventData.added.Count > 0)
        {
            _listPlanes.AddRange(eventData.added);
        }

        // recoremos los planos uno por uno
        foreach (var plane in _listPlanes)
        {
            // comprobamos el tamaño en función del objecto
            if (CompareSizeWithObject(plane) && _objectPlaced == null)
            {
                // colocación del objeto
                _objectPlaced = Instantiate(_objectPrefab.gameObject);
                _objectPlaced.transform.position = plane.center;
                _objectPlaced.transform.up = plane.normal;
            }

            StopPlaneDetection(plane);
        }
    }

    private bool CompareSizeWithObject(ARPlane plane)
    {
        return plane.extents.x > _objectSize.bounds.size.x && plane.extents.y > _objectSize.bounds.size.z;
    }
    private void StopPlaneDetection(ARPlane planeException)
    {
        StopPlaneDectection();

        foreach (var plane in _listPlanes)
        {
            if (plane == planeException)
            {
                plane.gameObject.SetActive(true);
            }
        }
    }

    private void StopPlaneDectection()
    {
        _planeManager.requestedDetectionMode = PlaneDetectionMode.None;

        foreach (var plane in _listPlanes)
        {
            plane.gameObject.SetActive(false);
        }
    }

}

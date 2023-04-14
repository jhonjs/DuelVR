using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private BoxCollider _collider;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _collider.GetComponent<BoxCollider>();
        _meshRenderer.GetComponent<MeshRenderer>();
    }

    public void onShow()
    {
        _collider.enabled = true;
        _meshRenderer.enabled = true;
        target.SetActive(true);
    }

    public void onHide()
    {
        _collider.enabled = false;
        _meshRenderer.enabled = false;
        target.SetActive(false);
    }
}

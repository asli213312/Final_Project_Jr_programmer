using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private string _vehicleName;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _explosionParticle;
    
    // ENCAPSULATION
    public string VehicleName { get => _vehicleName; protected set => _vehicleName = value; }
    public float Speed { get => _speed; protected set => _speed = value; }
    public GameObject ExplosionParticle { get => _explosionParticle; protected set => _explosionParticle = value; }

    private bool _isEventRunning;

    protected virtual void Move()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        GameManager.Instance.SetText("VehicleMoving!");
    }

    private void Update()
    {
        CheckOnClick();
    }

    private void CheckOnClick()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (!Physics.Raycast(ray, out RaycastHit hit) || hit.transform == null || hit.transform.gameObject != gameObject) 
            return;
        
        OnClick();
    }

    private void OnClick()
    {
        Move();
    }

    protected void TranslateDirection(Vector3 direction, float speed)
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    
    protected IEnumerator EventParticle()
    {
        _isEventRunning = true;
        Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(999);
        _isEventRunning = false;
    } 
}

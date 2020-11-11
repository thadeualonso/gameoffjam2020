using UnityEngine;
using UnityEngine.Events;

public class LookAtMouseBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask _floorMask;
    [SerializeField] float _mouseMinDistance;
    [SerializeField] UnityEvent OnClickMouseButton;

    void Update()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit, 100f, _floorMask))
        {
            Vector3 playerToMouse = hit.point;
            playerToMouse.y = 0f;

            if(Vector3.Distance(hit.point, transform.position) > _mouseMinDistance)
                transform.LookAt(playerToMouse, Vector3.up);

            if(Input.GetMouseButton(0))
            {
                OnClickMouseButton?.Invoke();
            }
        }
    }
}
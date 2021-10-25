using UnityEngine;

public class PlayerShootingQL : MonoBehaviour
{
    public ProjectileQL projectilePrefab;
    public LayerMask mask;

    void shoot(RaycastHit hit)
    {
        var projectile = Instantiate(projectilePrefab).GetComponent<ProjectileQL>();
        var pointAboveFloor = hit.point + new Vector3(0, 0, this.transform.position.z);
        var direction = pointAboveFloor - transform.position;
        var shootRay = new Ray(this.transform.position, direction);
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
        projectile.FireProjectile(shootRay);
    }

    void raycastOnMouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(this.transform.position, Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            shoot(hit);
            Debug.Log("shooting");
        }
    }

    private void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            raycastOnMouseClick();
        }
    }
}

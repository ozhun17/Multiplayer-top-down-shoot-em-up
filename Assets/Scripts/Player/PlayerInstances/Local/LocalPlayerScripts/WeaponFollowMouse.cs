using UnityEngine;

namespace Player.PlayerInstances.Local.LocalPlayerScripts
{
    public class WeaponFollowMouse : MonoBehaviour
    {
        private GameObject _center;
        private Camera _main;
        private void Awake()
        {
            if(Camera.main is null){Destroy(this);}
            _main = Camera.main;
            _center = transform.Find("Center").gameObject;
        }

        private void Update()
        {
            WeaponLookAtMouse();
        }

        private void WeaponLookAtMouse()
        {
            var dir = Input.mousePosition - _main.WorldToScreenPoint(_center.transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
            _center.transform.rotation = angleAxis;
        }

    }
}
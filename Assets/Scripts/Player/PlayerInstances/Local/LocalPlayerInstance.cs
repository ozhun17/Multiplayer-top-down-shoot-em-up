using InputSystem;
using Interfaces;
using Player.PlayerInstances.Local.LocalPlayerScripts;
using Player.PlayerInstances.Local.LocalPlayerScripts.LeftClickActions;

namespace Player.PlayerInstances.Local
{
    public class LocalPlayerInstance: PlayerInstance
    {
        private WeaponFollowMouse _weaponFollow;
        private LeftClickListener _leftClickListener;
        private IAction _leftClickAction;
        internal override void Initialize()
        {
            PlayerInput = this.gameObject.AddComponent<TempInput>();
            PlayerMovement = this.gameObject.AddComponent<PlayerMovement>();
            _weaponFollow = this.gameObject.AddComponent<WeaponFollowMouse>();
            _leftClickListener = this.gameObject.AddComponent<LeftClickListener>();
            _leftClickAction = this.gameObject.AddComponent<FireBulletLca>();
            
            _leftClickListener.InsertAction(_leftClickAction);
            base.Initialize();
        }
    }
}
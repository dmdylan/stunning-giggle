using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineStuff
{
    //TODO: Make sure jumping doesn't change out of reloading state
    //TODO: Change ability to ADS when reloading?
    public class PlayerReloadingState : PlayerBaseState
    {
        private bool isDoneReloading = false;
        private bool canceledReload = false;
        private bool stillPressingFire = false;
        private Task reloading;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken reloadCanceled;

        public PlayerReloadingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
            cancellationTokenSource = new CancellationTokenSource();
            reloadCanceled = cancellationTokenSource.Token;
        }

        public override void CheckSwitchStates()
        {
            if (canceledReload || isDoneReloading)
                SwitchState(CurrentSubState);
            else if (Ctx.Input.IsSprinting)
                SwitchState(Factory.Running());
        }

        public override void EnterState()
        {
            //reloading = Reloading(Ctx.GemController.CurrentWeapon.GemStats.RechargeTime, reloadCanceled);
            //if (Ctx.Input.IsShooting)
            //    stillPressingFire = true;
        }

        public override void ExitState()
        {

        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
                SetSubState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SetSubState(Factory.Walking());
        }

        public override void UpdateState()
        {
            //if(Ctx.Input.DidCancel || (Ctx.Input.IsShooting && stillPressingFire == false))
            //{
            //    canceledReload = true;
            //    cancellationTokenSource.Cancel();
            //}

            CheckSwitchStates();
        }

        async Task Reloading(float reloadTime, CancellationToken token)
        {
            await Task.Delay(TimeSpan.FromSeconds(reloadTime), token);
            isDoneReloading = true;
            //Ctx.GemController.CurrentWeapon.SetCurrentEneryToMaxEnergy();
            reloading.Dispose();
        }
    }
}
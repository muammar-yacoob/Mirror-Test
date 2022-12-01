using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerAuthority : NetworkBehaviour
{
        [SerializeField] private GameObject crown;

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            SwitchAuthority(authority);
        }

        private void Update()
        {
            if (crown == null) return;

            if (Input.GetKeyDown(KeyCode.Alpha1))
                SwitchAuthority(!isOwned);
        }
        
        private void SwitchAuthority(bool state)
        {
            //if(isOwned) identity.AssignClientAuthority(conn);;
            //else Object.ReleaseStateAuthority();
            
            crown.SetActive(isOwned);
            print($"Has State: {isOwned}");
        }
    }

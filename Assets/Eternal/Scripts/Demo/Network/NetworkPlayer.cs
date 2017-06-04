//using UnityEngine;
//using System.Collections;
//using UnityEngine.Networking;
//using UnityStandardAssets.Characters.FirstPerson;

//public class NetworkPlayer : NetworkBehaviour
//{
//    [SerializeField]
//	private Camera _camera;
//	[SerializeField]
//	private AudioListener _audioListener;
//    [SerializeField]
//    private FirstPersonController _fpsController;

//    // Use this for initialization
//    public override void OnStartLocalPlayer ()
//	{
//		_camera.enabled = true;
//		_audioListener.enabled = true;
//		_fpsController.enabled = true;
//	}

//	void Update()
//	{
//		if(!isLocalPlayer)
//			return;

//		if(!_fpsController.enabled)
//			return;
		
//		if(Input.GetButtonDown("Fire2")){
//			CmdHandlePlayerHit(gameObject);
//		}

//		if(Input.GetButtonDown("Fire1")){
//			RaycastHit hit;

//			var ray = _camera.transform.position + (1f * _camera.transform.forward);

//			if(Physics.Raycast(ray, _camera.transform.forward, out hit, 1000f)){
//				if(hit.transform.CompareTag("Player")){
//					CmdHandlePlayerHit(hit.transform.gameObject);
//				}
//			}
//		}
//	}

//	private void ChangeVisualState(bool enable)
//	{
//		var renders = GetComponentsInChildren<Renderer>();

//		foreach (var item in renders) {
//			item.enabled = enable;
//		}
//	}

//	private void ChangeControl(bool enable)
//	{
//		_fpsController.enabled = enable;
//		_camera.enabled = enable;
//	}

//	[Command]
//	private void CmdHandlePlayerHit(GameObject obj){
//		var player = obj.GetComponent<NetworkPlayer>();

//		player.RpcOnPlayerHit(gameObject);
//	}

//	[ClientRpc]
//	public void RpcOnPlayerHit(GameObject obj)
//	{
//		var who = obj.GetComponent<NetworkPlayer>();

//		ChangeVisualState(false);

//		if(isLocalPlayer)
//		{
//			ChangeControl(false);

//			var net = NetworkManager.singleton as MyNetworkManager;

//			var point = net.GetRandomPosition();

//			transform.position = point;
//		}

//		Invoke("Respawn", 1);
//	}

//	private void Respawn()
//	{
//		if(isLocalPlayer){
//			ChangeControl(true);
//		}

//		ChangeVisualState(true);
//	}
//}

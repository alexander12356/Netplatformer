using UnityEngine;
using UnityEngine.Networking;

public class SwordsmenNetwork : NetworkBehaviour
{
    private SwordsmenCharacter _swordsmenCharacter;

    [SerializeField]
    private FollowCamera FollowCameraPrefab;

    public void Awake()
    {
        _swordsmenCharacter = GetComponent<SwordsmenCharacter>();
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<SwordsmenCharacter>().enabled = true;

        var followCamera = Instantiate(FollowCameraPrefab);
        followCamera.target = transform;
    }

    public void PlayAnimation(string animationName)
    {
        CmdPlayAnimation(animationName);
    }

    [Command]
    private void CmdPlayAnimation(string animation)
    {
        RpcPlayAnimation(animation);
    }

    [ClientRpc]
    private void RpcPlayAnimation(string animation)
    {
    }

    public void StopAnimation(string animationName)
    {
        CmdStopAnimation(animationName);
    }

    [Command]
    private void CmdStopAnimation(string animation)
    {
        RpcStopAnimation(animation);
    }

    [ClientRpc]
    private void RpcStopAnimation(string animation)
    {
    }

    public void Flip(bool value)
    {
        CmdFlip(value);
    }

    [Command]
    public void CmdFlip(bool value)
    {
        RpcFlip(value);
    }

    [ClientRpc]
    public void RpcFlip(bool value)
    {
        _swordsmenCharacter.ChangeFlip(value);
    }
}

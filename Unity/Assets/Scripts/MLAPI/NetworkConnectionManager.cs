using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;

public class NetworkConnectionManager : MonoBehaviour
{
    public string ipAdress = "127.0.0.1";//Defaults to Netcode local host
    UNetTransport transportObj;

    //Server only!!!
    public void Host()
    {
        //NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;//Local multiplayer only
        NetworkManager.Singleton.StartHost();
    }
    //Server only!!!
    private void ApprovalCheck(byte[] connectionData, ulong clientId, NetworkManager.ConnectionApprovedDelegate callback)
    {
        //Check the incoming data!!!
        bool allowThisConnection = System.Text.Encoding.ASCII.GetString(connectionData) == "SuperSecurePassword";
        callback(true, null, allowThisConnection, RandomSpawn(), Quaternion.identity);
    }

    public void Client()
    {
        NetworkManager.Singleton.StartClient();
        //Join();//Local multiplayer only
    }


    public void Join()
    {
        transportObj = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transportObj.ConnectAddress = ipAdress;
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("SuperSecurePassword");
        NetworkManager.Singleton.StartClient();
    }

    public void IPAdressChanged(string newIPAdress)
    {
        ipAdress = newIPAdress;
    }

    public Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
    }
}

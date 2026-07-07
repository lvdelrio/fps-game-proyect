using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using Fusion;
using Fusion.Sockets;
using System;
using System.Linq;
using System.Threading.Tasks;



public class networkRunner : MonoBehaviour
{
    public NetworkRunner networkRunnerePrefab;
    NetworkRunner networkRunnerprefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        networkRunnerprefab = Instantiate(networkRunnerePrefab);
        networkRunnerprefab.name = "Network Runner";

    }

    protected virtual Task InitializeNetworkRunner( NetworkRunner runner, GameMode gameMode, GameMode gamemode, SceneRef scene, Action<NetworkRunner> initialized)
    {
        var sceneManager = runner.GetComponent(typeof(MonoBehaviour)).ofType<INetworkSceneManager>().FirstOrDefault();
    }

}

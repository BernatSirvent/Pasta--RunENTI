using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int MaxPlayers = 4;
    
    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Singelton - Trying to create another instance of singelton!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public void SetPlayerPrefab(int index, GameObject prefab)
    {
        playerConfigs[index].Prefab = prefab;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].IsReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void HandlePlayerJoinder(PlayerInput pi)
    {
        Debug.Log("PlayerJoined" + pi.playerIndex);
        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }
}



public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    public Material PlayerMaterial { get; set; }
    public GameObject Prefab { get; set; }
    public Animator PlayerAnimator { get; set; }

}

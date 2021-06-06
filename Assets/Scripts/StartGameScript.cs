using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StartGameScript : MonoBehaviour
{
    public Button StartGameButton; 
    public GameObject NetworkManagerObject; 


    // Start is called before the first frame update
    void Start()
    {
        // PhotonNetwork.ConnectUsingSettings("v01"); //
        StartGameButton.onClick.AddListener(startGameFunc); 
    }

    // Update is called once per frame
    // void Update()
    // {
    //   TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString();
    // }

    void startGameFunc()
    {
        StartGameButton.gameObject.SetActive(false); 
        NetworkManagerObject.SetActive(true); 
    }
}

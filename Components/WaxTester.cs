using EosSharp;
using EosSharp.Core;
using EosSharp.Core.Providers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxTester : MonoBehaviour
{

    public const string  waxEndpoint = "http://testnet-wax.3dkrender.com";
    public const string privateKey= "5JkvbZnPFommzVUyiiYMz2vCr49toJeJiUxaa58MC7txNvQseEo";
    public string mainChainID="";

    Eos eosMainNet = new Eos(new EosConfigurator()
    {
        HttpEndpoint = "http://testnet-wax.3dkrender.com", //Mainnet   
        ChainId = "",
        ExpireSeconds = 60,
        SignProvider = new DefaultSignProvider(privateKey)
    });

#if UNITY_EDITOR
    [EasyButtons.Button]
#endif
    public async void getChainInfo()
    {
        eosMainNet = new Eos(new EosConfigurator()
        {
            HttpEndpoint = waxEndpoint, //Mainnet   
            ChainId = mainChainID,
            ExpireSeconds = 60,
            SignProvider = new DefaultSignProvider(privateKey)
        });

        var NetInfoResponse = await eosMainNet.GetInfo();

        mainChainID = NetInfoResponse.chain_id;
        
        Debug.Log("Main Net Server Version: " + NetInfoResponse.server_version + " ChainID :" + NetInfoResponse.chain_id);


    }


}

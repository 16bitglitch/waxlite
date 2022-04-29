using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using EosSharp.Core.Api.v1;
using EosSharp.Unity3D;

namespace waxlite
{
    public class waxcore
    {
        Eos endPoint;

        public static async Task<GetInfoResponse> GetInfo(Eos EndPoint)
        {
            return await EndPoint.GetInfo();
        }

        public async Task<string> GetChainId(Eos EndPoint)
        {
            var result = await EndPoint.GetInfo();
            if (result == null) { return null; }
            else
            {
                return result.chain_id;
            }
        }

        public static async Task<string> GetServerVersion(Eos EndPoint)
        {
            var result = await EndPoint.GetInfo();
            if (result == null) { return null; }
            else
            {
                return result.server_version;
            }
        }

    }

}

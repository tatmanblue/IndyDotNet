﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndyDotNet.Utils;
using IndyDotNet.Pool;
using Tests.Utils;
using System.Collections.Generic;

namespace Tests.PoolTests
{
    [TestClass]
    public class GenesisTransactionSerializationTests
    {
        [TestMethod]
        public void SingleTransactionGeneratedCorrectly()
        {
            GenesisTransaction genesisTransaction = PoolUtils.GetNode1GenesisTransaction();

            string json = genesisTransaction.ToJson(false);
            string expected = string.Format("{{\"reqSignature\":{{}},\"txn\":{{\"data\":{{\"data\":{{\"alias\":\"Node1\",\"blskey\":\"4N8aUNHSgjQVgkpm8nhNEfDf6txHznoYREg9kirmJrkivgL4oSEimFF6nsQ6M41QvhM2Z33nves5vfSn9n1UwNFJBYtWVnHYMATn76vLuL3zU88KyeAYcHfsih3He6UHcXDxcaecHVz6jhCYz1P2UZn2bDVruL5wXpehgBfBaLKm3Ba\",\"blskey_pop\":\"RahHYiCvoNCtPTrVtP7nMC5eTYrsUA8WjXbdhNc8debh1agE9bGiJxWBXYNFbnJXoXhWFMvyqhqhRoq737YQemH5ik9oL7R4NTTCz2LEZhkgLJzB3QRQqJyBNyv7acbdHrAT8nQ9UkLbaVL9NBpnWXBTw4LEMePaSHEw66RzPNdAX1\",\"client_ip\":\"{0}\",\"client_port\":9702,\"node_ip\":\"{1}\",\"node_port\":9701,\"services\":[\"VALIDATOR\"]}},\"dest\":\"Gw6pDLhcBcoQesN72qfotTgFa7cbuqZpkX3Xo6pLhPhv\"}},\"metadata\":{{\"from\":\"Th7MpTaRZVRYnPiabds81Y\"}},\"type\":\"0\"}},\"txnMetadata\":{{\"seqNo\":1,\"txnId\":\"fea82e10e894419fe2bea7d96296a6d46f50f93f9eeda954ec461b2ed2950b62\"}},\"ver\":\"1\"}}", "127.0.0.1", "127.0.0.1");

            Assert.AreEqual(expected, json, "json not as expected");

        }

    }
}

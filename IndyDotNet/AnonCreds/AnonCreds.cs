﻿using System;
using IndyDotNet.Did;
using IndyDotNet.Utils;
using IndyDotNet.Wallet;
using Newtonsoft.Json;

namespace IndyDotNet.AnonCreds
{
    internal class IssuerAnonCreds : IIssuerAnonCreds
    {
        internal IssuerAnonCreds() {}

        public Credential CreateStoreCredentialDef(IWallet wallet, IDid issuerDid, CredentialDefinition definition)
        {
            string schemaJson = definition.ToJson();
            string tag = definition.Tag;
            string configJson = definition.Config.ToJson();
            string signatureType = definition.SignatureType;

            Logger.Info($"     schemaJson = {schemaJson}");
            Logger.Info($"     configJson = {configJson}");
            Logger.Info($"     tag = {tag}");
            Logger.Info($"     signatureType = {signatureType}");

            IssuerCreateAndStoreCredentialDefResult result = AnonCredsAsync.IssuerCreateAndStoreCredentialDefAsync(wallet, issuerDid, schemaJson, tag, signatureType, configJson).Result;

            return JsonConvert.DeserializeObject<Credential>(result.CredDefJson);
        }
    }
}

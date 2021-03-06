﻿using System;
using Newtonsoft.Json;

namespace IndyDotNet.Wallet
{
    public class WalletConfig
    {
        public string Id { get; set; }
        public string StorageType { get; set; } = "default";
        public WalletStorageConfig StorageConfig { get; set; }

    }

    public class WalletStorageConfig
    {
        public string Path { get; set; } = String.Empty;
    }
}

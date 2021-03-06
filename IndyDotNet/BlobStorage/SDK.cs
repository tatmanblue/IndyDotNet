﻿using System;
using System.Runtime.InteropServices;

namespace IndyDotNet.BlobStorage
{
    internal static class NativeMethods
    {
        internal delegate void BlobStorageCompletedDelegate(int xcommand_handle, int err, int handle);

        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_open_blob_storage_reader(int command_handle, string type_, string config_json, BlobStorageCompletedDelegate cb);

        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_open_blob_storage_writer(int command_handle, string type_, string config_json, BlobStorageCompletedDelegate cb);
    }
}

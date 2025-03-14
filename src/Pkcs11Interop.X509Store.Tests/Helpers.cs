﻿/*
 *  Copyright 2017-2021 The Pkcs11Interop Project
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

/*
 *  Written for the Pkcs11Interop project by:
 *  Jaroslav IMRICH <jimrich@jimrich.sk>
 */

using System.Linq;
using System.Security.Cryptography;

namespace Net.Pkcs11Interop.X509Store.Tests
{
    /// <summary>
    /// Helper methods for tests
    /// </summary>
    public static class Helpers
    {
        public static Pkcs11X509Certificate GetCertificate(Pkcs11X509Store store, string tokenLabel, string certLabel)
        {
            Pkcs11Token token = store.Slots.FirstOrDefault(p => p.Token.Info.Label == tokenLabel)?.Token;
            return token?.Certificates.FirstOrDefault(p => p.Info.Label == certLabel);
        }

        public static byte[] ComputeHash(byte[] data, HashAlgorithmName hashAlgName)
        {
            using (HashAlgorithm hashAlg = HashAlgorithm.Create(hashAlgName.Name))
                return hashAlg.ComputeHash(data);
        }
    }
}

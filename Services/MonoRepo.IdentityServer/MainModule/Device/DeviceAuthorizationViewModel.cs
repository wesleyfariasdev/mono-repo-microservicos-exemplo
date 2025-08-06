// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.



// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using MonoRepo.IdentityServer.MainModule.Consent;

namespace MonoRepo.IdentityServer.MainModule.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.IdentityModel.TestUtils;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Json.Tests;


namespace Microsoft.IdentityModel.Protocols.OpenIdConnect.Tests
{
    /// <summary>
    /// This configuration data is used to test that loading metadata from a json string has expected values.
    /// jsonstrings are defined and objects are created then tests use them to ensure they are the same.
    /// </summary>
    public class OpenIdConfigData
    {
        public static OpenIdConnectConfiguration FullyPopulated = new OpenIdConnectConfiguration();

        public static OpenIdConnectConfiguration FullyPopulatedWithKeys
        {
            get
            {
                var config = Default;
                config.JsonWebKeySet = DataSets.JsonWebKeySet1;
                config.AdditionalData["microsoft_multi_refresh_token"] = true;
                config.SigningKeys.Add(KeyingMaterial.RsaSecurityKey1);
                config.SigningKeys.Add(KeyingMaterial.RsaSecurityKey2);
                config.SigningKeys.Add(KeyingMaterial.X509SecurityKey1);
                config.SigningKeys.Add(KeyingMaterial.X509SecurityKey2);
                return config;
            }
        }

        public static OpenIdConnectConfiguration PingLabs = new OpenIdConnectConfiguration();
        public static OpenIdConnectConfiguration SingleX509Data = new OpenIdConnectConfiguration();
        public static string AADCommonUrl = "https://login.windows.net/common/.well-known/openid-configuration";
        public static string AADCommonUrlV1 = "https://login.microsoftonline.com/common/.well-known/openid-configuration";
        public static string AADCommonUrlV2 = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration";
        public static string AccountsGoogle = "https://accounts.google.com/.well-known/openid-configuration";
        public static string BadUri = "_____NoSuchfile____";
        public static string HttpsBadUri = "https://_____NoSuchfile____";

        #region Configuration Strings
        public static string OpenIdConnectMetadataPingString = @"{""authorization_endpoint"":""https:\/\/connect-interop.pinglabs.org:9031\/as\/authorization.oauth2"",
                                                                  ""issuer"":""https:\/\/connect-interop.pinglabs.org:9031"",
                                                                  ""id_token_signing_alg_values_supported"":[""none"",""HS256"",""HS384"",""HS512"",""RS256"",""RS384"",""RS512"",""ES256"",""ES384"",""ES512""],
                                                                  ""claim_types_supported"":[""normal""],
                                                                  ""claims_parameter_supported"":false,
                                                                  ""ping_end_session_endpoint"":""https:\/\/connect-interop.pinglabs.org:9031\/idp\/startSLO.ping"",
                                                                  ""ping_revoked_sris_endpoint"":""https:\/\/connect-interop.pinglabs.org:9031\/pf-ws\/rest\/sessionMgmt\/revokedSris"",
                                                                  ""request_parameter_supported"":false,
                                                                  ""request_uri_parameter_supported"":false,
                                                                  ""response_modes_supported"":[""fragment"",""query"",""form_post""],
                                                                  ""response_types_supported"":[""code"",""token"",""id_token"",""code token"",""code id_token"",""token id_token"",""code token id_token""],
                                                                  ""revocation_endpoint"":""https:\/\/connect-interop.pinglabs.org:9031\/as\/revoke_token.oauth2"",
                                                                  ""scopes_supported"":[""phone"",""address"",""email"",""openid"",""profile""],
                                                                  ""subject_types_supported"":[""public""],
                                                                  ""token_endpoint"":""https:\/\/connect-interop.pinglabs.org:9031\/as\/token.oauth2"",
                                                                  ""token_endpoint_auth_methods_supported"":[""client_secret_basic"",""client_secret_post""],
                                                                  ""userinfo_endpoint"":""https:\/\/connect-interop.pinglabs.org:9031\/idp\/userinfo.openid"",
                                                                  ""version"":""3.0""}";

        public static string JsonFile = @"OpenIdConnectMetadata.json";
        public static string OpenIdConnectMetadataFileEnd2End = @"OpenIdConnectMetadataEnd2End.json";
        public static string OpenIdConnectMetadataFileEnd2EndEC = @"OpenIdConnectMetadataEnd2EndEC.json";
        public static string JsonWebKeySetBadUriFile = @"OpenIdConnectMetadataJsonWebKeySetBadUri.json";
        public static string JsonAllValues =
                                            @"{ ""acr_values_supported"" : [""acr_value1"", ""acr_value2"", ""acr_value3""],
                                                ""authorization_endpoint"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize"",
                                                ""frontchannel_logout_session_supported"": ""true"",
                                                ""frontchannel_logout_supported"": ""true"",
                                                ""check_session_iframe"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession"",
                                                ""claims_locales_supported"" : [ ""claim_local1"", ""claim_local2"", ""claim_local3"" ],
                                                ""claims_parameter_supported"" : true,
                                                ""claims_supported"": [ ""sub"", ""iss"", ""aud"", ""exp"", ""iat"", ""auth_time"", ""acr"", ""amr"", ""nonce"", ""email"", ""given_name"", ""family_name"", ""nickname"" ],
                                                ""claim_types_supported"" : [ ""Normal Claims"", ""Aggregated Claims"", ""Distributed Claims"" ],
                                                ""display_values_supported"" : [ ""displayValue1"", ""displayValue2"", ""displayValue3"" ],
                                                ""end_session_endpoint"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout"",
                                                ""grant_types_supported"" : [""authorization_code"",""implicit""],
                                                ""http_logout_supported"" : true,
                                                ""id_token_encryption_alg_values_supported"" : [""RSA1_5"", ""A256KW""],
                                                ""id_token_encryption_enc_values_supported"" : [""A128CBC-HS256"",""A256CBC-HS512""],
                                                ""id_token_signing_alg_values_supported"" : [""RS256""],
                                                ""introspection_endpoint"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/introspect"",
                                                ""introspection_endpoint_auth_methods_supported"" : [""client_secret_post"",""private_key_jwt""],
                                                ""introspection_endpoint_auth_signing_alg_values_supported"" : [""ES192"", ""ES256""],
                                                ""issuer"" : ""https://sts.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/"",
                                                ""jwks_uri"" : ""JsonWebKeySet.json"",
                                                ""logout_session_supported"" : true,
                                                ""microsoft_multi_refresh_token"" : true,
                                                ""op_policy_uri"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/op_policy_uri"",
                                                ""op_tos_uri"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/op_tos_uri"",
                                                ""request_object_encryption_alg_values_supported"" : [""A192KW"", ""A256KW""],
                                                ""request_object_encryption_enc_values_supported"" : [""A192GCM"",""A256GCM""],
                                                ""request_object_signing_alg_values_supported"" : [""PS256"", ""PS512""],
                                                ""request_parameter_supported"" : true,
                                                ""request_uri_parameter_supported"" : true,
                                                ""require_request_uri_registration"" : true,
                                                ""response_modes_supported"" : [""query"", ""fragment"",""form_post""],
                                                ""response_types_supported"" : [""code"",""id_token"",""code id_token""],
                                                ""service_documentation"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/service_documentation"",
                                                ""scopes_supported"" : [""openid""],
                                                ""subject_types_supported"" : [""pairwise""],
                                                ""token_endpoint"" : ""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token"",
                                                ""token_endpoint_auth_methods_supported"" : [""client_secret_post"",""private_key_jwt""],
                                                ""token_endpoint_auth_signing_alg_values_supported"" : [""ES192"", ""ES256""],
                                                ""ui_locales_supported"" : [""hak-CN"", ""en-us""],
                                                ""userinfo_endpoint"" : ""https://login.microsoftonline.com/add29489-7269-41f4-8841-b63c95564420/openid/userinfo"",
                                                ""userinfo_encryption_alg_values_supported"" : [""ECDH-ES+A128KW"",""ECDH-ES+A192KW""],
                                                ""userinfo_encryption_enc_values_supported"" : [""A256CBC-HS512"", ""A128CBC-HS256""],
                                                ""userinfo_signing_alg_values_supported"" : [""ES384"", ""ES512""]
                                            }";

        public static string OpenIdConnectMetadataSingleX509DataString =
                                            @"{ ""authorization_endpoint"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize"",
                                                ""check_session_iframe"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession"",
                                                ""end_session_endpoint"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout"",
                                                ""id_token_signing_alg_values_supported"":[""RS256""],
                                                ""issuer"":""https://sts.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/"",
                                                ""jwks_uri"":""JsonWebKeySetSingleX509Data.json"",
                                                ""microsoft_multi_refresh_token"":true,
                                                ""response_types_supported"":[""code"",""id_token"",""code id_token""],
                                                ""response_modes_supported"":[""query"",""fragment"",""form_post""],
                                                ""scopes_supported"":[""openid""],
                                                ""subject_types_supported"":[""pairwise""],
                                                ""token_endpoint"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token"",
                                                ""token_endpoint_auth_methods_supported"":[""client_secret_post"",""private_key_jwt""]
                                            }";

        public static string JsonWithSigningKeys =
                                            @"{ ""authorization_endpoint"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize"",
                                                ""check_session_iframe"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession"",
                                                ""end_session_endpoint"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout"",
                                                ""id_token_signing_alg_values_supported"":[""RS256""],
                                                ""issuer"":""https://sts.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/"",
                                                ""jwks_uri"":""JsonWebKeySetSingleX509Data.json"",
                                                ""microsoft_multi_refresh_token"":true,
                                                ""response_types_supported"":[""code"",""id_token"",""code id_token""],
                                                ""response_modes_supported"":[""query"",""fragment"",""form_post""],
                                                ""scopes_supported"":[""openid""],
                                                ""subject_types_supported"":[""pairwise""],
                                                ""token_endpoint"":""https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token"",
                                                ""token_endpoint_auth_methods_supported"":[""client_secret_post"",""private_key_jwt""],
                                                ""SigningKeys"":[""key1"",""key2""]
                                            }";

        public static string OpenIdConnectMetadataBadX509DataString = @"{""jwks_uri"":""JsonWebKeySetBadX509Data.json""}";
        public static string OpenIdConnectMetadataBadBase64DataString = @"{""jwks_uri"":""JsonWebKeySetBadBase64Data.json""}";
        public static string OpenIdConnectMetadataBadUriKeysString = @"{""jwks_uri"":""___NoSuchFile___""}";
        public static string OpenIdConnectMetadataBadFormatString = @"{""issuer""::""https://sts.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/""}";
        public static string OpenIdConnectMetadataPingLabsJWKSString = @"{""jwks_uri"":""PingLabsJWKS.json""}";
        public static string OpenIdConnectMetatadataBadJson = @"{...";

        public static string MixedCaseNames =
            """
            {
                "Request_parameter_supported": true,
                "claiMs_parameter_supported": true,
                "Introspection_Endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/introspect",
                "Response_modes_supported": [ "query", "fragment", "form_post" ],
                "scopes_sUpported": [ "address", "phone", "openid", "profile", "email" ],
                "check_sesSion_iframe": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession",
                "Issuer": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token",
                "authorization_enDpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize",
                "introspection_endpoint_auTh_methods_supported": [ "client_secret_basic", "client_secret_post" ],
                "Claims_supported": [ "name", "locale" ],
                "userinfo_signing_alg_vAlues_supported": [ "RS256" ],
                "Token_Endpoint_Auth_Methods_Supported": [ "client_secret_basic", "client_secret_post" ],
                "token_endpOint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token",
                "Response_types_supported": [ "id_token token", "code", "code id_token token" ],
                "grant_types_sUpported": [ "authorization_code", "implicit" ],
                "End_session_Endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout",
                "Userinfo_endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/userinfo",
                "jwks_Uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks",
                "Subject_types_supported": [ "public" ],
                "id_tokEn_signing_alg_values_supported": [ "RS256" ],
                "Request_object_signing_alg_values_supported": [ "RS256", "RS384" ],
                "Frontchannel_logout_session_supported": true
            }
            """;

        public static string LowerCaseNames =
            """
            { "request_parameter_supported": true,
                "claims_parameter_supported": true,
                "introspection_endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/introspect",
                "response_modes_supported": [ "query", "fragment", "form_post" ],
                "scopes_supported": [ "address", "phone", "openid", "profile", "email" ],
                "check_session_iframe": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession",
                "issuer": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token",
                "authorization_endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize",
                "introspection_endpoint_auth_methods_supported": [ "client_secret_basic", "client_secret_post" ],
                "claims_supported": [ "name", "locale" ],
                "userinfo_signing_alg_values_supported": [ "RS256" ],
                "token_endpoint_auth_methods_supported": [ "client_secret_basic", "client_secret_post" ],
                "token_endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token",
                "response_types_supported": [ "id_token token", "code", "code id_token token" ],
                "grant_types_supported": [ "authorization_code", "implicit" ],
                "end_session_endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout",
                "userinfo_endpoint": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/userinfo",
                "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks",
                "subject_types_supported": [ "public" ],
                "id_token_signing_alg_values_supported": [ "RS256" ],
                "request_object_signing_alg_values_supported": [ "RS256", "RS384" ],
                "frontchannel_logout_session_supported": true
            }
            """;

        public static string ArrayAtBeginning =
            """
            {
                "array": ["query","fragment","form_post"],
                "request_parameter_supported": true,
                "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks"
            }
            """;

        public static string ArrayAtEnd =
            """
            {
                "request_parameter_supported": true,
                "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks",
                "array": ["query","fragment","form_post"]
            }
            """;

        public static string ArrayInMiddle =
            """
            {
                "request_parameter_supported": true,
                "array": ["query","fragment","form_post"],
                "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks"
            }
            """;

        public static string ObjectAtBegining =
            """
            {
              "object": {"query":["fragment","form_post"]},
              "request_parameter_supported": true,
              "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks"
            }
            """;

        public static string ObjectAtEnd =
            """
            {
                "request_parameter_supported": true,
                "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks",
                "object": {"query":["fragment","form_post"]}
            }
            """;

        public static string ObjectInMiddle =
            """
            {
                "request_parameter_supported": true,
                "object": {"query":["fragment","form_post"]},
                "jwks_uri": "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks"
            }
            """;

        public static string NoDuplicates =
            """
            { "claims_parameter_Supported": false,
              "request_parameter_supported": false
            }
            """;

        public static string MixedCaseWithDuplicates =
            """
            {
                "Request_parameter_supported": true,
                "claims_parameter_supported": true,
                "claims_parameter_Supported": false,
                "request_parameter_supported": false
            }
            """;

        public static string UnknownStringAtEnd =
            """
            {
                "Request_parameter_supported": true,
                "claims_parameter_supported": true,
                "claims_parameter_Supported": false,
                "request_parameter_supported": false,
                "unknown": "unknown"
            }
            """;

        public static string UnknownObjectAtEnd =
            """
            {
                "Request_parameter_supported": true,
                "claims_parameter_supported": true,
                "claims_parameter_Supported": false,
                "request_parameter_supported": false,
                "unknown": { "name" : "value" }
            }
            """;

        public static string Working =
            """
            {
                "issuer":"https://demo.duendesoftware.com",
                "authorization_endpoint":"https://demo.duendesoftware.com/connect/authorize",
                "token_endpoint":"https://demo.duendesoftware.com/connect/token",
                "userinfo_endpoint":"https://demo.duendesoftware.com/connect/userinfo",
                "end_session_endpoint":"https://demo.duendesoftware.com/connect/endsession",
                "check_session_iframe":"https://demo.duendesoftware.com/connect/checksession",
                "revocation_endpoint":"https://demo.duendesoftware.com/connect/revocation",
                "introspection_endpoint":"https://demo.duendesoftware.com/connect/introspect",
                "device_authorization_endpoint":"https://demo.duendesoftware.com/connect/deviceauthorization",
                "backchannel_authentication_endpoint":"https://demo.duendesoftware.com/connect/ciba",
                "frontchannel_logout_supported":true,
                "frontchannel_logout_session_supported":true,
                "backchannel_logout_supported":true,
                "backchannel_logout_session_supported":true,
                "scopes_supported":["openid","profile","email","api","resource1.scope1","resource1.scope2","resource2.scope1","resource2.scope2","resource3.scope1","resource3.scope2","scope3","scope4","shared.scope","transaction","offline_access"],
                "claims_supported":["sub","name","family_name","given_name","middle_name","nickname","preferred_username","profile","picture","website","gender","birthdate","zoneinfo","locale","updated_at","email","email_verified"],"grant_types_supported":["authorization_code","client_credentials","refresh_token","implicit","password","urn:ietf:params:oauth:grant-type:device_code","urn:openid:params:grant-type:ciba"],
                "response_types_supported":["code","token","id_token","id_token token","code id_token","code token","code id_token token"],
                "response_modes_supported":["form_post","query","fragment"],
                "token_endpoint_auth_methods_supported":["client_secret_basic","client_secret_post","private_key_jwt"],
                "id_token_signing_alg_values_supported":["RS256"],
                "subject_types_supported":["public"],
                "code_challenge_methods_supported":["plain","S256"],
                "request_parameter_supported":true,
                "request_object_signing_alg_values_supported":["RS256","RS384","RS512","PS256","PS384","PS512","ES256","ES384","ES512","HS256","HS384","HS512"],
                "prompt_values_supported":["none","login","consent","select_account"],
                "authorization_response_iss_parameter_supported":true,
                "backchannel_token_delivery_modes_supported":["poll"],
                "backchannel_user_code_parameter_supported":true,
                "dpop_signing_alg_values_supported":["RS256","RS384","RS512","PS256","PS384","PS512","ES256","ES384","ES512"],
                "jwks_uri":"https://demo.duendesoftware.com/.well-known/openid-configuration/jwks",
                "mtls_endpoint_aliases": {"token_endpoint": "https://demo.duendesoftware.com/connect/token"}
            }
            """;

        public static string NotWorking =
            """
            {
                "issuer":"https://demo.duendesoftware.com",
                "authorization_endpoint":"https://demo.duendesoftware.com/connect/authorize",
                "token_endpoint":"https://demo.duendesoftware.com/connect/token",
                "userinfo_endpoint":"https://demo.duendesoftware.com/connect/userinfo",
                "end_session_endpoint":"https://demo.duendesoftware.com/connect/endsession",
                "check_session_iframe":"https://demo.duendesoftware.com/connect/checksession",
                "revocation_endpoint":"https://demo.duendesoftware.com/connect/revocation",
                "introspection_endpoint":"https://demo.duendesoftware.com/connect/introspect",
                "device_authorization_endpoint":"https://demo.duendesoftware.com/connect/deviceauthorization",
                "backchannel_authentication_endpoint":"https://demo.duendesoftware.com/connect/ciba",
                "frontchannel_logout_supported":true,
                "frontchannel_logout_session_supported":true,
                "backchannel_logout_supported":true,
                "backchannel_logout_session_supported":true,
                "scopes_supported":["openid","profile","email","api","resource1.scope1","resource1.scope2","resource2.scope1","resource2.scope2","resource3.scope1","resource3.scope2","scope3","scope4","shared.scope","transaction","offline_access"],
                "claims_supported":["sub","name","family_name","given_name","middle_name","nickname","preferred_username","profile","picture","website","gender","birthdate","zoneinfo","locale","updated_at","email","email_verified"],
                "grant_types_supported":["authorization_code","client_credentials","refresh_token","implicit","password","urn:ietf:params:oauth:grant-type:device_code","urn:openid:params:grant-type:ciba"],
                "response_types_supported":["code","token","id_token","id_token token","code id_token","code token","code id_token token"],
                "response_modes_supported":["form_post","query","fragment"],
                "token_endpoint_auth_methods_supported":["client_secret_basic","client_secret_post","private_key_jwt"],
                "id_token_signing_alg_values_supported":["RS256"],
                "subject_types_supported":["public"],
                "code_challenge_methods_supported":["plain","S256"],
                "request_parameter_supported":true,
                "request_object_signing_alg_values_supported":["RS256","RS384","RS512","PS256","PS384","PS512","ES256","ES384","ES512","HS256","HS384","HS512"],
                "prompt_values_supported":["none","login","consent","select_account"],
                "authorization_response_iss_parameter_supported":true,
                "backchannel_token_delivery_modes_supported":["poll"],
                "backchannel_user_code_parameter_supported":true,
                "dpop_signing_alg_values_supported":["RS256","RS384","RS512","PS256","PS384","PS512","ES256","ES384","ES512"],
                "mtls_endpoint_aliases": {"token_endpoint": "https://demo.duendesoftware.com/connect/token"},
                "jwks_uri":"https://demo.duendesoftware.com/.well-known/openid-configuration/jwks"
            }
            """;

        // https://accounts.google.com/.well-known/openid-configuration
        // Kept arrays on one line otherwise JsonElement.GetRawText will not match.
        public static string AccountsGoogleCom =
            """
            {
                "issuer": "https://accounts.google.com",
                "authorization_endpoint": "https://accounts.google.com/o/oauth2/v2/auth",
                "device_authorization_endpoint": "https://oauth2.googleapis.com/device/code",
                "token_endpoint": "https://oauth2.googleapis.com/token",
                "userinfo_endpoint": "https://openidconnect.googleapis.com/v1/userinfo",
                "revocation_endpoint": "https://oauth2.googleapis.com/revoke",
                "jwks_uri": "https://www.googleapis.com/oauth2/v3/certs",
                "response_types_supported": ["code","token","id_token","code token","code id_token","token id_token","code token id_token","none"],
                "subject_types_supported": ["public"],
                "id_token_signing_alg_values_supported": ["RS256"],
                "scopes_supported": ["openid","email","profile"],
                "token_endpoint_auth_methods_supported": ["client_secret_post","client_secret_basic"],
                "claims_supported": ["aud","email","email_verified","exp","family_name","given_name","iat","iss","locale","name","picture","sub"],
                "code_challenge_methods_supported": ["plain","S256"],
                "grant_types_supported": ["authorization_code","refresh_token","urn:ietf:params:oauth:grant-type:device_code","urn:ietf:params:oauth:grant-type:jwt-bearer"]
            }
            """;

        #endregion

        public static OpenIdConnectConfiguration AccountsGoogleComConfig;
        public static OpenIdConnectConfiguration ArrayConfig;
        public static OpenIdConnectConfiguration ObjectConfig;

        static OpenIdConfigData()
        {
            // AccountsGoogleComConfig
            AccountsGoogleComConfig = new OpenIdConnectConfiguration
            {
                AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth",
                Issuer = "https://accounts.google.com",
                JwksUri = "https://www.googleapis.com/oauth2/v3/certs",
                TokenEndpoint = "https://oauth2.googleapis.com/token",
                UserInfoEndpoint = "https://openidconnect.googleapis.com/v1/userinfo",
            };

            AddToCollection(AccountsGoogleComConfig.ResponseTypesSupported, "code", "token", "id_token", "code token", "code id_token", "token id_token", "code token id_token", "none");
            AccountsGoogleComConfig.SubjectTypesSupported.Add("public");
            AccountsGoogleComConfig.IdTokenSigningAlgValuesSupported.Add("RS256");
            AddToCollection(AccountsGoogleComConfig.ScopesSupported, "openid", "email", "profile");
            AddToCollection(AccountsGoogleComConfig.TokenEndpointAuthMethodsSupported, "client_secret_post", "client_secret_basic");
            AddToCollection(AccountsGoogleComConfig.ClaimsSupported, "aud", "email", "email_verified", "exp", "family_name", "given_name", "iat", "iss", "locale", "name", "picture", "sub");
            AddToCollection(AccountsGoogleComConfig.GrantTypesSupported, "authorization_code", "refresh_token", "urn:ietf:params:oauth:grant-type:device_code", "urn:ietf:params:oauth:grant-type:jwt-bearer");

            // Adjust if Google changes their config or https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/2456 is fixed.
            AccountsGoogleComConfig.AdditionalData.Add("device_authorization_endpoint", "https://oauth2.googleapis.com/device/code");
            AccountsGoogleComConfig.AdditionalData.Add("code_challenge_methods_supported", JsonUtilities.CreateJsonElement( """ ["plain","S256"] """));
            AccountsGoogleComConfig.AdditionalData.Add("revocation_endpoint", "https://oauth2.googleapis.com/revoke");

            // ArrayConfig, used for testing arrays in the middle, beginning, and end of the json.
            ArrayConfig = new OpenIdConnectConfiguration
            {
                RequestParameterSupported = true,
                JwksUri = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks",
            };

            ArrayConfig.AdditionalData.Add("array", JsonUtilities.CreateJsonElement(""" ["query","fragment","form_post"] """));

            // ObjectConfig, used for testing objects in the middle, beginning, and end of the json.
            ObjectConfig = new OpenIdConnectConfiguration
            {
                RequestParameterSupported = true,
                JwksUri = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/jwks",
            };

            ObjectConfig.AdditionalData.Add("object", JsonUtilities.CreateJsonElement(""" {"query":["fragment","form_post"]} """));

            PingLabs = new OpenIdConnectConfiguration()
            {
                JwksUri = "PingLabsJWKS.json",
                JsonWebKeySet = new JsonWebKeySet()
            };

            PingLabs.SigningKeys.Add(KeyingMaterial.RsaSecurityKeyFromPing1);
            PingLabs.SigningKeys.Add(KeyingMaterial.RsaSecurityKeyFromPing2);
            PingLabs.SigningKeys.Add(KeyingMaterial.RsaSecurityKeyFromPing3);
            PingLabs.JsonWebKeySet.Keys.Add(DataSets.JsonWebKeyFromPing1);
            PingLabs.JsonWebKeySet.Keys.Add(DataSets.JsonWebKeyFromPing2);
            PingLabs.JsonWebKeySet.Keys.Add(DataSets.JsonWebKeyFromPing3);

            // matches with OpenIdConnectMetadataString
            SetDefaultConfiguration(FullyPopulated);
            FullyPopulated.AdditionalData["microsoft_multi_refresh_token"] = true;

            // Config with X509Data
            SingleX509Data.AdditionalData["microsoft_multi_refresh_token"] = true;
            SingleX509Data.AuthorizationEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize";
            SingleX509Data.CheckSessionIframe = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession";
            SingleX509Data.EndSessionEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout";
            SingleX509Data.Issuer = "https://sts.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/";
            SingleX509Data.JsonWebKeySet = DataSets.JsonWebKeySetX509Data;
            SingleX509Data.JwksUri = "JsonWebKeySetSingleX509Data.json";
            SingleX509Data.IdTokenSigningAlgValuesSupported.Add("RS256");
            AddToCollection(SingleX509Data.ResponseTypesSupported, new string[] { "code", "id_token", "code id_token" });
            AddToCollection(SingleX509Data.ResponseModesSupported, new string[] { "query", "fragment", "form_post" });
            SingleX509Data.ScopesSupported.Add("openid");
            SingleX509Data.SigningKeys.Add(KeyingMaterial.X509SecurityKey1);
            SingleX509Data.SubjectTypesSupported.Add("pairwise");
            SingleX509Data.TokenEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token";
            AddToCollection(SingleX509Data.TokenEndpointAuthMethodsSupported, new string[] { "client_secret_post", "private_key_jwt" });
        }

        public static OpenIdConnectConfiguration Default
        {
            get => SetDefaultConfiguration(new OpenIdConnectConfiguration());
        }

        private static OpenIdConnectConfiguration SetDefaultConfiguration(OpenIdConnectConfiguration config)
        {
            AddToCollection(config.AcrValuesSupported, "acr_value1", "acr_value2", "acr_value3");
            config.AuthorizationEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/authorize";
            config.CheckSessionIframe = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/checksession";
            AddToCollection(config.ClaimsLocalesSupported, "claim_local1", "claim_local2", "claim_local3");
            config.ClaimsParameterSupported = true;
            AddToCollection(config.ClaimsSupported, "sub", "iss", "aud", "exp", "iat", "auth_time", "acr", "amr", "nonce", "email", "given_name", "family_name", "nickname");
            AddToCollection(config.ClaimTypesSupported, "Normal Claims", "Aggregated Claims", "Distributed Claims");
            AddToCollection(config.DisplayValuesSupported, "displayValue1", "displayValue2", "displayValue3");
            config.EndSessionEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/logout";
            config.FrontchannelLogoutSessionSupported = "true";
            config.FrontchannelLogoutSupported = "true";
            AddToCollection(config.GrantTypesSupported, "authorization_code", "implicit");
            config.HttpLogoutSupported = true;
            AddToCollection(config.IdTokenEncryptionAlgValuesSupported, "RSA1_5", "A256KW");
            AddToCollection(config.IdTokenEncryptionEncValuesSupported, "A128CBC-HS256", "A256CBC-HS512");
            AddToCollection(config.IdTokenSigningAlgValuesSupported, "RS256");
            config.IntrospectionEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/introspect";
            AddToCollection(config.IntrospectionEndpointAuthMethodsSupported, "client_secret_post", "private_key_jwt");
            AddToCollection(config.IntrospectionEndpointAuthSigningAlgValuesSupported, "ES192", "ES256");
            config.Issuer = "https://sts.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/";
            config.JwksUri = "JsonWebKeySet.json";
            config.LogoutSessionSupported = true;
            config.OpPolicyUri = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/op_policy_uri";
            config.OpTosUri = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/op_tos_uri";
            AddToCollection(config.RequestObjectEncryptionAlgValuesSupported, "A192KW", "A256KW");
            AddToCollection(config.RequestObjectEncryptionEncValuesSupported, "A192GCM", "A256GCM");
            AddToCollection(config.RequestObjectSigningAlgValuesSupported, "PS256", "PS512");
            config.RequestParameterSupported = true;
            config.RequestUriParameterSupported = true;
            config.RequireRequestUriRegistration = true;
            AddToCollection(config.ResponseModesSupported, "query", "fragment", "form_post");
            AddToCollection(config.ResponseTypesSupported, "code", "id_token", "code id_token");
            config.ScopesSupported.Add("openid");
            config.ServiceDocumentation = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/service_documentation";
            config.SubjectTypesSupported.Add("pairwise");
            config.TokenEndpoint = "https://login.windows.net/d062b2b0-9aca-4ff7-b32a-ba47231a4002/oauth2/token";
            AddToCollection(config.TokenEndpointAuthMethodsSupported, "client_secret_post", "private_key_jwt");
            AddToCollection(config.TokenEndpointAuthSigningAlgValuesSupported, "ES192", "ES256");
            AddToCollection(config.UILocalesSupported, "hak-CN", "en-us");
            config.UserInfoEndpoint = "https://login.microsoftonline.com/add29489-7269-41f4-8841-b63c95564420/openid/userinfo";
            AddToCollection(config.UserInfoEndpointEncryptionAlgValuesSupported, "ECDH-ES+A128KW", "ECDH-ES+A192KW");
            AddToCollection(config.UserInfoEndpointEncryptionEncValuesSupported, "A256CBC-HS512", "A128CBC-HS256");
            AddToCollection(config.UserInfoEndpointSigningAlgValuesSupported, "ES384", "ES512");

            return config;
        }

        private static void AddToCollection(ICollection<string> collection, params string[] strings)
        {
            foreach (var str in strings)
                collection.Add(str);
        }
    }
}
